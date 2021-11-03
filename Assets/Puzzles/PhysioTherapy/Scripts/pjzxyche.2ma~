using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class RestartControl : MonoBehaviour
    {
        public void Restart() {
            Debug.Log("Running Restart");
            GameManager.Scripts.GameManager.PhysioIterate();
            // Will need to be modified
            //UnityEngine.SceneManagement.SceneManager.LoadScene("PhysioTherapyPuzzle");
            //GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
            //GameObject.Find("UIBehaviour").GetComponent<UIBehaviour>().unPause();
            GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
        }

        public void Quit() {
#if UNITY_EDITOR
            Debug.Log("hasQuit");
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
