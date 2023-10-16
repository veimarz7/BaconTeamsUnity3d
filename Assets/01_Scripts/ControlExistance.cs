using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlExistance : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BothPlayer();


    }
    public void BothPlayer()
    {

        if (GameObject.FindGameObjectWithTag("playerone") == null && GameObject.FindGameObjectWithTag("playertwo") == null)
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
