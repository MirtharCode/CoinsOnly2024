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

        if (data.GetComponent<Data>().day00Checked)           // Solo sale el Jefe.
            imageComponent.sprite = imagenes[0];

        else if (data.GetComponent<Data>().day01Checked)       // Lo anterior y luego hasta Rockon.
        {
            randomIndex = Random.Range(0, 9);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day02Checked)       // Lo anterior hasta Pijus Magnus.
        {
            randomIndex = Random.Range(0, 16);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day03Checked)       // Lo anterior hasta Jissy.
        {
            randomIndex = Random.Range(0, 23);
            imageComponent.sprite = imagenes[randomIndex];
        }

        else if (data.GetComponent<Data>().day04Checked)       // Lo anterior hasta Magmadora
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
        if (data.GetComponent<Data>().day01Checked) ImagesLoop(9);

        else if (data.GetComponent<Data>().day02Checked) ImagesLoop(16);

        else if (data.GetComponent<Data>().day03Checked) ImagesLoop(23);

        else if (data.GetComponent<Data>().day04Checked) ImagesLoop(26);

        else if (data.GetComponent<Data>().finalSecretoConseguido) ImagesLoop(imagenes.Length);
    }

    public void PreviousImage()
    {
        if (data.GetComponent<Data>().day01Checked) ReverseImagesLoop(9);

        else if (data.GetComponent<Data>().day02Checked) ReverseImagesLoop(16);

        else if (data.GetComponent<Data>().day03Checked) ReverseImagesLoop(23);

        else if (data.GetComponent<Data>().day04Checked) ReverseImagesLoop(26);

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
