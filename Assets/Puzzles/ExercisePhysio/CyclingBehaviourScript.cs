using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CyclingBehaviourScript : MonoBehaviour
{
    [Tooltip("Wait time between keystrokes")]
    public float time; // delay time
    int pos = 0; // next button position
    private ButtonBehaviour _btnScript; // ButtonBehaviour Script
    private Button _up; // Up arrow button
    private Button _down; // Down arrow button
    private Button _left; // Left arrow button
    private Button _right; // Right arrow button

    private bool upIsClicked = false;
    private bool downIsClicked = false;
    private bool leftIsClicked = false;
    private bool rightIsClicked = false;

    public Sprite down_arrow;
    public Sprite down_arrow_highlight;
    public Sprite up_arrow;
    public Sprite up_arrow_highlight;
    public Sprite left_arrow;
    public Sprite left_arrow_highlight;
    public Sprite right_arrow;
    public Sprite right_arrow_highlight;

    // Start is called before the first frame update
    void Start()
    {
        // Getting scene objects
        _btnScript = GameObject.Find("ButtonBehaviour").GetComponent<ButtonBehaviour>();
        _up = GameObject.Find("Up").GetComponent<Button>();
        _down = GameObject.Find("Down").GetComponent<Button>();
        _left = GameObject.Find("Left").GetComponent<Button>();
        _right = GameObject.Find("Right").GetComponent<Button>();

        // Setting the intial colour
        SetColourYellow(_up);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if ((Input.GetKey(KeyCode.UpArrow) && pos == 0) || (upIsClicked && pos == 0))
        {
            Debug.Log("Up arrow pressed");
            pos = 1;
            // Setting time to 2 seconds delay
            time = 2;
            _btnScript.SetBike(true);
            SetColourDefault(_up);
            SetColourYellow(_right);
            // Update animation

            // For mouse/touch controls
            upIsClicked = false;
        }
        else if ((Input.GetKey(KeyCode.RightArrow) && pos == 1) || (rightIsClicked && pos == 1))
        {
            Debug.Log("Right arrow pressed");
            pos = 2;
            // Setting time to 2 seconds delay
            time = 2;
            _btnScript.SetBike(true);
            SetColourDefault(_right);
            SetColourYellow(_down);
            // Update animation

            // For mouse/touch controls
            rightIsClicked = false;
        }
        else if ((Input.GetKey(KeyCode.DownArrow) && pos == 2) || (downIsClicked && pos == 2))
        {
            Debug.Log("Down arrow pressed");
            pos = 3;
            // Setting time to 2 seconds delay
            time = 2;
            _btnScript.SetBike(true);
            SetColourDefault(_down);
            SetColourYellow(_left);
            // Update animation

            // For mouse/touch controls
            downIsClicked = false;
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) && pos == 3) || (leftIsClicked && pos == 3))
        {
            Debug.Log("Left arrow pressed");
            pos = 0;
            // Setting time to 2 seconds delay
            time = 2;
            _btnScript.SetBike(true);
            SetColourDefault(_left);
            SetColourYellow(_up);
            // Update animation

            // For mouse/touch controls
            leftIsClicked = false;
        }
        else if (time < 0)
        {
            _btnScript.SetBike(false);
        }
    }

    void SetColourYellow(Button button)
    {
        // Could replace button sprite instead
        button.GetComponent<Image>().color = Color.yellow;
    }

    void SetColourDefault(Button button)
    {
        // Could replace button sprite instead
        button.GetComponent<Image>().color = Color.white;
    }

    public void ArrowClick(string btn)
    {
        Debug.Log("Arrow click string is " + btn);
        Debug.Log("Statement  " + btn.Equals("Right"));


        if (btn.Equals("Up"))
        {
            Debug.Log("Is clicked is true");
            upIsClicked = true;
        }
        else if (btn.Equals("Down"))
        {
            downIsClicked = true;
        }
        else if (btn.Equals("Left"))
        {
            leftIsClicked = true;
        }
        else if (btn.Equals("Right"))
        {
            rightIsClicked = true;
        }
    }
}
