using UnityEngine;

namespace MainMenus.Scripts
{
    public class SplashScreen : MonoBehaviour
    {
        public int timeToKeep = 120;
        public int currentTime;

        void FixedUpdate()
        {
            currentTime++;
            if (currentTime == timeToKeep)
            {
                GameManager.Scripts.GameManager.LoadNewScene("MainMenus", "Splash Screen");
            }
        }
    }
}