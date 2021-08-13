using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pinchos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Morir(collision));
        }
    }

    private IEnumerator Morir(Collider2D collision)
    {
        collision.GetComponentInParent<Jugador>().Morir(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
