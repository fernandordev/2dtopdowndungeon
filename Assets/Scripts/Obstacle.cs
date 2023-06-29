using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;

    public float rotation = 0;

    void Start()
    {
        transform.Rotate(new Vector3(0, 0, rotation));
    }

    void FixedUpdate()
    {
        rig.MovePosition(transform.position + transform.up * -1 * speed * Time.deltaTime);
    }
}
