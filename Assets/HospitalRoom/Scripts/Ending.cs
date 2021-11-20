using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace HospitalRoom.Scripts
{
    public class Ending : MonoBehaviour
    {
        public GameObject background;
        public float fadeSpeed = 0.01f;
        public GameObject otherObjects;
        public Text scoreText;

        private Image _image;
        private bool _isDisplayed;

        // Start is called before the first frame update
        void Start()
        {
            _image = background.GetComponent<Image>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_image.color.a < 1.0f)
            {
                //Fade the screen to black
                Color color = _image.color;
                color.a += fadeSpeed;
                _image.color = color;
            }
            else
            {
                DisplayOtherItems();
            }
        }

        private void DisplayOtherItems()
        {
            if (_isDisplayed)
                return;
            _isDisplayed = true;
            //Fade completed
            //Display scores and other UI elements
            otherObjects.SetActive(true);
            //TODO: fetch scores and display
            int physioScore =
                GameManager.Scripts.GameManager.RetrieveScore(GameManager.Scripts.GameManager.Puzzle.PhysioTherapy);
            int otScore =
                GameManager.Scripts.GameManager.RetrieveScore(GameManager.Scripts.GameManager.Puzzle
                    .OccupationalTherapy);
            int optomScore =
                GameManager.Scripts.GameManager.RetrieveScore(GameManager.Scripts.GameManager.Puzzle.Optometry);
            int exerciseScore =
                GameManager.Scripts.GameManager.RetrieveScore(GameManager.Scripts.GameManager.Puzzle
                    .ExercisePhysio);
            float averageScore = GameManager.Scripts.GameManager.RetrieveAverageScore();
            scoreText.text =
                "Congratulations on completing the game. Here is how you went.\n" +
                "Physio Therapy: " + physioScore + "\n" +
                "Occupational Therapy: " + otScore + "\n" +
                "Optometry: " + optomScore + "\n" +
                 "Exercise Physio: " + exerciseScore + "\n" +
                "For an average score of " + averageScore.ToString("F2") + " out of 3.00";
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("GameManager");
        }
    }
}