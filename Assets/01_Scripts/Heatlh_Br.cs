using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heatlh_Br : MonoBehaviour
{
    // Start is called before the first frame update

    public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;
    
    void Start()
    {
        vidaActual = vidaMax;
        StartCoroutine(ReducirVida());
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        if (vidaActual <=0)
        {
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            AumentarVida();
        }

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
            vidaActual += 1;
        }
    }
}
