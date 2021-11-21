using UnityEngine;

namespace Puzzles.ExercisePhysio
{
    public class UIHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject startMenu;
        public GameObject endMenu;
        private ButtonBehaviour bScript;

        void Start() {
            bScript = GameObject.Find("ButtonBehaviour").GetComponent<ButtonBehaviour>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                if (startMenu.activeSelf)
                {
                    startMenu.SetActive(false);
                    bScript.TimeStart();

                }
                else if (endMenu.activeSelf)
                {
                    GameManager.Scripts.GameManager.LoadNewScene("EP_End", "ExercisePhysio");
                }
            }
        }
    }
}
