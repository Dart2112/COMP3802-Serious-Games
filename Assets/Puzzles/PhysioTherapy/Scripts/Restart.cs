using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject endMenu;
    void start() { 
    }

    public void restart() {
        Debug.Log("Running Restart");
        GameManager.Scripts.GameManager.PhysioIterate();
        // Will need to be modified
        //UnityEngine.SceneManagement.SceneManager.LoadScene("PhysioTherapyPuzzle");
        //GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
        GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "PhysioTherapyPuzzle");
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
