using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoX : MonoBehaviour
{
    private Transform Jugador;
    private float posicionY;

    // Start is called before the first frame update
    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player").transform;
        posicionY = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 posicionCamaraOriginal = transform.position;
        posicionCamaraOriginal.x = Jugador.position.x;
        transform.position = posicionCamaraOriginal;
    }
}
