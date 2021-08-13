using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Opciones()
    {
        SceneManager.LoadScene("Opciones");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
