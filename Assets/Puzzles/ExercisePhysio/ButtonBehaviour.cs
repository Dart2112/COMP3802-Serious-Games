using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBehaviour : MonoBehaviour
{
    private GameObject[] btnList; // Array of buttons on the screen
    private string[] colourNamArr = { "Red", "Yellow", "Green", "Blue", "Magenta", "White" }; // Array of the all the colour choices
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
    private int _goal = 10;
    private int score = 0;

    //public GameObject startScreen; // Start screen
    public GameObject endScreen; // End Screen

    public float currentTime; // Current time in the scene;

    private bool _finished = false; // Is the puzzle finished

    public Text cTimeText;

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

        cTimeText = GameObject.Find("CurrentTime").GetComponent<Text>();

        // Updating Screen
        UpdateScreen();
    }

    // Update is called once per frame
    void Update()
    {
        // Updating time (stopwatch) Currently is running even when start screen has been closed.
        currentTime += Time.deltaTime;
        if (!_finished) {
            cTimeText.text = ("" + (int)currentTime);
        }
        
    }

    void SetTarget() {
        int x = Random.Range(0, btnList.Length);
        target = colourNamArr[x];
        Debug.Log("Target is " + target);
        targetText.text = ("Click the button with " + target + " text");

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

            /*btnList[i].GetComponentInChildren<Text>().text = colourNamArr[i];
            int x = Random.Range(0, btnList.Length);*/

            if (colourNamArr[i].Equals("Red"))
            {
                // Change this line when loading in new sprite instead
                btnList[i].GetComponent<Image>().sprite = Red;
                Debug.Log("assigning to red");
            }
            else if (colourNamArr[i].Equals("Yellow")) {
                btnList[i].GetComponent<Image>().sprite = Yellow;
            }
            else if (colourNamArr[i].Equals("Green"))
            {
                btnList[i].GetComponent<Image>().sprite = Green;
            }
            else if (colourNamArr[i].Equals("Blue"))
            {
                btnList[i].GetComponent<Image>().sprite = Blue;
            }
            else if (colourNamArr[i].Equals("Magenta"))
            {
                btnList[i].GetComponent<Image>().sprite = Magenta;
            }
            else if (colourNamArr[i].Equals("White"))
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
        if (button.GetComponentInChildren<Text>().text.Equals(target) && bikeIsClear && !_finished)
        {
            counter++;
            UpdateScreen();
            uiCounter.text = "" + counter;

            if (counter == _goal) {
                
                // Get final time
                endScreen.SetActive(true);

                if (currentTime < 30f)
                {
                    score = 3;
                }
                else if (currentTime < 60f)
                {
                    score = 2;
                }
                else {
                    score = 1;
                }

                _finished = true;
                // Pushing score
                //GameManager.Scripts.GameManager.SubmitScore(GameManager.Scripts.GameManager.Puzzle.ExercisePhysio, this.score);
            }
        }
    }

    public bool isFinished() {
        return _finished;
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
