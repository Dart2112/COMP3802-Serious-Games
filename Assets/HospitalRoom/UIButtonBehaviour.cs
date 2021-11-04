using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonBehaviour : MonoBehaviour
{
    public GameObject phone;
    public GameObject noteBook;

    void Start() {
        //phone = GameObject.Find("Canvas");
        //noteBook = GameObject.Find("Canvas");
        noteBook.SetActive(false);
        phone.SetActive(false);
    }

    public void OpenPhone()
    {
        Debug.Log("openphone");
        phone.SetActive(true);
    }

    public void OpenNotebook()
    {
        Debug.Log("opennotebook");
        noteBook.SetActive(true);
    }

    public void CloseNotebook() {
        Debug.Log("closing notebook");
        noteBook.SetActive(false);
    }

    public void ClosePhone() {
        Debug.Log("closing phone");
        phone.SetActive(false);
    }
}
