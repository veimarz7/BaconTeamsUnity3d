using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour
{
    //public GameObject objeto;
    public float velocidadRotacion = 30f;
    public float tiempoDeVida = 10f;
    public float velocidadMovimiento = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, velocidadRotacion * Time.deltaTime, 0f);
        transform.Translate(0f, 0f, -velocidadMovimiento * Time.deltaTime);
        tiempoDeVida -= Time.deltaTime;

        if (tiempoDeVida <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
