using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotitoPersonajeMenu : MonoBehaviour
{
    public Sprite[] imagenes;

    private Image imageComponent;

    [SerializeField] public GameObject data;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
        imageComponent = GetComponent<Image>();

        if (!data.GetComponent<Data>().day1Check)           // Solo sale el Jefe.
            imageComponent.sprite = imagenes[0];

        else if (data.GetComponent<Data>().day1Check)       // Lo anterior y luego hasta Rockon.
        {
            int randomIndex = Random.Range(0, 9);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day2Check)       // Lo anterior hasta Pijus Magnus.
        {
            int randomIndex = Random.Range(0, 16);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day3Check)       // Lo anterior hasta Jissy.
        {
            int randomIndex = Random.Range(0, 23);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day4Check)       // Lo anterior hasta Magmadora
        {
            int randomIndex = Random.Range(0, 26);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day4Check)       // Lo anterior hasta Magmadora
        {
            int randomIndex = Random.Range(0, imagenes.Length);
            imageComponent.sprite = imagenes[randomIndex];
        }
    }

}
