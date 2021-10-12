using System;
using UnityEngine;

namespace Puzzles.OT_Assets.Scripts
{
    public class AnimationPlayer : MonoBehaviour
    {
        public float animationSpeed;
        public Animator grabberAnimator;
        public Animator tongueAnimator;
        public Animator shoeHornAnimator;
        public Animator footAnimator;

        private AnimatedObject[] _objects;

        private void Start()
        {
            _objects = new[]
            {
                new AnimatedObject(grabberAnimator, 0, 90),
                new AnimatedObject(tongueAnimator, 0, 30),
                new AnimatedObject(shoeHornAnimator, 0, 60),
                new AnimatedObject(footAnimator, 0, 60)
            };
        }

        //TODO: Add more steps in between to make the game last longer
        private readonly AnimationProgress[] _arr =
        {
            new AnimationProgress(0, 0, 0, 0),
            new AnimationProgress(15, 0, 0, 0),
            new AnimationProgress(30, 0, 0, 0),
            new AnimationProgress(60, 30, 0, 0),
            new AnimationProgress(60, 30, 0, 30),
            new AnimationProgress(90, 30, 0, 30),
            new AnimationProgress(90, 30, 30, 30),
            new AnimationProgress(90, 0, 30, 60),
            new AnimationProgress(90, 0, 60, 60)
        };


        private int _index;
        private float _t;

        public void AnimateFoward()
        {
            if (_arr.Length > (_index + 1))
            {
                _index += 1;
                Animate();
            }
            else
            {
                Debug.Log("Reached End of Animations");
            }
        }

        public void AnimateBackward()
        {
            if (_index != 0)
            {
                _index -= 1;
                Animate();
            }
            else
            {
                Debug.Log("Reached Start of Animations");
            }
        }

        private void Animate()
        {
            //Get the animation states that should be set as targets
            int[] progress = _arr[_index].ToArray();
            
            //Loop over each and set frames to the number from progress
            for (int i = 0; i < 4; i++)
            {
                int frames = progress[i];
                AnimatedObject obj = _objects[i];
                obj.Frames = frames;
            }

            _t = 0.0f;
        }

        void FixedUpdate()
        {
            //Map frames to animation progress and check if anything is animating
            bool isAnimating = false;
            foreach (AnimatedObject animatedObject in _objects)
            {
                animatedObject.MapFrames();
                if (animatedObject.IsAnimating())
                    isAnimating = true;
            }

            //Increment time value based on animation speed
            if (isAnimating)
            {
                _t += 1.0f / (30.0f * animationSpeed);
            }
            else
            {
                _t = 0.0f;
            }

            //Lerp the animations towards their targets
            foreach (AnimatedObject animatedObject in _objects)
            {
                animatedObject.ProgressAnimations(_t);
            }
        }

        private class AnimatedObject
        {
            private readonly Animator _ani;
            private float _target;
            private float _progress;
            public int Frames;
            private readonly int _startFrame, _endFrame;

            public AnimatedObject(Animator ani, int startFrame, int endFrame)
            {
                _ani = ani;
                _ani.speed = 0;
                _target = 0.0f;
                _progress = 0.0f;
                Frames = 0;
                this._startFrame = startFrame;
                this._endFrame = endFrame;
            }

            public void MapFrames()
            {
                _target = Map(Frames, _startFrame, _endFrame);
            }

            public bool IsAnimating()
            {
                return Math.Abs(_target - _progress) > 0.005f;
            }

            public void ProgressAnimations(float t)
            {
                _progress = Mathf.Lerp(_progress, _target, t);
                _ani.Play("Ani", -1, _progress);
            }

            private static float Map(float s, float a1, float a2)
            {
                return 0 + (s - a1) * (1 - 0) / (a2 - a1);
            }
        }


        private class AnimationProgress
        {
            private readonly int _grabber, _tongue, _horn, _foot;

            public AnimationProgress(int grabber, int tongue, int horn, int foot)
            {
                this._foot = foot;
                this._horn = horn;
                this._grabber = grabber;
                this._tongue = tongue;
            }


            public int[] ToArray()
            {
                return new[] { _grabber, _tongue, _horn, _foot };
            }
        }
    }
}