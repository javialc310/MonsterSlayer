using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public GameObject menuMuerte;
    
    public void Muerte(){
        menuMuerte.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reaparecer(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void CargarMenu(){
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1f;
    }

    public void SalirJuego(){
        Application.Quit();
    }
}
