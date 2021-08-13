using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWin : MonoBehaviour
{    
    public static int ColeccionablesRestantes;
    public static TextMeshProUGUI txt_dn_restantes;

    private void Start()
    {
        ColeccionablesRestantes = GameObject.FindGameObjectsWithTag("Enemy").Length * 2;
        TextMeshProUGUI[] allTextMesh = FindObjectsOfType<TextMeshProUGUI>();
        foreach (TextMeshProUGUI tm in allTextMesh)
        {
            if (tm.name == "TXT_DN_Restantes")
            {
                txt_dn_restantes = tm;
            }
        }
        txt_dn_restantes.text = (ColeccionablesRestantes / 2).ToString();
    }

    private void Update()
    {
        if (ColeccionablesRestantes == 0)
        {
            Ganar();
        }
    }

    private void Ganar()
    {
        if (SceneManager.GetActiveScene().name == "Nivel1")
        {
            SceneManager.LoadScene("Nivel2");
        } else if (SceneManager.GetActiveScene().name == "Nivel2")
        {
            SceneManager.LoadScene("Nivel3");
        } else if (SceneManager.GetActiveScene().name == "Nivel3")
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu");
    }
}
