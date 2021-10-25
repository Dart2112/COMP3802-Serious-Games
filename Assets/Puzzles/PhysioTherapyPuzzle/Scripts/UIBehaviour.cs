using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIBehaviour : MonoBehaviour
{
    public Text count; // Current count of stacked blocks text field
    public Text fails; // Current count of failures text field
    private int blockCounter = 0; // Count of stacked blocks
    private int failCounter = 0; // Count of failures    
    private int goal = 9; // Block count goal
    private int max = 3; // Fail Limit

    [Tooltip("End Menu UI Screen")]
    public GameObject endMenu;

    [Tooltip("Fail menu UI screen")]
    public GameObject failMenu;

    private Transform startPos; // Starting position of the blocks
    private Transform camPos; // Camera Position

    private Vector3 camStartPos; // Camera Starting Position
    private float blockCamDifference; // Measures the distance between the startpos and camera centre.
    private float colliderCamDifference; // Measures the distance between the left/right collider and camera centre. 

    [Tooltip("Left collider")]
    public GameObject leftCollider;
    [Tooltip("Right Collider")]
    public GameObject rightCollider;

    [Tooltip("Direction of the block")]
    public int direction = 0;
    [Tooltip("Block Horizontal MoveSpeed")]
    public float moveSpeed = 0.02f;

    [Tooltip("Starting wait between fails time")]
    public float currentTime;

    [Tooltip("EndTime Timer")]
    public float endTime; // End timer for when goal is reached.
    private bool wait; // Are we still waiting until fail number can be updated.
    private bool ending; // Are we greater than the goal counter.

    private GameObject[] blockList; // List of all blocks currently on the screen. Used to determine block number.

    private GameObject currentObject; // Currently selected object under player control

    [Tooltip("End Timer GameObject UI")]
    public GameObject endCountDown;

    [Tooltip("End Timer UI circle")]
    public GameObject countDownCircle;

    private AudioSource success;
    private AudioSource fail;
    private AudioSource totalFailure;
    private AudioSource complete;


    // Start is called before the first frame update
    void Start()
    {
        //currentTime = 2;
        wait = false;
        ending = false;

        // Getting main camera and its starting position
        camPos = GameObject.Find("Main Camera").transform;
        startPos = GameObject.Find("StartPos").transform;
        camStartPos = camPos.position;
        count.text = blockCounter + " / " + goal;


        // Getting the starting difference between the camera and other objects
        blockCamDifference = startPos.position.y - camPos.position.y;
        colliderCamDifference = leftCollider.transform.position.y - camPos.position.y;

        // Getting Effect Sounds
        success = GameObject.Find("Success").GetComponent<AudioSource>();
        fail = GameObject.Find("Fail").GetComponent<AudioSource>();
        complete = GameObject.Find("Complete").GetComponent<AudioSource>();
        complete = GameObject.Find("Complete").GetComponent<AudioSource>();
        totalFailure = GameObject.Find("TotalFailure").GetComponent<AudioSource>();
    }

    void Update()
    {
        // Updating end and current times
        currentTime -= Time.deltaTime;
        endTime -= Time.deltaTime;

        UpdateBlockCounter();

        // If end goal has been reached and end wait time has been completed
        if (blockCounter >= goal && endTime < 0)
        {
            Time.timeScale = 0;
            direction = 0;
            endCountDown.SetActive(false);
            countDownCircle.SetActive(false);
            endMenu.SetActive(true);
            complete.Play();
        }
    }

    void FixedUpdate()
    {
        AdjustItemPositions();
    }

    // Updates when block collides with another block, sets end timer when goal is reached
    public void UpdateBlockNo()
    {
        blockCounter += 1;
        count.text = blockCounter + " / " + goal;
        success.Play();
        if (blockCounter == goal && !ending)
        {
            // Wait 4 seconds before ending
            ending = true;
            endTime = 4;
        }
    }

    // Updates the fail UI when blocks hit the floor
    public void UpdateFail()
    {
        // Checking current state of wait if waiting
        if (wait)
        {
            if (currentTime < 0)
            {
                wait = false;
                Debug.Log("wait is false");
            }
        }

        if (!wait)
        {
            wait = true;
            currentTime = 2;
            failCounter += 1;
            
            Debug.Log("Updating Fail");
        }

        fails.text = failCounter + " / " + max;

        if (failCounter == max)
        {
            Time.timeScale = 0;
            direction = 0;
            failMenu.SetActive(true);
            totalFailure.Play();
        } else fail.Play();
    }

    // Refreshing block counter by finding all gameobjects with tag 'Block'
    public void UpdateBlockCounter()
    {
        blockList = GameObject.FindGameObjectsWithTag("Block");
        blockCounter = blockList.Length - 1;
        if (blockCounter < 0)
        {
            blockCounter = 0;
        }

        if (blockCounter >= goal)
        {
            // set the screen as active
            endCountDown.SetActive(true);
            countDownCircle.SetActive(true);
            endCountDown.GetComponent<Text>().text = ((int)endTime).ToString(); // Converting to string and rounding
        }
        else
        {
            endCountDown.SetActive(false);
            countDownCircle.SetActive(false);
            ending = false;
        }

        count.text = blockCounter + " / " + goal;
    }

    // Adjusting the cam pos, start pos and block collider positions
    public void AdjustItemPositions()
    {
        // Increase scales to the number of blocks found on the screen
        float increase = blockCounter * 1f;

        // Adjusting Camera
        camPos.position = camStartPos + new Vector3(0, increase, -10f);

        // Adjusting Collider and block startpos positions in scene
        startPos.position = new Vector3(startPos.position.x, camPos.position.y + blockCamDifference, startPos.position.z);
        leftCollider.transform.position = new Vector3(leftCollider.transform.position.x, camPos.position.y + colliderCamDifference, 0);
        rightCollider.transform.position = new Vector3(rightCollider.transform.position.x, camPos.position.y + colliderCamDifference, 0);

        // Adjusting the current object position in scene
        if (currentObject != null)
        {
            if (direction != 0)
            {
                currentObject.transform.position = new Vector3(currentObject.transform.position.x + direction * moveSpeed, camPos.position.y + blockCamDifference, 0);
            }
        }

    }

    // Sets the new current object name and initial direction
    public void setCurrentObjectName(GameObject obj)
    {
        currentObject = obj;
        setDirection(1);
    }

    // Sets block transform direction
    public void setDirection(int i)
    {
        direction = i;
    }
}
