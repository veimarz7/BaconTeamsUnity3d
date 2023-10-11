using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5;
    public float jumpForce = 10f;
    public float alturaOriginal;

    public bool canJump = true;

    void Start()
    {
        // Guarda la altura original del jugador.
        alturaOriginal = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        //salto
        Sprint();
        Jump();
    }

    void movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, z * moveSpeed);

        //agacharse :


    }

    void Jump()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Cambia la condición a la tecla de espacio
            {
                // Activa el trigger "Jump" en el Animator (si lo necesitas)


                // Aplica la fuerza de salto hacia arriba
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                canJump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;

        }
    }
    public void Sprint()
    {


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) // Asegurarse de que cuando se suelta Shift, la velocidad vuelva a la normal
        {
            moveSpeed /= 2;
        }
    }
}
