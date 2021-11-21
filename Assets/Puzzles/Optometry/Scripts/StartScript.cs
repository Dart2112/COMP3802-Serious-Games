using UnityEngine;

namespace Puzzles.Optometry.Scripts
{
    public class StartScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject startMenu;
        public GameObject endMenu;
        public float gameTime;

        // Update is called once per frame
        void Update()
        {
            if (!endMenu.activeSelf && !startMenu.activeSelf)
            {
                gameTime += Time.deltaTime;
            }

            if (Input.GetKeyDown("space"))
            {
                if (startMenu.activeSelf)
                {
                    startMenu.SetActive(false);
                }
                else if (endMenu.activeSelf)
                {
                    int score = 0;
                    if (gameTime < 10f)
                    {
                        score = 3;
                    }
                    else if (gameTime < 20f)
                    {
                        score = 2;
                    }
                    else if (gameTime < 30f)
                    {
                        score = 1;
                    }

                    GameManager.Scripts.GameManager.SubmitScore(GameManager.Scripts.GameManager.Puzzle.Optometry,
                        score);
                    GameManager.Scripts.GameManager.LoadNewScene("Optom_End", "OptometryPuzzle");
                }
            }
        }
    }
}