using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Puzzles.Optometry.Scripts
{
    public class DogMovement : MonoBehaviour
    {
        // Start is called before the first frame update
        public Transform dog;
        public Transform image;
        public GameObject endPage;
        public Text endText;
        public StartScript startScript;
        private int _counter;

        void Start()
        {
            dog = GameObject.Find("DogButton").transform;
            image = GameObject.Find("image").transform;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void Click()
        {
            _counter++;

            if (_counter == 1)
            {
                dog.position = new Vector2(765, 140);
                image.position = new Vector2(765, 140);
            }

            if (_counter == 2)
            {
                dog.position = new Vector2(250, 120);
                image.position = new Vector2(250, 120);
            }

            if (_counter == 3)
            {
                dog.position = new Vector2(740, 550);
                image.position = new Vector2(740, 550);
            }

            if (_counter == 4)
            {
                dog.position = new Vector2(1500, 420);
                image.position = new Vector2(1500, 420);
            }

            if (_counter == 5)
            {
                endPage.SetActive(true);
                endText.text = "You did it in " + startScript.gameTime.ToString("F2") + " seconds!\nWell done!\n" +
                               "Press [SPACE] to return";
            }
        }
    }
}