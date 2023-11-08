using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotitoPersonajeMenu : MonoBehaviour
{
    public Sprite[] imagenes;

    private Image imageComponent;

    void Start()
    {
        // Accede al componente Image.
        imageComponent = GetComponent<Image>();

        int randomIndex = Random.Range(0, imagenes.Length);

        imageComponent.sprite = imagenes[randomIndex];
    }

}
