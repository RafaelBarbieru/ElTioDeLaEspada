using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
    
{
    [SerializeField]
    private Transform puntoOrigen, puntoDestino;

    [SerializeField]
    private float Velocidad = 1f;

    private Vector2 posicionOriginal;
    private Vector2 posicionSiguiente;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = puntoOrigen.position;
        /*
        if (transform.Find("Origen") != null && transform.Find("Destino") != null)
        {
            puntoOrigen = transform.Find("Origen");
            puntoDestino = transform.Find("Destino");            
        }        
        transform.position = puntoOrigen.position;
        */
        posicionSiguiente = posicionOriginal;
    }

    // Update is called once per frame
    void Update()
    {      
        if (transform.position == puntoOrigen.position)
        {
            posicionSiguiente = puntoDestino.position;
        } else if (transform.position == puntoDestino.position)
        {
            posicionSiguiente = puntoOrigen.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, posicionSiguiente, Velocidad * Time.deltaTime);
    }
}
