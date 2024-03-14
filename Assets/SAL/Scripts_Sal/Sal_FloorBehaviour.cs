using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sal_FloorBehaviour : MonoBehaviour
{
    public GameObject gameManager;      // GameObject que se rellenará con el objeto vacío GameManager en el Start.
    public AudioSource grassStep, mudStep, chofStep;

    private void Start()
    {
        // Rellenamos el GameObject anteriormente nombrado con el que se encuentre en escena con el tag GM.
        gameManager = GameObject.FindGameObjectWithTag("GM");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player"
            && (gameObject.GetComponent<SpriteRenderer>().color != Color.yellow))
        {
            // Si el que entra en mi trigger tiene el tag Player y nuestro color no es amarillo...
            if (gameObject.transform.name.Contains("Mud"))
            {
                gameObject.GetComponent<AudioSource>().enabled = true;
                mudStep.Play();
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;     // Pongo mi color en amarillo (baba).
            }

            if (gameObject.transform.childCount > 1)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;     // Pongo mi color en amarillo (baba).

                if ((gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled != true)
                && (gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled != true))
                {
                    gameObject.GetComponent<AudioSource>().enabled = true;
                    grassStep.Play();
                }

                if (gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled == true)
                {
                    gameObject.transform.GetChild(1).GetComponent<AudioSource>().enabled = true;
                    chofStep.Play();
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si el que sale en mi trigger tiene el tag Player y yo no tengo a mi hijo 0 activado (la sal)...
        if (collision.transform.tag == "Player" && gameObject.transform.name.Contains("Mud"))
        {
            mudStep.Stop();
            if ((gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled != true))
            {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true; // Activo ese hijo para que sea visible.
                gameManager.GetComponent<Sal_GameManager>().totalPaintedCells++;                    // Añado uno al contador de celdas pintadas.
            }
        }

        if (collision.transform.tag == "Player" && gameObject.transform.childCount > 1)
        {
            if ((gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled != true)
                && (gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled != true))
            {
                grassStep.Stop();
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true; // Activo ese hijo para que sea visible.
                gameManager.GetComponent<Sal_GameManager>().totalPaintedCells++;                    // Añado uno al contador de celdas pintadas.
            }

            if (gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled == true)
            {
                chofStep.Play();
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            }

        }
    }
}