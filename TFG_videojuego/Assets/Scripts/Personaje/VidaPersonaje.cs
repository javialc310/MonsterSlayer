using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaPersonaje : MonoBehaviour
{
    public int corazones;
    public Image[] imagenCorazones;
    // Start is called before the first frame update
    void Start()
    {
        ActualizarCorazones();
    }

    // Update is called once per frame

    public void ActualizarCorazones(){
        for (int i = 0; i < imagenCorazones.Length; i++){
            if (i < corazones){
                imagenCorazones[i].color = Color.white;
            }else{
                Color temp = imagenCorazones[i].color;
                temp.a=0f;
                imagenCorazones[i].color = temp;
            }
        }
    }

}
