using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform[] waypoint;
    int waypointIndex;
    public GameObject idle;
    public DialogueTrigger dialogueTrigger;

    public float speed = 10f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = waypoint[waypointIndex].position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        moveCharacter(movement);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

        if (Vector2.Distance(transform.position, waypoint[waypointIndex].position) <= 0.02f)
        {
            nextWaypoint();
        }
    }

    void nextWaypoint()
    {
        if (waypointIndex >= waypoint.Length - 1)
        {
            Destroy(gameObject);
            idle.SetActive(true);
            dialogueTrigger.TriggerDialogue();
        }

        waypointIndex++;
    }
}
