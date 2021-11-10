using UnityEngine;

namespace HospitalRoom.Scripts
{
    public class PhoneButtonBehaviour : MonoBehaviour
    {
        public void LoadPhysioEntrance() {
            GameManager.Scripts.GameManager.LoadNewScene("Physiotherapist_Start", "Into_End");
        }

        public void LoadPhysioTherapyPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "Physiotherapist_Start");
        }

        public void LoadOTPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "Into_End");
        }
    
    }
}
