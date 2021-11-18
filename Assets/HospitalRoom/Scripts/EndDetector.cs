using System;
using UnityEngine;

namespace HospitalRoom.Scripts
{
    public class EndDetector : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            foreach (GameManager.Scripts.GameManager.Puzzle puzzle in Enum.GetValues(
                typeof(GameManager.Scripts.GameManager.Puzzle)))
            {
                int score = PlayerPrefs.GetInt(puzzle + ".score", -1);
                if (score == -1)
                {
                    //A game hasn't been done yet so we let the player keep going
                    Debug.Log(puzzle + " puzzle is incomplete, not triggering end state");
                    return;
                }
            }

            //This point in code being reached means all puzzles have scores logged
            Debug.Log("End state reached");
            GameManager.Scripts.GameManager.LoadNewScene("Ending", "Intro_End");
        }
    }
}