using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehaviour : MonoBehaviour
{
    GameObject myPrefab;
    //public Transform sceneStartPos; // Scene Block starting position
    private Transform startPos; // Block starting position

    private bool collided = false; // Has this block collided with another block
    private bool fail = false; // Missed Block

    private GameObject UIBehaviour; // Global UI behaviour Script gameobject
    private UIBehaviour ui; // UI behaviour Script

    void Start()
    {
        UIBehaviour = GameObject.Find("UIBehaviour");
        ui = UIBehaviour.GetComponent<UIBehaviour>();
        startPos = GameObject.Find("StartPos").transform;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Check") // If colliding with another check collider do nothing
        {
            return;
        }

        if (collision.name == "LeftBoxCollider")
        {
            ui.setDirection(1); // Making the block go right
        }
        else if (collision.name == "RightBoxCollider")
        {
            ui.setDirection(-1); // Making the block go left
        }
        else if (collision.name != "Floor" && !collided)
        {
            collided = true;
            // Determining the next block shape
            selectNewPrefab();

            // Generating new block
            Instantiate(myPrefab, startPos.position, startPos.rotation);
            ui.UpdateBlockNo();

            // Destroying this script
            Destroy(this.transform.parent.gameObject.GetComponent<BlockControllerV2>());
        }
        else if (collision.name == "Floor" && collided && !fail)
        { // If colliding with the floor after colliding with another object and havent failed yet.
            fail = true;

            // Determining the next block shape
            selectNewPrefab();
            ui.UpdateFail();

            // Destroying the object this script is attached to
            Destroy(this.transform.parent.gameObject);
        }
        else if (collision.name == "Floor" && !fail)
        { // If colliding with floor and have not failed in the last few seconds
            fail = true;

            // Determining next block shape
            selectNewPrefab();
            ui.UpdateFail();
            Instantiate(myPrefab, startPos.position, startPos.rotation);

            Destroy(this.transform.parent.gameObject);
        }

    }

    // Psuedo-Randomly selects the next block
    private void selectNewPrefab()
    {
        // Gets a random number between 1 and 3 (inclusive)
        int objNumber = Random.Range(1, 4);
        Debug.Log("Obhject number " + objNumber);

        if (objNumber == 1)
        {
            // Can access gameassets because its in the 'Resources' folder
            myPrefab = GameAssets.i.block;
        }
        else if (objNumber == 2)
        {
            myPrefab = GameAssets.i.block2;
        }
        else
        {
            myPrefab = GameAssets.i.block3;
        }
    }
}
