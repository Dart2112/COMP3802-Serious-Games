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
        UnityEngine.SceneManagement.SceneManager.LoadScene("PhysioTherapyPuzzle");
        endMenu.SetActive(false);
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
