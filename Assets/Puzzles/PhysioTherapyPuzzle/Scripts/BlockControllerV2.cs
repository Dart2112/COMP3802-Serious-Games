using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControllerV2 : MonoBehaviour
{
    private bool playerControl;
    //private float moveInput = 0;
    
   // private float direction = -1;
    private Rigidbody2D rb;
    private GameObject UIBehaviour; // Object Containing the UIBehaviour Script
    private UIBehaviour ui; // UIBehaviour script


    // Start is called before the first frame update
    void Start()
    {

        UIBehaviour = GameObject.Find("UIBehaviour");
        ui = UIBehaviour.GetComponent<UIBehaviour>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        ui.setCurrentObjectName(this.gameObject);
        //ui.AdjustItemPositions();
        Debug.Log("CurrentObjectName " + this.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControl) {
            if (Input.GetKeyDown("space"))
            {
                //Debug.Log("Space was pressed");
                playerControl = true;
                ui.setDirection(0);
                this.rb.gravityScale = 0.5f;
                // Create new object of 3 based on prefab
            }
        }
    }
    }
