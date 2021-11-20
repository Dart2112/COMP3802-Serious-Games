using UnityEngine;

namespace Puzzles.ExercisePhysio
{
    public class UIHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject startMenu;
        public GameObject endMenu;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                if (startMenu.activeSelf)
                {
                    startMenu.SetActive(false);
                }
                else if (endMenu.activeSelf)
                {
                    GameManager.Scripts.GameManager.LoadNewScene("EP_End", "ExercisePhysio");
                }
            }
        }
    }
}
