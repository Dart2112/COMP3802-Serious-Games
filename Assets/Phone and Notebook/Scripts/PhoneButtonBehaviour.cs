using UnityEngine;

namespace Phone_and_Notebook.Scripts
{
    public class PhoneButtonBehaviour : MonoBehaviour
    {
        public GameObject physio, ot, optom, exercise;

        public void Start()
        {
            //TODO: Check the status of games completion and update the phone buttons
            if (GameManager.Scripts.GameManager.RetrieveScore(GameManager.Scripts.GameManager.Puzzle.PhysioTherapy) !=
                -1)
            {
                //Show physio as not available
                physio.SetActive(true);
            }

            if (GameManager.Scripts.GameManager.RetrieveScore(
                    GameManager.Scripts.GameManager.Puzzle.OccupationalTherapy) !=
                -1)
            {
                //Show ot as not available
                ot.SetActive(true);
            }

            if (GameManager.Scripts.GameManager.RetrieveScore(
                    GameManager.Scripts.GameManager.Puzzle.Optometry) !=
                -1)
            {
                //Show optom as not available
                optom.SetActive(true);
            }

            //Show EP as not available, not complete so no if statement
            exercise.SetActive(true);
        }

        public void LoadPhysioPuzzle()
        {
            if (physio.activeSelf)
                return;
            GameManager.Scripts.GameManager.LoadNewScene("Physio_Start", "Intro_End");
        }

        public void LoadOtPuzzle()
        {
            if (ot.activeSelf)
                return;
            GameManager.Scripts.GameManager.LoadNewScene("OT_Start", "Intro_End");
        }

        public void LoadOptomPuzzle()
        {
            if (optom.activeSelf)
                return;
            GameManager.Scripts.GameManager.LoadNewScene("Optom_Start", "Intro_End");
        }

        public void LoadExercisePhysioPuzzle()
        {
            //Puzzle not complete, dont launch
            return;
        }
    }
}