using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FotitoPersonajeMenu : MonoBehaviour
{
    public Sprite[] imagenes;
    public int randomIndex;

    private Image imageComponent;

    [SerializeField] public GameObject data;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
        imageComponent = GetComponent<Image>();

        if (data.GetComponent<Data>().day0Check)           // Solo sale el Jefe.
            imageComponent.sprite = imagenes[0];

        else if (data.GetComponent<Data>().day1Check)       // Lo anterior y luego hasta Rockon.
        {
            randomIndex = Random.Range(0, 9);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day2Check)       // Lo anterior hasta Pijus Magnus.
        {
            randomIndex = Random.Range(0, 16);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day3Check)       // Lo anterior hasta Jissy.
        {
            randomIndex = Random.Range(0, 23);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day4Check)       // Lo anterior hasta Magmadora
        {
            randomIndex = Random.Range(0, 26);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().finalSecretoConseguido)       // Se incluye Detective
        {
            randomIndex = Random.Range(0, imagenes.Length);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else imageComponent.sprite = imagenes[0]; //Si no detecta ningún día completado, salta el jefe (Esto debido al guardado)
    }

    public void NextImage()
    {
        if (data.GetComponent<Data>().day1Check) ImagesLoop(9);

        else if (data.GetComponent<Data>().day2Check) ImagesLoop(16);

        else if (data.GetComponent<Data>().day3Check) ImagesLoop(23);

        else if (data.GetComponent<Data>().day4Check) ImagesLoop(26);

        else if (data.GetComponent<Data>().finalSecretoConseguido) ImagesLoop(imagenes.Length);
    }

    public void PreviousImage()
    {
        if (data.GetComponent<Data>().day1Check) ReverseImagesLoop(9);

        else if (data.GetComponent<Data>().day2Check) ReverseImagesLoop(16);

        else if (data.GetComponent<Data>().day3Check) ReverseImagesLoop(23);

        else if (data.GetComponent<Data>().day4Check) ReverseImagesLoop(26);

        else if (data.GetComponent<Data>().finalSecretoConseguido) ReverseImagesLoop(imagenes.Length);
    }

    void ImagesLoop(int limit)
    {
        if (randomIndex != limit - 1) randomIndex += 1;

        else randomIndex = 0;

        imageComponent.sprite = imagenes[randomIndex];
    }

    void ReverseImagesLoop(int limit)
    {
        if (randomIndex != 0) randomIndex -= 1;

        else randomIndex = limit - 1;

        imageComponent.sprite = imagenes[randomIndex];
    }
}
