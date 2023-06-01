using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivacionPuertas : MonoBehaviour
{
    public GameObject player;
    public GameObject pantallaNivel;
    private float distance;
    private Animator anim;
    void Start(){
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 7){
            anim.SetBool("activada", true);
        }else{
            anim.SetBool("activada", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Personaje"){
            pantallaNivel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
