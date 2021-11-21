using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonBehaviour : MonoBehaviour
{
    public GameObject phone;
    public GameObject noteBook;
    private bool _allowOpen;
    private string test;

    void Start()
    {
        _allowOpen = false;
    }

    public void OpenPhone()
    {
        if (_allowOpen)
        {
            Debug.Log("openphone");
            Instantiate(phone);
        }
    }

    public void OpenNotebook()
    {
        if (_allowOpen)
        {
            Debug.Log("opennotebook");
            Instantiate(noteBook);
        }
    }

    public void CloseNotebook()
    {
        Debug.Log("closing notebook");
        Destroy(gameObject);
    }

    public void ClosePhone()
    {
        Debug.Log("closing phone");
        Destroy(gameObject);
    }

    public void AllowOpen()
    {
        Debug.Log("AllowOpen is trye");
        _allowOpen = true;
    }
}