using System;
using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class RestartControl : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Running Restart");
                GameManager.Scripts.GameManager.PhysioIterate();
                GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "PhysioTherapyPuzzle");
            }
        }
    }
}
