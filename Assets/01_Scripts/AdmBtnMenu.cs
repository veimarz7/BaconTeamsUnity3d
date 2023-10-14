using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdmBtnMenu : MonoBehaviour
{
    public Animator btnPrinciAnimator;
    public Animator titleAnima;
    public Animator btnCreditAnima;

    public void Play()
    {
        btnPrinciAnimator.SetBool("PrinActivate", false);
        Invoke("goPlay", 0.5f);
    }
    private void goPlay()
    {
        // aqui escribir el nombre de la escena que queremos ir
        SceneManager.LoadScene("Game");

    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        btnPrinciAnimator.SetBool("PrinActivate", false);
        titleAnima.SetBool("TitleOut", false);
        btnCreditAnima.SetBool("OutCredits", false);
    }

    // esto activara el menu
    public void Menu()
    {
        btnPrinciAnimator.SetBool("PrinActivate", true);
        titleAnima.SetBool("TitleOut", true);
        btnCreditAnima.SetBool("OutCredits", true);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
