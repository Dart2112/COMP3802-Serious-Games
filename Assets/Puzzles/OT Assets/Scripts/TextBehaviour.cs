using System;
using UnityEngine;
using TMPro;
using Object = UnityEngine.Object;

namespace Puzzles.OT_Assets.Scripts
{
    public class TextBehaviour : MonoBehaviour
    {
        public float fadeSpeed = 1.0f;
        public float speed = 0.05f;
        private TextMeshPro _text;

        private void Start()
        {
            _text = GetComponent<TextMeshPro>();
            _text.color = _text.text == "YES" ? Color.green : Color.red;
        }

        // Update is called once per frame
        void Update()
        {
            //Fade the alpha
            Color oldColor = _text.color;
            float alpha = oldColor.a;
            Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alpha - (fadeSpeed * Time.deltaTime));
            _text.color = newColor;
            //Once its not visible we destroy it
            if (_text.color.a <= 0)
            {
                Destroy(gameObject);
            }
            //Move upward
            Vector3 translation = Vector3.up * speed * Time.deltaTime;
            transform.Translate(translation);
        }
    }
}