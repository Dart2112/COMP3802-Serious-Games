using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonBehaviour : MonoBehaviour
{
    public GameObject phone;
    public GameObject noteBook;
    private bool _allowOpen;
    private string test;

    void Start() {
        noteBook.SetActive(false);
        phone.SetActive(false);
        _allowOpen = false;
    }

    public void OpenPhone()
    {
        if (_allowOpen) { 
        Debug.Log("openphone");
        phone.SetActive(true);
        }        
    }

    public void OpenNotebook()
    {
        if (_allowOpen)
        {
        Debug.Log("opennotebook");
        noteBook.SetActive(true);
        }
        
    }

    public void CloseNotebook() {
        Debug.Log("closing notebook");
        noteBook.SetActive(false);
    }

    public void ClosePhone() {
        Debug.Log("closing phone");
        phone.SetActive(false);
    }

    public void AllowOpen() {
        _allowOpen = true;
    }

    public void LoadPhysioEntrance()
    {
        test = GameManager.Scripts.GameManager.getCurrentScene();
        Debug.Log("test is " + test);
        GameManager.Scripts.GameManager.LoadNewScene("Physiotherapist_Start", test);
    }

    public void LoadPhysioTherapyPuzzle()
    {
        test = GameManager.Scripts.GameManager.getCurrentScene();
        GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", test);
    }

/*    public void LoadOTEntrance()
    {
        GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "Into_End");
    }*/

    public void LoadOTPuzzle()
    {
        test = GameManager.Scripts.GameManager.getCurrentScene();
        GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", test);
    }
}
