using UnityEngine;

namespace GameManager.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private string _sceneName;

        // Update is called once per frame
        void Update()
        {
            _sceneName = PlayerPrefs.GetString("SceneToLoad");
            if (_sceneName != "")
            {
                //TODO: Start loading new scene here
                //TODO: also unload the old scene
                _sceneName = "";
            }
        }

        public static void LoadNewScene(string sceneName)
        {
            PlayerPrefs.SetString("SceneToLoad", sceneName);
        }
    }
}