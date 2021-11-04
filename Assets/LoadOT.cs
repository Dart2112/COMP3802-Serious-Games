using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOT : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadOTPuzzle()
    {
        GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "notebook better");
    }
}
