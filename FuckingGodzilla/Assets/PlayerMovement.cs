using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    Vector3 movement;
     // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("P1LS_hori");
        movement.z = Input.GetAxis("P1LS_vert");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
