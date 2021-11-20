using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Puzzles.ExercisePhysio
{
    public class CyclingBehaviourScript : MonoBehaviour
    {
        [Tooltip("Wait time between keystrokes")]
        public float time; // delay time
        int _pos; // next button position
        private ButtonBehaviour _btnScript; // ButtonBehaviour Script
        private Button _up; // Up arrow button
        private Button _down; // Down arrow button
        private Button _left; // Left arrow button
        private Button _right; // Right arrow button

        private bool _upIsClicked;
        private bool _downIsClicked;
        private bool _leftIsClicked;
        private bool _rightIsClicked;

        [FormerlySerializedAs("down_arrow")] public Sprite downArrow;
        //public Sprite down_arrow_highlight;
        [FormerlySerializedAs("up_arrow")] public Sprite upArrow;
        //public Sprite up_arrow_highlight;
        [FormerlySerializedAs("left_arrow")] public Sprite leftArrow;
        //public Sprite left_arrow_highlight;
        [FormerlySerializedAs("right_arrow")] public Sprite rightArrow;
        //public Sprite right_arrow_highlight;

        public GameObject frame0;
        public GameObject frame1;
        public GameObject frame2;

        private GameObject[] _animationArray = new GameObject[3];


        private int _frameIndex;

        // Start is called before the first frame update
        void Start()
        {
            // Getting scene objects
            _btnScript = GameObject.Find("ButtonBehaviour").GetComponent<ButtonBehaviour>();
            _up = GameObject.Find("Up").GetComponent<Button>();
            _down = GameObject.Find("Down").GetComponent<Button>();
            _left = GameObject.Find("Left").GetComponent<Button>();
            _right = GameObject.Find("Right").GetComponent<Button>();

            //Adding frames
            _animationArray[0] = frame0;
            _animationArray[1] = frame1;
            _animationArray[2] = frame2;

            _animationArray[_frameIndex].SetActive(true);

            // Setting the intial colour
            SetColourYellow(_up);

            Debug.Log("Animation array size " + _animationArray.Length);
        }

        // Update is called once per frame
        void Update()
        {
            time -= Time.deltaTime;
            if (!_btnScript.IsFinished()) {
                if ((Input.GetKey(KeyCode.UpArrow) && _pos == 0) || (_upIsClicked && _pos == 0))
                {
                    Debug.Log("Up arrow pressed");
                    _pos = 1;
                    // Setting time to 2 seconds delay
                    time = 2;
                    _btnScript.SetBike(true);
                    SetColourDefault(_up);
                    SetColourYellow(_right);

                    NextFrame();

                    /*frameIndex++;
                if (frameIndex == numberOfFrames)
                {
                    frameIndex = 0;
                }*/

                    // For mouse/touch controls
                    _upIsClicked = false;
                }
                else if ((Input.GetKey(KeyCode.RightArrow) && _pos == 1) || (_rightIsClicked && _pos == 1))
                {
                    Debug.Log("Right arrow pressed");
                    _pos = 2;
                    // Setting time to 2 seconds delay
                    time = 2;
                    _btnScript.SetBike(true);
                    SetColourDefault(_right);
                    SetColourYellow(_down);
                    // Update animation
                    NextFrame();
                    // For mouse/touch controls
                    _rightIsClicked = false;
                }
                else if ((Input.GetKey(KeyCode.DownArrow) && _pos == 2) || (_downIsClicked && _pos == 2))
                {
                    Debug.Log("Down arrow pressed");
                    _pos = 3;
                    // Setting time to 2 seconds delay
                    time = 2;
                    _btnScript.SetBike(true);
                    SetColourDefault(_down);
                    SetColourYellow(_left);
                    // Update animation
                    NextFrame();
                    // For mouse/touch controls
                    _downIsClicked = false;
                }
                else if ((Input.GetKey(KeyCode.LeftArrow) && _pos == 3) || (_leftIsClicked && _pos == 3))
                {
                    Debug.Log("Left arrow pressed");
                    _pos = 0;
                    // Setting time to 2 seconds delay
                    time = 2;
                    _btnScript.SetBike(true);
                    SetColourDefault(_left);
                    SetColourYellow(_up);
                    // Update animation
                    NextFrame();
                    // For mouse/touch controls
                    _leftIsClicked = false;
                }
                else if (time < 0)
                {
                    _btnScript.SetBike(false);
                }
            }
        
        }

        void NextFrame() {
            // Making previous frame invisible
            _animationArray[_frameIndex].SetActive(false);

            // Getting next frame and setting active
            //frameIndex = (frameIndex + 1) % animationArray.Length;

            _frameIndex++;
            if (_frameIndex == _animationArray.Length)
            {
                _frameIndex = 0;
            }

            Debug.Log("Frame index " + _frameIndex + " array size " + _animationArray.Length);
            _animationArray[_frameIndex].SetActive(true);
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
                _upIsClicked = true;
            }
            else if (btn.Equals("Down"))
            {
                _downIsClicked = true;
            }
            else if (btn.Equals("Left"))
            {
                _leftIsClicked = true;
            }
            else if (btn.Equals("Right"))
            {
                _rightIsClicked = true;
            }
        }
    }
}
