using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationPlayer : MonoBehaviour
{
    public Animator footAnimator;
    [Range(0, 1)] public float footProgress = 0.0f;
    [Range(0, 1)] public float footTarget = 0.0f;

    public Animator shoeHornAnimator;
    [Range(0, 1)] public float shoeHornProgress = 0.0f;
    [Range(0, 1)] public float shoeHornTarget = 0.0f;

    void Start()
    {
        footAnimator.speed = 0;
        shoeHornAnimator.speed = 0;
    }

    /*
     * Shoehorn 30
     * shoe 30
     * shoehorn 60
     * shoehorn 90
     * shoehorn 120
     * shoe 60 (END)
     * shoehorn 150 (END)
     */
    private AnimationProgress[] arr = new AnimationProgress[]
    {
        new AnimationProgress(0, 0),
        new AnimationProgress(0, 30),
        new AnimationProgress(30, 30),
        new AnimationProgress(30, 60),
        new AnimationProgress(30, 90),
        new AnimationProgress(30, 120),
        new AnimationProgress(60, 120),
        new AnimationProgress(60, 150),
    };

    private int index = 0;
    private float t = 0.0f;
    float footFrames = 0;
    float shoeHornFrames = 0;

    void FixedUpdate()
    {
        bool animate = false;
        //Detect if the animation needs to play
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index += 1;
            animate = true;
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            index -= 1;
            animate = true;
        }

        if (animate)
        {
            AnimationProgress progress = arr[index];
            footFrames = progress.shoe;
            shoeHornFrames = progress.horn;

            t = 0.0f;

            Debug.Log(progress.toString() + "  Foot:" + footFrames + "  Shoehorn:" + shoeHornFrames);
        }

        //Map frames to animation progress
        footTarget = map(footFrames, 0, 60);
        shoeHornTarget = map(shoeHornFrames, 0, 150);

        //Lerp to the correct animation point
        if (footProgress != footTarget || shoeHornProgress != shoeHornTarget)
        {
            t += 1.0f / 120.0f;
        }
        else
        {
            t = 0.0f;
        }

        footProgress = Mathf.Lerp(footProgress, footTarget, t);
        footAnimator.Play("Ani", -1, footProgress);
        shoeHornProgress = Mathf.Lerp(shoeHornProgress, shoeHornTarget, t);
        shoeHornAnimator.Play("Ani", -1, shoeHornProgress);
    }

    float map(float s, float a1, float a2)
    {
        return 0 + (s - a1) * (1 - 0) / (a2 - a1);
    }

    protected class AnimationProgress
    {
        public AnimationProgress(float shoe, float horn)
        {
            this.shoe = shoe;
            this.horn = horn;
        }

        public float shoe;
        public float horn;

        public String toString()
        {
            return shoe + "-" + horn;
        }
    }
}