using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Rigidbody rb;
    // public Rigidbody Player2;
    public float moveSpeed = 5;
    public float jumpForce = 10f;
    public float alturaOriginal;
    public AudioClip jump;
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
        // Puedes ajustar la velocidad según sea necesario

        // Movimiento del jugador
        float x = Input.GetAxis("Vertical2");
        float z = Input.GetAxis("Horizontal2");

        // Invertir los sentidos
        x = -x;
        z = -z;

        // Asignar el movimiento al Rigidbody
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, -z * moveSpeed);
    }


    void Jump()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.F)) // Cambia la condición a la tecla de espacio
            {
                // Activa el trigger "Jump" en el Animator (si lo necesitas)

                AudioManager.instance.PlaySound(jump);
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
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5.0f; // Asegurarse de que la velocidad vuelva a la normal cuando se suelta Shift
        }
    }
}
