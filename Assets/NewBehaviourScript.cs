using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image pic, face;
    public Sprite sprit;
    public Button obj, obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9; 
    public GameObject link;
    public Text bio1, bio2, def1, def2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewImage()
    {
        pic.sprite = sprit;
        obj.interactable = false;
        obj1.interactable = false;
        obj2.interactable = false;
        obj3.interactable = false;
        obj4.interactable = false;
        obj5.interactable = false;
        obj6.interactable = false;
        obj7.interactable = false;
        obj8.interactable = false;
        obj9.interactable = true;
        bio1.enabled = false;
        bio2.enabled = false;
        def1.enabled = true;
        def2.enabled = true;
        face.enabled = false;
        link.SetActive(true);
    }
}
