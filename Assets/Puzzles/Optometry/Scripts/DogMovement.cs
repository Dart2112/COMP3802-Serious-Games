using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform dog;

    void Start()
    {
        dog = GameObject.Find("DogButton").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        dog.position = new Vector2(350, -221);
    }
}
