using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool pausado = false;
    public GameObject menuPausa;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (pausado){
                Reanudar();
            }else{
                Pausar();
            }
        }
    }

    public void Reanudar(){
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    void Pausar(){
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void CargarMenu(){
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1f;
    }

    public void SalirJuego(){
        Application.Quit();
    }
}
