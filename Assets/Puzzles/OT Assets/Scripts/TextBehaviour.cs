using System;
using UnityEngine;
using TMPro;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Puzzles.OT_Assets.Scripts
{
    public class TextBehaviour : MonoBehaviour
    {
        public float fadeSpeed = 1.0f;
        public float speed = 1f;
        public float maxDrift = 1f;
        private float _drift;
        private SpriteRenderer _sprite;

        private void Start()
        {
            _drift = Random.Range(-maxDrift, maxDrift);
            _sprite = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            //Fade the alpha, this makes the prefab fade as it rises
            Color oldColor = _sprite.color;
            float alpha = oldColor.a;
            Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alpha - (fadeSpeed * Time.deltaTime));
            _sprite.color = newColor;
            //Once its not visible we destroy it, this clears it from the scene so they don't stack up
            if (_sprite.color.a <= 0)
            {
                Destroy(gameObject);
            }

            //Translate upwards based on speed
            //We also apply drift to the x value, this makes them float up at different angles
            Vector3 translation = new Vector3(_drift * Time.deltaTime, speed * Time.deltaTime, 0);
            transform.Translate(translation);
        }
    }
}