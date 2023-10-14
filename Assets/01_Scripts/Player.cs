using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;

    void Start()
    {

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x * moveSpeed, 0, z * moveSpeed);
    }
}
