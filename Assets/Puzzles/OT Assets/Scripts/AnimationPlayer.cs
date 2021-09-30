using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationPlayer : MonoBehaviour
{
    public Animator foot;
    public float target = 0.0f;

    public void animateFoward()
    {
        target += 0.05f;
    }

    public void animateBackward()
    {
        target -= 0.025f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //foot.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}