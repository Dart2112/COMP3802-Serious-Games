using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class EndScene : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int score; // Score to be returned
                int result = GameManager.Scripts.GameManager.GetPhysioCount(); // Number of retrys

                if (result == 0)
                {
                    score = 3;
                }
                else if (result == 1)
                {
                    score = 2;
                }
                else
                {
                    score = 1;
                }

                GameManager.Scripts.GameManager.SubmitScore(GameManager.Scripts.GameManager.Puzzle.PhysioTherapy,
                    score);
                GameManager.Scripts.GameManager.LoadNewScene("Physio_End", "PhysioTherapyPuzzle");
            }
        }
    }
}