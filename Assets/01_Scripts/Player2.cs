using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Player2 : MonoBehaviour
{
    public Rigidbody rb;
    // public Rigidbody Player2;
    public float moveSpeedtwo = 5;
    public float jumpForce = 10f;
    public float alturaOriginal;
    public AudioClip jump;
    public bool canJump = true;
    public Animator animat;


    private Heath_Br2 vida;
    private float speedMoveOriginal = 5.0f;
    void Start()
    {
        // Guarda la altura original del jugador.
        alturaOriginal = transform.localScale.y;
        vida = FindObjectOfType<Heath_Br2>();
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
        rb.velocity = new Vector3(x * moveSpeedtwo, rb.velocity.y, -z * moveSpeedtwo);

        if (x != 0 || z != 0)
        {
            animat.SetBool("Run", true);
        }
        else
        {
            animat.SetBool("Run", false);
        }
    }


    void Jump()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.F)) // Cambia la condición a la tecla de espacio
            {
                // Activa el trigger "Jump" en el Animator (si lo necesitas)
                animat.SetTrigger("Jump");
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
        //cambio de escenas
        if (collision.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene(0);
        }
        //if (collision.gameObject.CompareTag("FinalJungle"))
        //{
        //    SceneManager.LoadScene(0); // 0 menu  ,1 city y 2 es jungla
        //}
        ////colision obstaculos
        if (collision.gameObject.CompareTag("heart"))
        {

            vida.AumentarVida();



        }
        if (collision.gameObject.CompareTag("thunder"))//teletrasnporta atras
        {

            moveSpeedtwo *= 3;

            // Invoca la función para volver a la velocidad normal después de 2 segundos
            Invoke("restoreSpeed", 2.0f);
        }
        if (collision.gameObject.CompareTag("carone"))
        {
            vida.vidaActual = vida.vidaActual - 2;

        }
        if (collision.gameObject.CompareTag("cartwo"))
        {
            Vector3 posicionActual = transform.position;

            Vector3 nuevaPosicion = new Vector3(posicionActual.x + 15f, posicionActual.y, posicionActual.z);

            // Establece la nueva posición del jugador
            transform.position = nuevaPosicion;

        }

    }

    public void restoreSpeed()
    {
        moveSpeedtwo = speedMoveOriginal;
    }
    public void Sprint()
    {


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeedtwo *= 2;
            animat.SetTrigger("Walk");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeedtwo /= 2;
            animat.SetTrigger("Walk");

        }
    }

}
