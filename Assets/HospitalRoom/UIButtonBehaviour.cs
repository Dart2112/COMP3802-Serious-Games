using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonBehaviour : MonoBehaviour
{
    public GameObject phone;
    public GameObject noteBook;

    void start() {
        //phone = GameObject.Find("Canvas");
        //noteBook = GameObject.Find("Canvas");
        noteBook.SetActive(false);
        phone.SetActive(false);
    }

    public void OpenPhone()
    {
        phone.SetActive(true);
    }

    public void OpenNotebook()
    {
        noteBook.SetActive(true);
    }
}
