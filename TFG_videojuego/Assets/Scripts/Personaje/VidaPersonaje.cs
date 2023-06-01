using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaPersonaje : MonoBehaviour
{
    public int corazones;
    public Image[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHearts(){
        for (int i = 0; i < hearts.Length; i++){
            if (i < corazones){
                hearts[i].color = Color.white;
            }else{
                Color temp = hearts[i].color;
                temp.a=0f;
                hearts[i].color = temp;
            }
        }
    }

}
