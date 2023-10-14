using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float moveSpeed = 20.0f; // Velocidad de movimiento en el eje X
    public float fireInterval = 3.0f; // Intervalo de disparo en segundos

    private List<GameObject> bullets = new List<GameObject>();

    void Start()
    {
        // Llama a la función FireBullet cada "fireInterval" segundos y repite la llamada.
        InvokeRepeating("FireBullet", 0.0f, fireInterval);
    }

    // Esta función será llamada automáticamente cada "fireInterval" segundos.
    void FireBullet()
    {
        // Instancia el objeto
        GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullets.Add(bulletGo); // Agregar la nueva bala a la lista
    }

    void Update()
    {
        // Mueve todas las balas en la lista en el eje X
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] != null)
            {
                bullets[i].transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Si la bala se destruyó, quítala de la lista
                bullets.RemoveAt(i);
                i--; // Asegura que no saltemos ninguna bala
            }
        }
    }
}
