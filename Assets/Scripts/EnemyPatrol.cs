using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentWaypoint;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentWaypoint = waypoints[0].transform;
        sprite = GetComponent<SpriteRenderer>();
        anim.SetBool("isWalking", true);
    }

    void Update()
    {
        Vector2 point = currentWaypoint.position - transform.position;
        if (currentWaypoint == waypoints[0].transform)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            sprite.flipX = true;
        }
        else if (currentWaypoint == waypoints[1].transform)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            sprite.flipX = false;
        }

        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.5f && currentWaypoint == waypoints[0].transform)
        {
            currentWaypoint = waypoints[1].transform;
        }
        else if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.5f && currentWaypoint == waypoints[1].transform)
        {
            currentWaypoint = waypoints[0].transform;
        }
    }
}
