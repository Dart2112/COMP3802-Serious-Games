using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Puzzles.PhysioTherapy.Scripts {
    public class Restart : MonoBehaviour
    {
        public GameObject endMenu;
        //private UIBehaviour _ui;
        void start() {
            //_ui = GameObject.Find("UIBehaviour").GetComponent<UIBehaviour>();
           /* if (_ui == null) {
                Debug.Log("I am null");
            } else Debug.Log("I am not null");*/
        }

        public void restart() {
            Debug.Log("Running Restart2");
            Debug.Log("Excuse me");
            //Debug.Log(_ui);
            

            GameManager.Scripts.GameManager.PhysioIterate();
            // Will need to be modified
            //UnityEngine.SceneManagement.SceneManager.LoadScene("PhysioTherapyPuzzle");
            //Debug.Log("unpause " + _ui);
            //_ui.unPause();
            GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
            //GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "PhysioTherapyPuzzle");
            //endMenu.SetActive(false);
        }

        public void quit() {
#if UNITY_EDITOR
        Debug.Log("hasQuit");
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
