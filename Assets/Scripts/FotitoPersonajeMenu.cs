using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotitoPersonajeMenu : MonoBehaviour
{
    public Sprite[] imagenes; // Arrastra tus sprites aquí desde el Inspector.

    private Image imageComponent;

    void Start()
    {
        // Accede al componente Image.
        imageComponent = GetComponent<Image>();

        if (imagenes.Length > 0)
        {
            // Genera un índice aleatorio basado en el número de sprites disponibles.
            int randomIndex = Random.Range(0, imagenes.Length);

            // Asigna el sprite aleatorio al componente Image.
            imageComponent.sprite = imagenes[randomIndex];
        }
        else
        {
            Debug.LogError("No se han asignado sprites en el Inspector.");
        }
    }

}
