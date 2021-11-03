using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class ButtonBehaviour : MonoBehaviour
    {
        public void Continue() {
            // Score to be pushed
            int score;
            // Number of retrys
            int result = GameManager.Scripts.GameManager.getPhysioCount();

            if (result == 0)
            {
                score = 3;
            }
            else if (result == 1)
            {
                score = 2;
            }
            else {
                score = 1;
            }

            // Pushing puzzle score
            GameManager.Scripts.GameManager.SubmitScore(GameManager.Scripts.GameManager.Puzzle.PhysioTherapy, score);
            // Loading OT puzzle
            GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "PhysioTherapyPuzzle");
        }

        public void Restart() {
            // Iterating physio loop number
            GameManager.Scripts.GameManager.PhysioIterate();
            // Reloading the scene
            GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
        }

        public void Quit() {
            // Quitting to main menu
            GameManager.Scripts.GameManager.LoadNewScene("MainMenus", "PhysioTherapyPuzzle");
        }
    }
}