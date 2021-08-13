using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] fondos;
    private float[] cantidadParallax;
    public float suavizado = 1f;

    public Transform camara;
    private Vector3 posicionOriginalCamara;

    // Is called before Start()
    /*
    private void Awake()
    {
        camara = Camera.main.transform;
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        posicionOriginalCamara = camara.position;
        cantidadParallax = new float[fondos.Length];
        for (int i = 0; i < fondos.Length; i++)
        {
            cantidadParallax[i] = fondos[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fondos.Length; i++)
        {
            float parallax = (posicionOriginalCamara.x - camara.position.x) * cantidadParallax[i];
            float posicionXObjetivoFondo = fondos[i].position.x + parallax;
            Vector3 posicionObjetivoFondo = new Vector3(posicionXObjetivoFondo, fondos[i].position.y, fondos[i].position.z);
            fondos[i].position = Vector3.Lerp(fondos[i].position, posicionObjetivoFondo, suavizado * Time.deltaTime);
        }
        posicionOriginalCamara = camara.position;
    }
}
