using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform dog;
    private int counter = 0;

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
        counter++;

        if(counter == 1)
        {
            dog.position = new Vector2(570, 100);
        }

        if (counter == 2)
        {
            dog.position = new Vector2(160, 70);
        }

        if (counter == 3)
        {
            dog.position = new Vector2(490, 330);
        }

        if (counter == 4)
        {
            dog.position = new Vector2(1000, 320);
        }

    }
}
