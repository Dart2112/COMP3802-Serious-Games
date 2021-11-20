using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform dog;
    public Transform image;
    public GameObject endPage;
    private int counter = 0;

    void Start()
    {
        dog = GameObject.Find("DogButton").transform;
        image = GameObject.Find("image").transform;
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
            dog.position = new Vector2(765, 140);
            image.position = new Vector2(765, 140);
        }

        if (counter == 2)
        {
            dog.position = new Vector2(250, 120);
            image.position = new Vector2(250, 120);
        }

        if (counter == 3)
        {
            dog.position = new Vector2(740, 550);
            image.position = new Vector2(740, 550);
        }

        if (counter == 4)
        {
            dog.position = new Vector2(1500, 420);
            image.position = new Vector2(1500, 420);
        }

        if (counter == 5)
        {
            endPage.SetActive(true);
        }


    }
}
