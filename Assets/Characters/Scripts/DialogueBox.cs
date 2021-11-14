 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    
    private Queue<string> sentences;
    private Queue<string> names;

    private string test;
    private UIButtonBehaviour behaviour;

    // Start is called before the first frame update
    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        behaviour = GameObject.Find("Behaviour").GetComponent<UIButtonBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        names.Clear();
        sentences.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextName();
        DisplayNextSentence();
    }

    public void DisplayNextName()
    {
        if (names.Count == 0)
        {
            return;
        }

        string name = names.Dequeue();
        nameText.text = name;
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() //You can use this method to change the scene maybe? or run another method from Game Manager?
    {
        Debug.Log("End");
        animator.SetBool("isOpen", false);
        test = GameManager.Scripts.GameManager.getCurrentScene();

        // For testing when not loaded into gamemanager. Set false when not in use
        bool notInGameManager = true;
        
        if (notInGameManager || test.Equals("Intro_End")) {
            // Allow Button Behaviour to work
            Debug.Log("Test2 is working");
            behaviour.AllowOpen();
        }

        // Because this method is re-used for dialogue, getting the currently loaded scene checks what scene to load next
        if (test.Equals("Intro_Start")) {
            GameManager.Scripts.GameManager.LoadNewScene("Intro_End", "Intro_Start");
        }

        if (test.Equals("Intro_End")) {
            // Allow Button Behaviour to work
            behaviour.AllowOpen();
        }


        if (test.Equals("Physiotherapist_Start"))
        {
            // Allow Button Behaviour to work
            GameManager.Scripts.GameManager.LoadNewScene("PhysioTherapyPuzzle", "Physiotherapist_Start");
        }

        if (test.Equals("OT_Start"))
        {
            GameManager.Scripts.GameManager.LoadNewScene("OT Puzzle", "OT_Start");
        }


    }
}
