using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameManager.Scripts
{
    public class GameManager : MonoBehaviour
    {
        //SCENE MANAGEMENT

        //The first scene that needs to be loaded for the game
        public string mainSceneName;

        //The scene being loaded (This is given by other classes)
        private string _sceneName;

        //The scene that should be active (Might still be loading though)
        private string _activeScene = "";

        //Items to be toggled
        private static readonly Dictionary<string, GameObject> ToggleItems = new Dictionary<string, GameObject>();

        private static int _physioTherapyIteration;

        private void Start()
        {
            //Clear all scores as these do persist restarts
            PlayerPrefs.DeleteAll();
            //Load the main scene and dont unload anything
            PlayerPrefs.SetString("GameManager.LoadScene", mainSceneName);
            PlayerPrefs.SetString("GameManager.UnloadScene", "");
            PlayerPrefs.SetString("GameManager.ActiveScene", mainSceneName);
            _physioTherapyIteration = 0;
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            string unloadScene = PlayerPrefs.GetString("GameManager.UnloadScene");
            //If we are unloading a scene then we add it to the list here
            if (unloadScene != "")
            {
                SceneManager.UnloadSceneAsync(unloadScene);
                Debug.Log("Unloading " + unloadScene);
                PlayerPrefs.SetString("GameManager.UnloadScene", "");
            }

            //Fetch this value to check if a scene needs to be loaded
            _sceneName = PlayerPrefs.GetString("GameManager.LoadScene");
            //Check if there is one to load
            if (_sceneName != "")
            {
                Debug.Log("Loading " + _sceneName);
                //Load the scene
                SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
                //Clear the variable to only load the scene once
                PlayerPrefs.SetString("GameManager.LoadScene", "");
            }

            string activeScene = PlayerPrefs.GetString("GameManager.ActiveScene");
            //Set the active scene variable
            if (activeScene != "")
            {
                _activeScene = activeScene;
                PlayerPrefs.SetString("GameManager.ActiveScene", "");
            }

            //Check if the correct scene is active
            bool setActive = SceneManager.GetActiveScene().name != _activeScene;

            //Loop over all the loaded or loading scenes
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene s = SceneManager.GetSceneAt(i);

                //If this is the scene that should be active and its ready then we set it as the active scene
                if (setActive && s.name == _activeScene && s.isLoaded)
                {
                    Debug.Log("Setting " + s.name + " as the active scene");
                    SceneManager.SetActiveScene(s);
                }
            }
        }

        public static void ToggleItem(string tag, bool state)
        {
            if (!ToggleItems.TryGetValue(tag, out _))
            {
                GameObject obj = GameObject.FindWithTag(tag);
                if (obj == null)
                    return;
                ToggleItems[tag] = obj;
            }

            ToggleItems[tag].SetActive(state);
        }

        //Use this to unload a mini-game and revert back to another scene
        public static void UnloadScene(string sceneToUnload, string newActiveScene)
        {
            PlayerPrefs.SetString("GameManager.UnloadScene", sceneToUnload);
            PlayerPrefs.SetString("GameManager.ActiveScene", newActiveScene);
        }

        //Use this to load a Scene, Leave unload scene blank if you dont want to unload a scene
        public static void LoadNewScene(string sceneToLoad, string unloadScene)
        {
            PlayerPrefs.SetString("GameManager.LoadScene", sceneToLoad);
            PlayerPrefs.SetString("GameManager.ActiveScene", sceneToLoad);
            PlayerPrefs.SetString("GameManager.UnloadScene", unloadScene);
        }

        //SCORE MANAGEMENT

        public enum Puzzle
        {
            OccupationalTherapy,
            PhysioTherapy,
            Optometry,
            ExercisePhysio
        }

        public static void SubmitScore(Puzzle puzzle, int score)
        {
            PlayerPrefs.SetInt(puzzle + ".score", score);
            Debug.Log(puzzle + ".score: " + score);
        }

        public static int RetrieveScore(Puzzle puzzle)
        {
            int score = PlayerPrefs.GetInt(puzzle + ".score", -1);
            Debug.Log(puzzle + ".score: " + score);
            return score;
        }

        public static float RetrieveAverageScore()
        {
            float i = 0;
            float total = 0;
            foreach (Puzzle puzzle in Enum.GetValues(typeof(Puzzle)))
            {
                i++;
                total += PlayerPrefs.GetInt(puzzle + ".score");
            }

            return total / i;
        }

        // Keeps track of the number of restarts for the physio puzzle
        public static void PhysioIterate()
        {
            _physioTherapyIteration++;
            Debug.Log("Iteration" + _physioTherapyIteration);
        }

        public static int GetPhysioCount()
        {
            return _physioTherapyIteration;
        }
    }
}