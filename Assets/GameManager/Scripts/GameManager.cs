using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager.Scripts
{
    public class GameManager : MonoBehaviour
    {
        //The first scene that needs to be loaded for the game
        public string mainSceneName;

        //The scene being loaded (This is given by other classes)
        private string _sceneName;

        //The scene that should be active (Might still be loading though)
        private string _activeScene = "";

        //List of scenes that need to be unloaded (Probably doesnt need to be a list but its just safer to do this)
        private readonly List<string> _unload = new List<string>();

        private void Start()
        {
            //Load the main scene and dont unload anything
            PlayerPrefs.SetString("GameManager.LoadScene", mainSceneName);
            PlayerPrefs.SetString("GameManager.UnloadScene", "");
            PlayerPrefs.SetString("GameManager.ActiveScene", mainSceneName);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //Fetch this value to check if a scene needs to be loaded
            _sceneName = PlayerPrefs.GetString("GameManager.LoadScene");
            //Check if there is one to load
            if (_sceneName != "")
            {
                //Clear the variable to only load the scene once
                PlayerPrefs.SetString("GameManager.LoadScene", "");
                //Load the scene
                SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
            }

            string unloadScene = PlayerPrefs.GetString("GameManager.UnloadScene");
            //If we are unloading a scene then we add it to the list here
            if (unloadScene != "")
            {
                _unload.Add(unloadScene);
                PlayerPrefs.SetString("GameManager.UnloadScene", "");
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
                //Unload this scene if its in the unload list
                if (_unload.Contains(s.name))
                {
                    SceneManager.UnloadSceneAsync(s);
                }

                //If this is the scene that should be active and its ready then we set it as the active scene
                if (setActive && s.name == _activeScene && s.isLoaded)
                {
                    SceneManager.SetActiveScene(s);
                }
            }
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
            PlayerPrefs.SetString("GameManager.UnloadScene", unloadScene);
        }
    }
}