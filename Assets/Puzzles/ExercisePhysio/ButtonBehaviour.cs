using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBehaviour : MonoBehaviour
{
    private GameObject[] btnList; // Array of buttons on the screen
    private string[] colourNamArr = {"Red", "Yellow", "Green", "Blue", "Magenta", "White"}; // Array of the all the colour choices
    private Text targetText; // Target colour UI Text component
    private Text uiCounter; // UI Counter

    private string target; // Target Colour as String
    private int counter; // Counter as int
    private bool bikeIsClear = false;

    //Getting Color Sprites
    public Sprite Red;
    public Sprite Yellow;
    public Sprite Green;
    public Sprite Blue;
    public Sprite Magenta;
    public Sprite White;

    //private Font Munro;

    private CyclingBehaviourScript cyclingScrt;
    

    // Start is called before the first frame update
    void Start()
    {
        // Getting Buttons with tag 'btn'
        btnList = GameObject.FindGameObjectsWithTag("btn");
        // Getting targetText component
        targetText = GameObject.Find("TargetText").GetComponent<Text>();
        // Getting counter UI text
        uiCounter = GameObject.Find("UICounter").GetComponent<Text>();

        cyclingScrt = GameObject.Find("CyclingBehaviour").GetComponent<CyclingBehaviourScript>();

        // Updating Screen
        UpdateScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetTarget() {
        int x = Random.Range(0, btnList.Length);
        target = colourNamArr[x];
        Debug.Log("Target is " + target);
        targetText.text = ("Choose the " + target + " button");

    }

    void UpdateScreen() {

        for (int i = 0; i < btnList.Length; i++)
        {
            //colourNamArr[i].font = Munro;
            btnList[i].GetComponentInChildren<Text>().text = colourNamArr[i];
        }

        Shuffle(btnList);
        SetTarget();

        Debug.Log("Before Shuffle clname:" + colourNamArr[0] + ", btn: " + btnList[0]);
        
        ShuffleString(colourNamArr);

        Debug.Log("After Shuffle clname:" + colourNamArr[0] + ", btn: " + btnList[0]);


        for (int i = 0; i < btnList.Length; i++) {
            
            btnList[i].GetComponentInChildren<Text>().text = colourNamArr[i];
            int x = Random.Range(0, btnList.Length);

            if (colourNamArr[i].Equals(Red))
            {
                // Change this line when loading in new sprite instead
                btnList[i].GetComponent<Image>().sprite = Red;
            }
            else if (colourNamArr[i].Equals(Yellow)) {
                btnList[i].GetComponent<Image>().sprite = Yellow;
            }
            else if (colourNamArr[i].Equals(Green))
            {
                btnList[i].GetComponent<Image>().sprite = Green;
            }
            else if (colourNamArr[i].Equals(Blue))
            {
                btnList[i].GetComponent<Image>().sprite = Blue;
            }
            else if (colourNamArr[i].Equals(Magenta))
            {
                btnList[i].GetComponent<Image>().sprite = Magenta;
            }
            else if (colourNamArr[i].Equals(White))
            {
                btnList[i].GetComponent<Image>().sprite = White;
            }
        }    
    }

    // Knuth shuffle algorithm
    void Shuffle(GameObject[] objects) {
        for (int i = 0; i < objects.Length; i++) {
            GameObject tmp = objects[i];
            int r = Random.Range(i, objects.Length);
            objects[i] = objects[r];
            objects[r] = tmp;
        }    
    }


    void ShuffleString(string[] str) {
        var rand = new System.Random();

        for (int i = 0; i < str.Length; i++)
        {
            string tmp = str[i];
            int r = Random.Range(i, str.Length);
            str[i] = str[r];
            str[r] = tmp;
        }
    }

    public void OnClick(Button button) {
        Debug.Log("Button name is " + button.GetComponentInChildren<Text>().text);

        if (button.GetComponentInChildren<Text>().text.Equals(target) && bikeIsClear) {
            counter++;
            UpdateScreen();
            uiCounter.text = "" + counter;
        }
    }

    public void SetBike(bool set) {
        bikeIsClear = set;
    }

    // Might use for clicking the arrow keys instead
    public void ArrowOnclick(Button button)
    {
        Debug.Log("Button name is " + button.GetComponentInChildren<Text>().text);
        cyclingScrt.ArrowClick(button.GetComponentInChildren<Text>().text);
    }
}
