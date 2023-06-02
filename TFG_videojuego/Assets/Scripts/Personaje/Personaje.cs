using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    private bool estaSuelo;
    public float saltoFuerza;
    public float checkRadius;
    public Transform posicion;
    public LayerMask saberSuelo;
    private bool atacando;
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float contadorSalto;
    public float tiempoSalto;
    private float moveInput;
    public float velocidad;
    public Vector3 respawnPoint;
    public GameObject fallDetector;
    public int nivel;
    public Animator checkpoint;
    public DatosJugador datos;


    // Start is called before the first frame update
    void Start()
    {   
        nivel = SceneManager.GetActiveScene().buildIndex;
        posicion = GetComponent<Transform>();
        atacando = false;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        datos = Guardar.CargarJugador();

        if (datos == null){
            respawnPoint = transform.position;
            Guardar.GuardarJugador(GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>(),
                                        GetComponent<RecogerMonedas>(), this);
        }else{
            nivel = datos.nivel;
            respawnPoint.x = datos.respawnPoint[0];
            respawnPoint.y = datos.respawnPoint[1];
            respawnPoint.z = datos.respawnPoint[2];
            GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>().corazones=datos.corazones;
            GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>().ActualizarCorazones();
            posicion.position = respawnPoint;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            sprite.flipX = true;
            transform.Translate(new Vector3(-0.0050f, 0.0f));
            anim.SetBool("walking", true);
        }else{
            if (Input.GetKeyUp(KeyCode.A)){
                anim.SetBool("walking", false);
            }
        }

        if (Input.GetKey(KeyCode.D)){
            sprite.flipX = false;
            transform.Translate(new Vector3(0.0050f, 0.0f));
            anim.SetBool("walking", true);
        }else{
            if (Input.GetKeyUp(KeyCode.D)){
                anim.SetBool("walking", false);
            }
        }

        if(Input.GetKeyDown(KeyCode.F)){
            atacando = true;
        }

        Jumping();

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    
    }

    void FixedUpdate(){
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * velocidad, rb.velocity.y);

        if (atacando){
            anim.SetTrigger("attack");
        }

        atacando = false;
    
    }

    void Jumping(){
        estaSuelo = Physics2D.OverlapCircle(posicion.position, checkRadius, saberSuelo);

        if(estaSuelo && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * saltoFuerza;
            contadorSalto = tiempoSalto;
        }

        if (Input.GetKey(KeyCode.Space)){
            if (contadorSalto >0){
                rb.velocity = Vector2.up * saltoFuerza;
                contadorSalto -= Time.deltaTime;
                anim.SetBool("jumping", true);
            }
        }

        if (estaSuelo){
            anim.SetBool("jumping", false);
        }

        if (Input.GetKeyUp(KeyCode.Space) && estaSuelo){
            anim.SetBool("jumping", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "FallDetector"){
            GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>().corazones -= 1;
            GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>().ActualizarCorazones();
            ComprobarMuerte();
            transform.position = respawnPoint;
        }

        if(collision.tag == "Checkpoint"){
            respawnPoint = transform.position;
            checkpoint.SetBool("checkpoint", true);
            Guardar.GuardarJugador(GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>(),
                                        GetComponent<RecogerMonedas>(), this);
        }
    }

    public void ComprobarMuerte(){
        if(GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>().corazones <= 0){
                GameObject.Find("PantallaMuerte").GetComponent<MenuMuerte>().Muerte();
            }
    }

    public void PasarNivel(){
        nivel = SceneManager.GetActiveScene().buildIndex + 1;
        Guardar.GuardarJugador(GameObject.Find("ControladorVida").GetComponent<VidaPersonaje>(),
                                        GetComponent<RecogerMonedas>(), this);
        SceneManager.LoadScene(nivel);
    }

    
}
