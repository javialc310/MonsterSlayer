using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame(){
        Guardar.BorrarDatos();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CargarJuego(){
        DatosJugador datos = Guardar.CargarJugador();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + datos.nivel);
    }
}
