using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipbackward : MonoBehaviour
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

    public void backward()
    {
        animate.SetBool("forward", false);
    }
}
