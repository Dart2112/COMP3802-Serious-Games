using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPStartScript : MonoBehaviour
{
    public GameObject startMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (startMenu.activeSelf)
            {
                startMenu.SetActive(false);
                Destroy(this);
            }
        }
    }
}
