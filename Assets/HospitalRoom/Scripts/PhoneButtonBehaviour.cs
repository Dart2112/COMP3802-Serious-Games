using UnityEngine;

namespace HospitalRoom.Scripts
{
    public class PhoneButtonBehaviour : MonoBehaviour
    {

        public void LoadPhysioTherapyPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "Into_End");
        }

        public void LoadOTPuzzle()
        {
            GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "Into_End");
        }
    
    }
}
