using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Descripcion : MonoBehaviour
{
    int razaSeleccionada;
    public string[] razasNormas;
    [SerializeField] public TextMeshProUGUI textoRaza;
    [SerializeField] public GameObject panelMagos;
    [SerializeField] public GameObject panelHibridos;
    [SerializeField] public GameObject panelElementales;
    [SerializeField] public GameObject panelLimbasticos;
    [SerializeField] public GameObject panelTecnopedos;


    void Start()
    {
        razasNormas = new string[5];
        razasNormas[0] = "Magos Oscuros";
        razasNormas[1] = "Híbridos";
        razasNormas[2] = "Tecno P2";
        razasNormas[3] = "Limbásticos";
        razasNormas[4] = "Elementales";

        razaSeleccionada = 0;
    }

    void Update()
    {
        
    }

    void MostrarRazaActual()
    {
        textoRaza.text = razasNormas[razaSeleccionada];
    }

    public void RetrocederRaza()
    {
        razaSeleccionada = (razaSeleccionada - 1 + razasNormas.Length) % razasNormas.Length;

        MostrarRazaActual();

        if (textoRaza.text == "Magos Oscuros")
        {
            panelMagos.SetActive(true);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Elementales")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(true);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Tecno P2")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(true);
        }

        else if (textoRaza.text == "Limbásticos")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(true);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Híbridos")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(true);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }
    }

    public void AvanzarRaza()
    {
        razaSeleccionada = (razaSeleccionada + 1) % razasNormas.Length;

        MostrarRazaActual();

        if (textoRaza.text == "Magos Oscuros")
        {
            panelMagos.SetActive(true);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Elementales")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(true);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Tecno P2")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(true);
        }

        else if (textoRaza.text == "Limbásticos")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(true);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Híbridos")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(true);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }
    }
}
