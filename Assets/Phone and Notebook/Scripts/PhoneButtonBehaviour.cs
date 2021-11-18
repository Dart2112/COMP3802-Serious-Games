using UnityEngine;

namespace Phone_and_Notebook.Scripts
{
    public class PhoneButtonBehaviour : MonoBehaviour
    {
        public void LoadPhysioPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("Physio_Start", "Intro_End");
        }

        public void LoadOptomPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("Optom_Start", "Intro_End");
        }

        public void LoadOtPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("OT_Start", "Intro_End");
        }

        public void LoadExercisePhysioPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("EP_Start", "Intro_End");
        }
    }
}