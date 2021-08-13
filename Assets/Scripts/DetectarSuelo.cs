using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarSuelo : MonoBehaviour
{

    private GameObject Jugador;
    private MovimientoJugador movimientoJugador;

    // Start is called before the first frame update
    void Start()
    {
        Jugador = gameObject.transform.parent.gameObject;
        movimientoJugador = Jugador.GetComponent<MovimientoJugador>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Jugador.GetComponent<MovimientoJugador>().En_suelo = true;
        } else if (collision.collider.CompareTag("PlataformaMovil"))
        {
            Jugador.transform.localScale = new Vector3(1, 1, 1);
            movimientoJugador.En_suelo = true;            
            Jugador.transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            movimientoJugador.En_suelo = false;            
        }
        else if (collision.collider.CompareTag("PlataformaMovil"))
        {
            movimientoJugador.En_suelo = false;
            Jugador.transform.parent = null;
        }
    }
}
