using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Puzzles.ExercisePhysio
{
    public class ButtonBehaviour : MonoBehaviour
    {
        private GameObject[] _btnList; // Array of buttons on the screen

        private string[]
            _colourNamArr =
                {"Red", "Yellow", "Green", "Blue", "Magenta", "White"}; // Array of the all the colour choices

        private Text _targetText; // Target colour UI Text component
        private Text _uiCounter; // UI Counter

        private string _target; // Target Colour as String
        private int _counter; // Counter as int
        private bool _bikeIsClear;

        //Getting Color Sprites
        [FormerlySerializedAs("Red")] public Sprite red;
        [FormerlySerializedAs("Yellow")] public Sprite yellow;
        [FormerlySerializedAs("Green")] public Sprite green;
        [FormerlySerializedAs("Blue")] public Sprite blue;
        [FormerlySerializedAs("Magenta")] public Sprite magenta;
        [FormerlySerializedAs("White")] public Sprite white;

        //private Font Munro;

        private CyclingBehaviourScript _cyclingScrt;
        private int _goal = 10;
        private int _score;

        //public GameObject startScreen; // Start screen
        public GameObject endScreen; // End Screen
        public Text endText;

        public float currentTime; // Current time in the scene;

        private bool _finished; // Is the puzzle finished

        public Text cTimeText;

        // Start is called before the first frame update
        void Start()
        {
            // Getting Buttons with tag 'btn'
            _btnList = GameObject.FindGameObjectsWithTag("btn");
            // Getting targetText component
            _targetText = GameObject.Find("TargetText").GetComponent<Text>();
            // Getting counter UI text
            _uiCounter = GameObject.Find("UICounter").GetComponent<Text>();

            _cyclingScrt = GameObject.Find("CyclingBehaviour").GetComponent<CyclingBehaviourScript>();

            cTimeText = GameObject.Find("CurrentTime").GetComponent<Text>();

            // Updating Screen
            UpdateScreen();
        }

        // Update is called once per frame
        void Update()
        {
            // Updating time (stopwatch) Currently is running even when start screen has been closed.
            currentTime += Time.deltaTime;
            if (!_finished)
            {
                cTimeText.text = ("" + (int) currentTime);
            }
        }

        void SetTarget()
        {
            int x = Random.Range(0, _btnList.Length);
            _target = _colourNamArr[x];
            Debug.Log("Target is " + _target);
            _targetText.text = ("Click the button with " + _target + " text");
        }

        void UpdateScreen()
        {
            for (int i = 0; i < _btnList.Length; i++)
            {
                //colourNamArr[i].font = Munro;
                _btnList[i].GetComponentInChildren<Text>().text = _colourNamArr[i];
            }

            Shuffle(_btnList);
            SetTarget();

            Debug.Log("Before Shuffle clname:" + _colourNamArr[0] + ", btn: " + _btnList[0]);

            ShuffleString(_colourNamArr);

            Debug.Log("After Shuffle clname:" + _colourNamArr[0] + ", btn: " + _btnList[0]);


            for (int i = 0; i < _btnList.Length; i++)
            {
                /*btnList[i].GetComponentInChildren<Text>().text = colourNamArr[i];
            int x = Random.Range(0, btnList.Length);*/

                if (_colourNamArr[i].Equals("Red"))
                {
                    // Change this line when loading in new sprite instead
                    _btnList[i].GetComponent<Image>().sprite = red;
                    Debug.Log("assigning to red");
                }
                else if (_colourNamArr[i].Equals("Yellow"))
                {
                    _btnList[i].GetComponent<Image>().sprite = yellow;
                }
                else if (_colourNamArr[i].Equals("Green"))
                {
                    _btnList[i].GetComponent<Image>().sprite = green;
                }
                else if (_colourNamArr[i].Equals("Blue"))
                {
                    _btnList[i].GetComponent<Image>().sprite = blue;
                }
                else if (_colourNamArr[i].Equals("Magenta"))
                {
                    _btnList[i].GetComponent<Image>().sprite = magenta;
                }
                else if (_colourNamArr[i].Equals("White"))
                {
                    _btnList[i].GetComponent<Image>().sprite = white;
                }
            }
        }

        // Knuth shuffle algorithm
        void Shuffle(GameObject[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                GameObject tmp = objects[i];
                int r = Random.Range(i, objects.Length);
                objects[i] = objects[r];
                objects[r] = tmp;
            }
        }


        void ShuffleString(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                string tmp = str[i];
                int r = Random.Range(i, str.Length);
                str[i] = str[r];
                str[r] = tmp;
            }
        }

        public void OnClick(Button button)
        {
            Debug.Log("Button name is " + button.GetComponentInChildren<Text>().text);
            if (button.GetComponentInChildren<Text>().text.Equals(_target) && _bikeIsClear && !_finished)
            {
                _counter++;
                UpdateScreen();
                _uiCounter.text = "" + _counter;

                if (_counter == _goal)
                {
                    // Get final time
                    endScreen.SetActive(true);
                    endText.text = "Well Done You Took " + currentTime + " seconds. Press [Space] to continue.";

                    if (currentTime < 30f)
                    {
                        _score = 3;
                    }
                    else if (currentTime < 60f)
                    {
                        _score = 2;
                    }
                    else
                    {
                        _score = 1;
                    }

                    _finished = true;
                    // Pushing score
                    GameManager.Scripts.GameManager.SubmitScore(GameManager.Scripts.GameManager.Puzzle.ExercisePhysio,
                        _score);
                }
            }
        }

        public bool IsFinished()
        {
            return _finished;
        }

        public void SetBike(bool set)
        {
            _bikeIsClear = set;
        }

        // Might use for clicking the arrow keys instead
        public void ArrowOnclick(Button button)
        {
            Debug.Log("Button name is " + button.GetComponentInChildren<Text>().text);
            _cyclingScrt.ArrowClick(button.GetComponentInChildren<Text>().text);
        }
    }
}