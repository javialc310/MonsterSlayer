using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Animator animator;
    public int vida;
    public bool muriendo;
    public Rigidbody2D enemyRb;
    public GameObject player;
    public float KBForce;
    

    // Start is called before the first frame update
    void Start()
    {
        muriendo = false;
        animator = GetComponent<Animator>();
        vida = 3;   
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getDamage(int damage){
        if(transform.position.x < player.transform.position.x){
            enemyRb.AddForce(Vector2.left * KBForce, ForceMode2D.Impulse);
        }else{
            enemyRb.AddForce(Vector2.right * KBForce, ForceMode2D.Impulse);
        }

        vida -= damage;
        if (vida <=0){
            animator.SetTrigger("Muerte");
            muriendo = true;
        }
    }


    public void DestruirObjecto(){
        Destroy(animator.gameObject);
    }
}
