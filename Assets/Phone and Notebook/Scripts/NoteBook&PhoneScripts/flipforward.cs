using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipforward : MonoBehaviour
{
    public Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void forward()
    {
        animate.SetBool("forward", true);
    }
}
