using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class ButtonBehaviour : MonoBehaviour
    {
        public void Continue()
        {
            int score; // Score to be returned
            int result = GameManager.Scripts.GameManager.getPhysioCount(); // Number of retrys

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

            GameManager.Scripts.GameManager.SubmitScore(GameManager.Scripts.GameManager.Puzzle.PhysioTherapy, score);
            //GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
            GameManager.Scripts.GameManager.LoadNewScene("Physio_End", "PhysioTherapyPuzzle");
        }

        public void Restart()
        {
            //Debug.Log("Running Restart");
            GameManager.Scripts.GameManager.PhysioIterate();
            // Will need to be modified
            //UnityEngine.SceneManagement.SceneManager.LoadScene("PhysioTherapyPuzzle");
            //GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
            //GameObject.Find("UIBehaviour").GetComponent<UIBehaviour>().unPause();
            GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
        }

        public void Quit()
        {
            GameManager.Scripts.GameManager.LoadNewScene("Physio_End", "PhysioTherapyPuzzle");
        }
    }
}