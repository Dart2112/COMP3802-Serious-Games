using UnityEngine;

namespace Phone_and_Notebook.Scripts
{
    public class PhoneButtonBehaviour : MonoBehaviour
    {
        public void LoadPhysioEntrance() {
            GameManager.Scripts.GameManager.LoadNewScene("Physiotherapist_Start", "Intro_End");
        }

        public void LoadPhysioTherapyPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "Physiotherapist_Start");
        }

        public void LoadOTPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("OT_Start", "Intro_End");
        }
    
    }
}
