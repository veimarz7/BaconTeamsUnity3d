using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerJungla : MonoBehaviour
{
    public List<GameObject> bulletPrefab = new List<GameObject>();
    public Transform firePoint;
    public float moveSpeed = 20.0f; // Velocidad de movimiento en el eje X
    public float fireInterval = 3.0f; // Intervalo de disparo en segundos



    void Start()
    {
        // Llama a la función FireBullet cada "fireInterval" segundos y repite la llamada.
        InvokeRepeating("FireBullet", 0.0f, fireInterval);
    }

    // Esta función será llamada automáticamente cada "fireInterval" segundos.
    void FireBullet()
    {
        int enemy = Random.Range(0, 1);// 0 1 2 3
        GameObject bulletGo = Instantiate(bulletPrefab[enemy], firePoint.position, firePoint.rotation);
        bulletPrefab.Add(bulletGo); // Agregar la nueva bala a la lista
    }

    void Update()
    {
        float r = Random.Range(1, 4);

        // Mueve todas las balas en la lista en el eje X
        for (int i = 0; i < bulletPrefab.Count; i++)
        {
            if (bulletPrefab[i] != null)
            {
                bulletPrefab[i].transform.Translate(Vector3.right * moveSpeed * 2 * Time.deltaTime);
            }
            else
            {
                // Si la bala se destruyó, quítala de la lista
                bulletPrefab.RemoveAt(i);
                i--; // Asegura que no saltemos ninguna bala
            }
        }



        Vector3 position = transform.position;

        // Obtener el valor aleatorio entre -365 y -375
        float z = Random.Range(-365, -370);

        // Establecer la nueva posición del GameObject 3D
        position.z = z;

        // Actualizar la posición del GameObject 3D
        transform.position = position;

        // Aplicar la velocidad
        transform.Translate(0, 0, 1);
    }
}
