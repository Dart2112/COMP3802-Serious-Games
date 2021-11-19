using UnityEngine;

namespace MainMenus.Scripts
{
    public class PausedBehaviour : MonoBehaviour
    {
        public static string sceneToReturnTo;

        public void Resume()
        {
            GameManager.Scripts.GameManager.UnloadScene("pauseMenu", sceneToReturnTo);
        }

        public void Credits()
        {
            GameManager.Scripts.GameManager.LoadNewScene("Credits", sceneToReturnTo);
            GameManager.Scripts.GameManager.UnloadScene("pauseMenu", "Credits");
        }

        public void Exit()
        {
            GameManager.Scripts.GameManager.LoadNewScene("MainMenus", sceneToReturnTo);
            GameManager.Scripts.GameManager.UnloadScene("pauseMenu", "MainMenus");
        }
    }
}