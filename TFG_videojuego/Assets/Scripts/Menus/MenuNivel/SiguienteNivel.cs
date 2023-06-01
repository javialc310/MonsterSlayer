using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour
{
    public GameObject player;
    public GameObject pantallaNivel;

    public void PasarNivel(){
        player.GetComponent<movimiento_personaje>().PasarNivel();
        Time.timeScale = 1f;
    }

    public void CargarMenu(){
        player.GetComponent<movimiento_personaje>().PasarNivel();
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1f;
    }

    public void SalirJuego(){
        Application.Quit();
    }
}
