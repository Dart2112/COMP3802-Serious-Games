using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenus.Scripts
{
    public class PauseBtn : MonoBehaviour
    {
        public void LoadPauseMenu()
        {
            PausedBehaviour.sceneToReturnTo = SceneManager.GetActiveScene().name;
            GameManager.Scripts.GameManager.LoadNewScene("pauseMenu", "");
        }
    }
}