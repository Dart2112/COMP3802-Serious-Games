using System;
using Puzzles.OccupationalTherapy.Scripts;
using UnityEngine;

namespace Puzzles.OT_Assets.Scripts
{
    public class AnimationPlayer : MonoBehaviour
    {
        public float animationSpeed = 15f;
        public Animator grabberAnimator;
        public Animator tongueAnimator;
        public Animator shoeHornAnimator;
        public Animator footAnimator;

        private AnimatedObject[] _objects;

        private void Start()
        {
            //Store the objects in an array to be accessed in Animate()
            //These need to be in the same order as they are in the animation progress array so that indices line up
            _objects = new[]
            {
                new AnimatedObject(grabberAnimator, 0, 90),
                new AnimatedObject(tongueAnimator, 0, 30),
                new AnimatedObject(shoeHornAnimator, 0, 60),
                new AnimatedObject(footAnimator, 0, 60)
            };
        }

        //Each of these is one of the states that the animations will take in the progress of the game
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


        //This is which animation progress item we are currently animating towards
        private int _index;

        //This value is used to drive the animations towards their target positions
        private float _t;

        public void AnimateForward()
        {
            if (_arr.Length - 1 == _index + 1)
            {
                _index++;
                Animate();
                Debug.Log("Reached End of Animations");
                //Trigger the end of game state
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameBarBehaviour>().EndGame();
            }
            else
            {
                _index++;
                Animate();
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
            //This is basically setting where each animation should go to so that it can be animated in fixed update
            for (int i = 0; i < 4; i++)
            {
                int frames = progress[i];
                AnimatedObject obj = _objects[i];
                obj.Frames = frames;
            }

            //Reset the time to 0 so that the animations start playing again from their current state towards the target
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
                //Setting the speed to 0 stops the animations from automatically playing
                //This is necessary as we control their playback at a custom speed by manually setting their progress
                _ani.speed = 0;
                //Make sure all progress is set to 0 so that the animations are playing from the start
                _target = 0.0f;
                _progress = 0.0f;
                Frames = 0;
                _startFrame = startFrame;
                _endFrame = endFrame;
            }

            public void MapFrames()
            {
                //Sets the target to a value from 0-1 given a frame in the animation
                _target = Map(Frames, _startFrame, _endFrame);
            }

            public bool IsAnimating()
            {
                //Dealing with floating point precision,
                //check if target is equal to progress as this means the animation is currently complete
                return Math.Abs(_target - _progress) > 0.005f;
            }

            public void ProgressAnimations(float t)
            {
                //Move towards the target with value t as our lerp value
                _progress = Mathf.Lerp(_progress, _target, t);
                //Apply this progression to the animator
                _ani.Play("Ani", -1, _progress);
            }

            private static float Map(float targetFrame, float startFrame, float endFrame)
            {
                return 0 + (targetFrame - startFrame) * (1 - 0) / (endFrame - startFrame);
            }
        }


        private class AnimationProgress
        {
            //This class is used as an array to store the progress of each animated object
            private readonly int _grabber, _tongue, _horn, _foot;

            public AnimationProgress(int grabber, int tongue, int horn, int foot)
            {
                _foot = foot;
                _horn = horn;
                _grabber = grabber;
                _tongue = tongue;
            }


            public int[] ToArray()
            {
                return new[] { _grabber, _tongue, _horn, _foot };
            }
        }
    }
}