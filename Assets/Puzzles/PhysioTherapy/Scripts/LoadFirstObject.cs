using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class LoadFirstObject : MonoBehaviour
    {
        public Transform sceneStartPos;
        public Transform startPos;
        public GameObject startMenu;
        public GameObject endMenu;
        // Start is called before the first frame update
        void Start()
        {
            GameManager.Scripts.GameManager.ToggleItem("MainMenus", false);
            /*    GameObject myPrefab = GameAssets.i.block;
            Instantiate(myPrefab, startPos.position, startPos.rotation);*/
            startMenu.SetActive(true);
            //Debug.Log("Hello");
            Time.timeScale = 1;
            startPos = GameObject.Find("StartPos").transform;
            //startPos.position = sceneStartPos.position;

            //endMenu = GameObject.Find("UIend") as GameObject;

        }

        void Update() {
            if (Input.GetKeyDown("space"))
            {
                startMenu.SetActive(false);
                GameObject myPrefab = GameAssets.i.block;
                Instantiate(myPrefab, startPos.position, startPos.rotation);
                this.enabled = false;
            }
       
        }
    }
}
