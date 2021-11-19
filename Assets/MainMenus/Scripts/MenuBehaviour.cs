using UnityEngine;

namespace MainMenus.Scripts
{
    public class MenuBehaviour : MonoBehaviour
    {
        //public GameObject greetScreen;
        public GameObject mainMenu;
        public GameObject settings;

        // Start is called before the first frame update
        void Start()
        {
            // greetScreen.SetActive(true);
            mainMenu.SetActive(true);
            settings.SetActive(false);
        }


        /*public void OpenMainMenu() {
        greetScreen.SetActive(false);
        mainMenu.SetActive(true);
    }*/

        /*public void CloseMainMenu() {
        mainMenu.SetActive(false);
        greetScreen.SetActive(true);
    }*/

        public void Quit()
        {
#if UNITY_EDITOR
            Debug.Log("hasQuit");
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        public void OpenSettingsMenu()
        {
            mainMenu.SetActive(false);
            settings.SetActive(true);
        }

        public void CloseSettingsMenu()
        {
            settings.SetActive(false);
            mainMenu.SetActive(true);
        }

        public void PlayCredits()
        {
            GameManager.Scripts.GameManager.LoadNewScene("credits", "MainMenus");
        }

        public void LoadFirstScene()
        {
            GameManager.Scripts.GameManager.LoadNewScene("Intro_Start", "MainMenus");
        }
    }
}