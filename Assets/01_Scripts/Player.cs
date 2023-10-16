using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Rigidbody rb;
    // public Rigidbody Player2;
    public float moveSpeed = 5;
    public float jumpForce = 10f;
    public float alturaOriginal;
    public AudioClip jump;
    public bool canJump = true;
    public Animator animat;
    private Heatlh_Br vida;
    private float speedMoveOriginal = 5.0f;
    void Start()
    {
        // Guarda la altura original del jugador.
        alturaOriginal = transform.localScale.y;

        vida = FindObjectOfType<Heatlh_Br>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        //salto
        Sprint();
        Jump();
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    vida.AumentarVida();
        //}
    }

    void movement()
    {
        // Verifica si la tecla de flecha hacia arriba está presionada
      
            // Movimiento del jugador
            float x = Input.GetAxis("Vertical");
            float z = Input.GetAxis("Horizontal");

            // Invertir los sentidos
            x = -x;
            z = -z;

            // Asignar el movimiento al Rigidbody
            rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, -z * moveSpeed);

            // Controla el parámetro "etet" para manejar la animación
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
            if (Input.GetKeyDown(KeyCode.L)) // Cambia la condición a la tecla de espacio
            {
                // Activa el trigger "Jump" en el Animator
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
        if (collision.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene(0); // 0 menu  ,1 city y 2 es jungla
        }
        //if (collision.gameObject.CompareTag("FinalJungle"))
        //{
        //    SceneManager.LoadScene(0); // 0 menu  ,1 city y 2 es jungla
        //}
        if (collision.gameObject.CompareTag("heart"))
        {

            vida.AumentarVida();
            
             

        }
        if (collision.gameObject.CompareTag("thunder"))//teletrasnporta atras
        {

            moveSpeed *= 3;

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
        moveSpeed = speedMoveOriginal;
    }

    public void Sprint()
    {


        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            moveSpeed *= 2;
            animat.SetTrigger("Walk");
            //  animat.SetBool("",tr) victor pendiente
        }
        else if (Input.GetKeyUp(KeyCode.RightShift)) // Asegurarse de que cuando se suelta Shift, la velocidad vuelva a la normal
        {
            moveSpeed /= 2;
            animat.SetTrigger("Walk");
        }
    }
  

    

}
