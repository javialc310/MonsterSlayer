using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    public Transform controladorGolpe;
    public float radioGolpe;
    public int damage;
    private Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            Golpe();
        }
    }

    private void Golpe(){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos){
            if (colisionador.CompareTag("Enemigo")){
                colisionador.transform.GetComponent<Enemigo>().getDamage(damage);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Enemigo"){
            GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>().corazones -= 1;
            GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>().UpdateHearts();
            if(GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>().corazones <= 0){
                anim.SetTrigger("death");
            }else{
                anim.SetTrigger("hurt");
            }
            
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
