using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject greetScreen;
    public GameObject mainMenu;
    public GameObject playScene;
    public GameObject noteBook;
    public GameObject settings;

    // Start is called before the first frame update
    void Start()
    {
        greetScreen.SetActive(true);
        mainMenu.SetActive(false);
        settings.SetActive(false);
    }


    public void OpenMainMenu() {
        greetScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void CloseMainMenu() {
        mainMenu.SetActive(false);
        greetScreen.SetActive(true);
    }
    
    public void OpenSettingsMenu() {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void CloseSettingsMenu() {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void StartOTPuzzle()
    {
        GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "MainMenus");
    }

    public void StartPhysioPuzzle() {
        GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "MainMenus");
    }
}
