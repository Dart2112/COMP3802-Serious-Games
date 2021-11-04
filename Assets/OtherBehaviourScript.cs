using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherBehaviourScript : MonoBehaviour
{
    public Image pic, face;
    public Sprite sprit;
    public Button obj, obj1, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9;
    public Text bio1, bio2, def1, def2, def3, def4, def5, def6, def7, def8, def9, def10, def11, def12, def13, def14, def15, def16, def17, def18;

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
        obj.interactable = true;
        obj1.interactable = true;
        obj2.interactable = true;
        obj3.interactable = true;
        obj4.interactable = true;
        obj5.interactable = true;
        obj6.interactable = true;
        obj7.interactable = true;
        obj8.interactable = true;
        obj9.interactable = false;
        bio1.enabled = true;
        bio2.enabled = true;
        def1.enabled = false;
        def2.enabled = false;
        def3.enabled = false;
        def4.enabled = false;
        def5.enabled = false;
        def6.enabled = false;
        def7.enabled = false;
        def8.enabled = false;
        def9.enabled = false;
        def10.enabled = false;
        def11.enabled = false;
        def12.enabled = false;
        def13.enabled = false;
        def14.enabled = false;
        def15.enabled = false;
        def16.enabled = false;
        def17.enabled = false;
        def18.enabled = false;
        face.enabled = true;
    }
}
