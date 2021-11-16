using UnityEngine;

namespace Phone_and_Notebook.Scripts
{
    public class PhoneButtonBehaviour : MonoBehaviour
    {
        public void LoadPhysioEntrance()
        {
            GameManager.Scripts.GameManager.LoadNewScene("Physio_Start", "Intro_End");
        }

        public void LoadOptomPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("Optom_Start", "Intro_End");
        }

        public void LoadOTPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("OT_Start", "Intro_End");
        }
    }
}