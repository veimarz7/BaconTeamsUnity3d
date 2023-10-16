using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class Heath_Br2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;
     public Animator animat;
   

   
    void Start()
    {
        vidaActual = vidaMax;
        StartCoroutine(ReducirVida());
    }

    // Update is called once per frame
    void Update()
    {
        BothPlayer();
        RevisarVida();
        if (vidaActual <= 0)
        {
            animat.SetTrigger("Death");


            Invoke("DeathT", 1.8f);
        }
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    AumentarVida();
        //}

    }
    private void DeathT()
    {
        // Ejecuta el código original

        gameObject.SetActive(false);

        // Nueva opción: fija el jugador
        // transform.position = new Vector3(0, 0, 0);
    }
    public void RevisarVida()
    {
        float porcentajeVida = vidaActual / vidaMax;
        imagenBarraVida.fillAmount = porcentajeVida;


    }
    IEnumerator ReducirVida()
    {
        while (vidaActual > 0)
        {
            yield return new WaitForSeconds(2f);
            vidaActual -= 1;
        }
    }
    public void AumentarVida()
    {
        if (vidaActual < vidaMax)
        {
            vidaActual += 2;
        }
    }
    public void BothPlayer()
    {

        if (GameObject.FindGameObjectWithTag("playerone") == null && vidaActual == 0)
        {
            // Carga la escena 0

            Invoke("menu", 1.8f);
        }

    }
    public void menu()
    {
        SceneManager.LoadScene(0);

    }
}
