using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecogerMonedas : MonoBehaviour
{
    public int monedas;
    [SerializeField] private Text textomonedas;
    void Start(){
        DatosJugador datos = Guardar.CargarJugador();

        if(datos == null){
            monedas = 0;
        }else{
            monedas = datos.monedas;
        }

        textomonedas.text = "" + monedas;
    }
    
    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Moneda"){
            Destroy(col.gameObject);
            monedas++;
            textomonedas.text = "" + monedas;
        }
        if (col.gameObject.tag == "MonedaRoja"){
            Destroy(col.gameObject);
            monedas = monedas + 5;
            textomonedas.text = "" + monedas;
        }
    }
}
