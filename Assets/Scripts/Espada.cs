using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            TriggerWin.ColeccionablesRestantes--;
            TriggerWin.txt_dn_restantes.text = (TriggerWin.ColeccionablesRestantes / 2).ToString();
            Debug.Log("Quedan " + TriggerWin.ColeccionablesRestantes + " coleccionables");            
        }
    }

}
