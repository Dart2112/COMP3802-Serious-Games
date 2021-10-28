using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Puzzles.OT_Assets.Scripts
{
    public class GameBarBehaviour : MonoBehaviour
    {
        public AnimationPlayer animations;
        public GameObject greenBar, box;
        public float speed = 0.05f;
        public float speedRamp = 0.03f;

        //The prefabs to be spawned when the player hits or misses the target
        public GameObject hitPrefab;
        public GameObject missPrefab;

        public GameObject startPanel, endPanel;

        private int _hits, _misses;

        private int _direction = 1;


        private enum GameState
        {
            Start,
            Playing,
            End
        }

        private GameState _gameState;

        private void Start()
        {
            GameManager.Scripts.GameManager.ToggleItem("MainMenus", false);
            _gameState = GameState.Start;
            startPanel.SetActive(true);
            endPanel.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_gameState == GameState.Start)
                {
                    //Start the game playing
                    _gameState = GameState.Playing;
                    //Hide the startPanel
                    startPanel.SetActive(false);
                    //Move the box to a random spot to start
                    MoveGreenBox();
                }
                else if (_gameState == GameState.Playing)
                {
                    //The player has tried to hit the box
                    //Check if the green bar is in the box
                    bool hit = greenBar.GetComponent<BoxCollider>().bounds
                        .Intersects(box.GetComponent<BoxCollider>().bounds);
                    //Progress if it hit, regress if it didn't
                    if (hit)
                    {
                        Debug.Log("HIT!");
                        //Log the hit for their score
                        _hits++;
                        //Go to the next animation state to progress the game
                        animations.AnimateForward();
                        //Move the green box to a new location on the bar
                        MoveGreenBox();
                        //Increase the speed of the cursor box to make the game more difficult
                        speed += speedRamp;
                        //Spawn the hit prefab to make sure the player knows that they did the right thing
                        Instantiate(hitPrefab);
                    }
                    else
                    {
                        Debug.Log("MISS!");
                        //Log the miss for their score
                        _misses++;
                        //Go to the previous animation state since the player missed
                        animations.AnimateBackward();
                        //Decrease the speed again to where it was
                        speed += -speedRamp;
                        //Spawn the miss prefab to make it clear to the player that they failed to hit the box
                        Instantiate(missPrefab);
                    }
                }
                else if (_gameState == GameState.End)
                {
                    //Return to the main menu
                    GameManager.Scripts.GameManager.ToggleItem("MainMenus", true);
                    GameManager.Scripts.GameManager.UnloadScene("OT Puzzle", "MainMenus");
                }
            }

            // Animate the cursor back and forth, but only if the game is running
            if (_gameState == GameState.Playing)
            {
                //Clamp the speed
                //This fixes an error with the cursor box escaping and flying off into the distance
                speed = Mathf.Clamp(speed, 0.05f, 0.15f);

                //These are the limits of the box in local X coordinates
                float min = -5.5f;
                float max = 5.5f;
                //Clamp the box x coordinate to avoid it breaking out of the game
                //Make sure to use local position as that centers on the camera
                float xPos = box.transform.localPosition.x;
                //This checks if the cursor box is off of the bar
                if (xPos > (max + 0.5f) || xPos < (min - 0.5f))
                {
                    Debug.Log("CLAMPED!");
                    //Teleport the box back onto the bar
                    Vector3 oldPosition = box.transform.localPosition;
                    Vector3 position = new Vector3(Mathf.Clamp(xPos, min, max), oldPosition.y, oldPosition.z);
                    box.transform.localPosition = position;
                }

                //Be sure to use local position
                xPos = box.transform.localPosition.x;
                //Reverse the direction if we have hit an end
                //This is what makes it bounce back and forward
                if ((xPos >= max && _direction == 1) || (xPos <= min && _direction == -1))
                {
                    _direction *= -1;
                }

                //Multiply the direction by the speed to make sure that the box does reverse direction when it needs to
                float translationMagnitude = _direction * speed;
                //Apply the magnitude to only the X axis as we only want to translate on the X axis
                Vector3 translation = new Vector3(translationMagnitude, 0, 0);
                //Move the box by translation magnitude on the X axis
                box.transform.Translate(translation);
            }
        }

        public void EndGame()
        {
            _gameState = GameState.End;
            endPanel.SetActive(true);
            endPanel.GetComponent<ScoreDisplayControl>().UpdateScores(_hits, _misses);
            //TODO: Submit scores
        }

        private void MoveGreenBox()
        {
            //Move the green box to a random X position in the below range
            float min = -5.5f;
            float max = 5.5f;
            //Pick a random value
            float xPos = Random.Range(min, max);
            Vector3 position = greenBar.transform.localPosition;
            //If the box isn't going to move much,
            //we want to add some more direction to it to make sure that it does move some significant amount
            //This is a while loop to make sure that the amount we add does actually move the box and
            //doesn't place it closer to the cursor
            while (Mathf.Abs(xPos - position.x) < 1f)
            {
                xPos += -_direction;
            }

            //Clamp the value to make sure its not out of bounds
            xPos = Mathf.Clamp(xPos, min, max);
            //Then apply the xPos value to just the X component of the position vector,
            //leaving the other two components as they are
            position = new Vector3(xPos, position.y, position.z);
            greenBar.transform.localPosition = position;
        }
    }
}