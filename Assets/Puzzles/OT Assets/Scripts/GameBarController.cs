using UnityEngine;

namespace Puzzles.OT_Assets.Scripts
{
    public class GameBarController : MonoBehaviour
    {
        public AnimationPlayer animations;
        public GameObject greenBar, box;
        public float speed = 0.05f;
        public float speedRamp = 0.03f;
        private int _direction = 1;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Check if the green bar is in the box
                bool hit = greenBar.GetComponent<BoxCollider>().bounds
                    .Intersects(box.GetComponent<BoxCollider>().bounds);
                //Progress if it hit, regress if it didn't
                //TODO: Add feedback to the player for if they hit or didnt hit it
                if (hit)
                {
                    Debug.Log("HIT!");
                    animations.AnimateFoward();
                    MoveGreenBox();
                    speed += speedRamp;
                }
                else
                {
                    Debug.Log("MISS!");
                    animations.AnimateBackward();
                    speed += -speedRamp;
                }
            }
            //Clamp the speed
            speed = Mathf.Clamp(speed, 0.05f, 0.15f);

            //Animate the box to bounce back and forward
            float min = -5.5f;
            float max = 5.5f;
            //Clamp the box x coordinate to avoid it breaking out of the game
            float xPos = box.transform.localPosition.x;
            if (xPos > (max + 0.5f) || xPos < (min - 0.5f))
            {
                Debug.Log("CLAMPED!");
                Vector3 oldPosition = box.transform.localPosition;
                Vector3 position = new Vector3(Mathf.Clamp(xPos, min, max), oldPosition.y, oldPosition.z);
                box.transform.localPosition = position;
            }

            //Be sure to use local position
            xPos = box.transform.localPosition.x;
            //Reverse the direction if we have hit an end
            if ((xPos >= max && _direction == 1) || (xPos <= min && _direction == -1))
            {
                _direction *= -1;
            }

            float translationMagnitude = _direction * speed;
            Vector3 translation = new Vector3(translationMagnitude, 0, 0);
            box.transform.Translate(translation);
        }

        private void MoveGreenBox()
        {
            //Move the green box to a random X position in the below range
            float min = -5.5f;
            float max = 5.5f;
            float xPos = Random.Range(min, max);
            Vector3 position = greenBar.transform.localPosition;
            //Make sure it moves a significant amount
            if (xPos - position.x < 1f)
            {
                xPos += -_direction;
            }

            //Clamp the value to make sure its not out of bounds
            xPos = Mathf.Clamp(xPos, min, max);
            position = new Vector3(xPos, position.y, position.z);
            greenBar.transform.localPosition = position;
        }
    }
}