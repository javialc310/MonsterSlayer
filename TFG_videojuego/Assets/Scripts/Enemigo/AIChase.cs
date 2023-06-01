using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Animator anim;
    public Enemigo enemy;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 7){
                if (!enemy.muriendo){
                    if (transform.position.x > player.transform.position.x){ 
                        transform.position += Vector3.left * speed * Time.deltaTime;
                        anim.SetBool("walking", true);
                    }else{
                        transform.position += Vector3.right * speed * Time.deltaTime;
                        anim.SetBool("walking", true);
                    }
                }
            }else{
                anim.SetBool("walking", false);
            }
        
    }
}
