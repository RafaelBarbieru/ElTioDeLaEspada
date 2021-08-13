using System.Collections;
using System;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private Camera Camera;
    [SerializeField]
    private float Vida = 100f;
    [SerializeField]
    private float Ataque = 10f;
    [SerializeField]
    private float Velocidad = 5f;
    [SerializeField]
    private float FuerzaDeSalto = 12f;

    private Animator animator;
    private BoxCollider2D colliderEspada;
    private bool isInvulnerable = false;
    private bool isVelocidadExtra = false;
    private bool isMuerto = false;
    private bool atacando = false;

    private AudioSource[] fuenteSonidos;

    // Scripts
    private MovimientoJugador scriptMovimientoJugador;
    private SeguimientoX scriptSeguimientoCamara;

    private void Start()
    {
        // Obteniendo el animator
        animator = GetComponent<Animator>();
        // Obteniendo el script de movimiento del jugador
        scriptMovimientoJugador = GetComponent<MovimientoJugador>();
        // Obteniendo el script de seguimiento de la cámara
        scriptSeguimientoCamara = Camera.GetComponent<SeguimientoX>();
        // Obteniendo el collider de la espada
        colliderEspada = transform.Find("body").Find("Weapon").Find("EspadaCollider").GetComponent<BoxCollider2D>();
        colliderEspada.gameObject.SetActive(false);

        // Controlar la velocidad
        scriptMovimientoJugador.setVelocidad(Velocidad);
        // Controlar la fuerza de salto
        scriptMovimientoJugador.setFuerzaSalto(FuerzaDeSalto);

        // Iniciar el gestor de sonidos
        fuenteSonidos = GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (Vida <= 0)
        {
            Morir(false
                );
        }
        if (Input.GetKeyDown("x"))
        {
            StartCoroutine(AddVelocidadExtra(2f, 5f));
        }
        if (Input.GetKeyDown("z"))
        {
            StartCoroutine(AddInulnerabilidad(2f));
        }        
        if (isMuerto)
        {
            Camera.gameObject.transform.position = Vector3.MoveTowards(Camera.gameObject.transform.position, new Vector3(Camera.gameObject.transform.position.x, Camera.gameObject.transform.position.y + 12), 0.01f);
        }
    }

    public void Morir(bool zonaMuerte)
    {
        if (!isInvulnerable)
        {
            Debug.Log("[Jugador.cs] -> START Morir()");
            animator.SetFloat("Velocidad", 0f);
            isMuerto = true;
            // Se bloquea el control del jugador
            scriptMovimientoJugador.RestringirMovimiento = true;
            scriptMovimientoJugador.IsMuerto = true;
            animator.SetFloat("Vida", 0f);
            if (zonaMuerte)
            {
                Array.Find<AudioSource>(fuenteSonidos, audio => audio.clip.name == "Caer").Play();
            } else
            {
                Array.Find<AudioSource>(fuenteSonidos, audio => audio.clip.name == "Morir").Play();
            }            
            Debug.Log("[Jugador.cs] -> FIN Morir()");
        }
        
    }

    public IEnumerator Atacar()
    {  
        if (!atacando)
        {
            Debug.Log("[Jugador.cs] -> START Atacar()");
            atacando = true;            
            colliderEspada.gameObject.SetActive(true);
            Array.Find<AudioSource>(fuenteSonidos, audio => audio.clip.name == "Atacar").Play();
            yield return new WaitForSeconds(0.5f);
            colliderEspada.gameObject.SetActive(false);
            atacando = false;
            animator.SetBool("Atacando", false);
            Debug.Log("[Jugador.cs] -> FIN Atacar()");
        }        
    }

    // Power-ups
    public IEnumerator AddVelocidadExtra(float extra, float duracion)
    {
        if (!isVelocidadExtra)
        {
            isVelocidadExtra = true;
            Debug.Log("POWER UP -> Velocidad extra");
            Velocidad += extra;
            cambiarVelocidad();
            yield return new WaitForSeconds(duracion);
            Velocidad -= extra;
            cambiarVelocidad();
            Debug.Log("POWER UP <- Velocidad extra");
            isVelocidadExtra = false;
        }        
    }

    public IEnumerator AddInulnerabilidad(float duracion)
    {
        isInvulnerable = true;
        Debug.Log("POWER UP -> Invulnerabilidad");  
        yield return new WaitForSeconds(duracion);  
        Debug.Log("POWER UP <- Invulnerabilidad");
        isInvulnerable = false;

    }

    private void cambiarVelocidad()
    {
        scriptMovimientoJugador.setVelocidad(Velocidad);
    }

}
