using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderGreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallDes"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("playerone"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("playertwo"))
        {
            Destroy(gameObject);
        }
    }
}
