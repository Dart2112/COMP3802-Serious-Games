using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class UIBehaviour : MonoBehaviour
    {
        public Text count; // Current count of stacked blocks text field
        public Text fails; // Current count of failures text field
        private int _blockCounter; // Count of stacked blocks
        private int _failCounter; // Count of failures    
        public int goal = 9; // Block count goal
        private int _max = 3; // Fail Limit
        private bool _failed = false;

        [Tooltip("End Menu UI Screen")] public GameObject endMenu;

        [Tooltip("Fail menu UI screen")] public GameObject failMenu;

        private Transform _startPos; // Starting position of the blocks
        private Transform _camPos; // Camera Position

        private Vector3 _camStartPos; // Camera Starting Position
        private float _blockCamDifference; // Measures the distance between the startpos and camera centre.

        private float
            _colliderCamDifference; // Measures the distance between the left/right collider and camera centre. 

        [Tooltip("Left collider")] public GameObject leftCollider;
        [Tooltip("Right Collider")] public GameObject rightCollider;

        [Tooltip("Direction of the block")] public int direction;

        [Tooltip("Block Horizontal MoveSpeed")]
        public float moveSpeed = 0.02f;

        [Tooltip("Starting wait between fails time")]
        public float currentTime;

        public GameObject endText;
        public GameObject failText;

        [Tooltip("EndTime Timer")] public float endTime; // End timer for when goal is reached.
        private bool _wait; // Are we still waiting until fail number can be updated.
        private bool _ending; // Are we greater than the goal counter.
        private bool _ended; // Game has ended

        private GameObject[] _blockList; // List of all blocks currently on the screen. Used to determine block number.

        private GameObject _currentObject; // Currently selected object under player control

        [Tooltip("End Timer GameObject UI")] public GameObject endCountDown;

        [Tooltip("End Timer UI circle")] public GameObject countDownCircle;

        private AudioSource _success;
        private AudioSource _fail;
        private AudioSource _totalFailure;
        private AudioSource _complete;


        // Start is called before the first frame update
        void Start()
        {
            //currentTime = 2;
            _wait = false;
            _ending = false;
            _ended = false;

            // Getting main camera and its starting position
            _camPos = GameObject.Find("PhysioMainCamera").transform;
            _startPos = GameObject.Find("StartPos").transform;
            _camStartPos = _camPos.position;
            count.text = _blockCounter + " / " + goal;


            // Getting the starting difference between the camera and other objects
            _blockCamDifference = _startPos.position.y - _camPos.position.y;
            _colliderCamDifference = leftCollider.transform.position.y - _camPos.position.y;

            // Getting Effect Sounds
            _success = GameObject.Find("Success").GetComponent<AudioSource>();
            _fail = GameObject.Find("Fail").GetComponent<AudioSource>();
            _complete = GameObject.Find("Complete").GetComponent<AudioSource>();
            _complete = GameObject.Find("Complete").GetComponent<AudioSource>();
            _totalFailure = GameObject.Find("TotalFailure").GetComponent<AudioSource>();
        }

        void Update()
        {
            if (!_failed) // Stops block from falling if failed
            {
                // Updating end and current times
                currentTime -= Time.deltaTime;
                endTime -= Time.deltaTime;

                UpdateBlockCounter();

                // If end goal has been reached and end wait time has been completed
                if (_blockCounter >= goal && endTime < 0)
                {
                    //Time.timeScale = 0;

                    direction = 0;
                    endCountDown.SetActive(false);
                    countDownCircle.SetActive(false);
                    endMenu.SetActive(true);

                    if (!_ended)
                    {
                        _ended = true;
                        _complete.Play();
                        removeRigidBody();
                    }
                }
            }
            else removeRigidBody();

        }

        void FixedUpdate()
        {
            AdjustItemPositions();
        }

        // Updates when block collides with another block, sets end timer when goal is reached. Differs from UpdateBlockCounter by playing success sound and sets ending
        public void UpdateBlockNo()
        {
            _blockCounter += 1;
            count.text = _blockCounter + " / " + goal;
            _success.Play();
            if (_blockCounter == goal && !_ending)
            {
                // Wait 4 seconds before ending
                _ending = true;
                endTime = 4;
            }
        }

        // Updates the fail UI when blocks hit the floor
        public void UpdateFail()
        {
            // Checking current state of wait if waiting
            if (_wait)
            {
                if (currentTime < 0)
                {
                    _wait = false;
                    Debug.Log("wait is false");
                }
            }

            if (!_wait)
            {
                _wait = true;
                currentTime = 2;
                _failCounter += 1;

                Debug.Log("Updating Fail");
            }

            fails.text = _failCounter + " / " + _max;

            if (_failCounter == _max)
            {
                SetDirection(0);
                _failed = true;
                if (GameManager.Scripts.GameManager.GetPhysioCount() == 2)
                {
                    //Has failed 3 times now, so we show the complete menu instead of fail
                    endMenu.SetActive(true);
                    endText.SetActive(false);
                    failText.SetActive(true);
                }
                else
                {
                    failMenu.SetActive(true);
                }

                _totalFailure.Play();
                removeRigidBody();
            }
            else _fail.Play();
        }

        // Refreshing block counter by finding all gameobjects with tag 'Block'
        private void UpdateBlockCounter()
        {
            _blockList = GameObject.FindGameObjectsWithTag("Block");
            _blockCounter = _blockList.Length - 1;
            if (_blockCounter < 0)
            {
                _blockCounter = 0;
            }

            if (_blockCounter >= goal)
            {
                // set the screen as active
                endCountDown.SetActive(true);
                countDownCircle.SetActive(true);
                endCountDown.GetComponent<Text>().text = ((int)endTime).ToString(); // Converting to string and rounding
            }
            else
            {
                endCountDown.SetActive(false);
                countDownCircle.SetActive(false);
                _ending = false;
            }

            count.text = _blockCounter + " / " + goal;
        }

        // Adjusting the cam pos, start pos and block collider positions
        public void AdjustItemPositions()
        {
            // Increase scales to the number of blocks found on the screen
            float increase = _blockCounter * 1f;

            // Adjusting Camera
            _camPos.position = _camStartPos + new Vector3(0, increase, -10f);

            // Adjusting Collider and block startpos positions in scene
            _startPos.position =
                new Vector3(_startPos.position.x, _camPos.position.y + _blockCamDifference, _startPos.position.z);
            leftCollider.transform.position = new Vector3(leftCollider.transform.position.x,
                _camPos.position.y + _colliderCamDifference, 0);
            rightCollider.transform.position = new Vector3(rightCollider.transform.position.x,
                _camPos.position.y + _colliderCamDifference, 0);

            // Adjusting the current object position in scene
            if (_currentObject != null)
            {
                if (direction != 0)
                {
                    _currentObject.transform.position =
                        new Vector3(_currentObject.transform.position.x + direction * moveSpeed,
                            _camPos.position.y + _blockCamDifference, 0);
                }
            }
        }

        // Sets the new current object name and initial direction
        public void SetCurrentObjectName(GameObject obj)
        {
            if (_failCounter != _max)
            {
                _currentObject = obj;
                SetDirection(1);
            }
            else SetDirection(0);
        }

        // Sets block transform direction
        public void SetDirection(int i)
        {
            Debug.Log("setting Direction to " + i);
            direction = i;
        }

        public void removeRigidBody()
        {
            _blockList = GameObject.FindGameObjectsWithTag("Block");
            Debug.Log("removing rb from " + _blockList.Length);
            for (int i = 0; i < _blockList.Length; i++)
            {
                Rigidbody2D rb = _blockList[i].GetComponent<Rigidbody2D>();
                Destroy(rb);
            }
        }
    }
}