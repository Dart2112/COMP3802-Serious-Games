using UnityEngine;

namespace MainMenus.Scripts
{
    public class CreditsControl : MonoBehaviour
    {
        public float speed = 2f;
        public float timeToEnd = 75f;
        public float timeElapsed;
        private bool _ended;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_ended)
                return;
            gameObject.transform.Translate(Vector3.up.normalized * speed);
            timeElapsed += Time.fixedDeltaTime;
            if (timeElapsed > timeToEnd)
            {
                _ended = true;
                GameManager.Scripts.GameManager.LoadNewScene("MainMenus", "credits");
            }
        }
    }
}