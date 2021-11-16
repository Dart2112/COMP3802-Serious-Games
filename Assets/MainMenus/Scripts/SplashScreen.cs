using UnityEngine;

namespace MainMenus.Scripts
{
    public class SplashScreen : MonoBehaviour
    {
        public int framesToWait = 240;
        public int currentFrame = 0;

        void FixedUpdate()
        {
            currentFrame++;
            if (framesToWait == currentFrame)
            {
                GameManager.Scripts.GameManager.LoadNewScene("MainMenus", "Splash Screen");
            }
        }
    }
}
