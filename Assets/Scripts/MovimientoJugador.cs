using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    // Variables públicas    
    private float Velocidad = 7;
    private float Fuerza_de_salto = 12;

    public bool En_suelo = false;
    public bool RestringirMovimiento = false;
    public bool IsMuerto = false;
    public bool dobleSaltoPermitido = true;
    public Joystick joystick;

    private Jugador jugador;

    private bool Sentado = false;
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<Jugador>();
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
    }

    // Update is called once per frame
    void Update()
    {

        if (!RestringirMovimiento)
        {
            Vector3 movimiento = new Vector3(joystick.Horizontal, 0f, 0f);
            
                            
                Vector3 cinetica = movimiento * Time.deltaTime * Velocidad;
                transform.position += cinetica;
                if (cinetica.x < 0)
                {
                    Debug.Log(cinetica.x);
                    Vector3 localScaleOriginal = transform.localScale;
                    localScaleOriginal.x = Mathf.Abs(transform.localScale.x);
                    transform.localScale = localScaleOriginal;
                }
                else if (cinetica.x > 0)
                {
                    Debug.Log(cinetica.x);
                    Vector3 localScaleOriginal = transform.localScale;
                    if (transform.localScale.x != -1)
                        localScaleOriginal.x = (transform.localScale.x * -1);
                    else
                        localScaleOriginal.x = transform.localScale.x;
                    transform.localScale = localScaleOriginal;
                }

            
            
                animator.SetFloat("Velocidad", Mathf.Abs(movimiento.x));
            
            


            // Saltar
            /*
            if (Input.GetKeyDown("Jump") && !Sentado)
            {
                if (En_suelo)
                {
                    Saltar();                    
                }
                               
            }
            */

            /*
            // Atacar
            if (Input.GetKeyDown("space"))
            {
                Atacar();
            }
            else
            {
                animator.SetBool("Atacando", false);
            }
            */

            // Animar salto
            if (En_suelo)
            {
                animator.SetBool("Saltando", false);
            }
            else
            {
                animator.SetBool("Saltando", true);
            }
        }
        else
        {
            animator.SetFloat("Velocidad", 0f);
        }


        // Descansar
        if (Input.GetKey("down"))
        {
            animator.SetBool("Descansando", true);
            RestringirMovimiento = true;
        }
        else if (!IsMuerto)
        {
            animator.SetBool("Descansando", false);
            RestringirMovimiento = false;
        }
    }

    public void Saltar()
    {
        if (En_suelo)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Fuerza_de_salto), ForceMode2D.Impulse);
        }
    }

    public void Atacar()
    {
        Debug.Log("[MovimientoJugador.cs] -> START Atacar()");
        StartCoroutine(jugador.Atacar());
        animator.SetBool("Atacando", true);
        Debug.Log("[MovimientoJugador.cs] -> FIN Atacar()");
    }

    public float getVelocidad()
    {
        return Velocidad;
    }

    public void setVelocidad(float velocidad)
    {
        Velocidad = velocidad;
    }

    public float getFuerzaSalto()
    {
        return Fuerza_de_salto;
    }

    public void setFuerzaSalto(float fuerzaSalto)
    {
        Fuerza_de_salto = fuerzaSalto;
    }

}
