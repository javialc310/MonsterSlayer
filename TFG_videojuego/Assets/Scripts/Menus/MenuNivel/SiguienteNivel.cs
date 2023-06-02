using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour
{
    public GameObject player;
    public GameObject pantallaNivel;

    public void PasarNivel(){
        player.GetComponent<Personaje>().PasarNivel();
        Time.timeScale = 1f;
    }

    public void CargarMenu(){
        player.GetComponent<Personaje>().PasarNivel();
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1f;
    }

    public void SalirJuego(){
        Application.Quit();
    }
}
