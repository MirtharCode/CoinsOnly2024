using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class Sal_Remapping : MonoBehaviour
{
    public TextMeshProUGUI _arribaText, _abajoText, _izquierdaText, _derechaText, _pausaText;

    // Update is called once per frame
    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        ControlMapping();
    }

    public void AsignarArriba()
    {
        _arribaText.text = "pulsa una tecla...";
        _arribaText.fontSize = 30;
    }

    public void AsignarAbajo()
    {
        _abajoText.text = "pulsa una tecla...";
        _abajoText.fontSize = 30;
    }

    public void AsignarDerecha()
    {
        _derechaText.text = "pulsa una tecla...";
        _derechaText.fontSize = 30;
    }

    public void AsignarIzquierda()
    {
        _izquierdaText.text = "pulsa una tecla...";
        _izquierdaText.fontSize = 30;
    }

    public void AsignarPausa()
    {
        _pausaText.text = "pulsa una tecla...";
        _pausaText.fontSize = 30;
    }

    public void ControlMapping()
    {
        if (_arribaText.text == "pulsa una tecla...")
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    _arribaText.text = keyCode.ToString();
                    PlayerPrefs.SetString("Arriba", _arribaText.text);
                    _arribaText.fontSize = 50;
                    PlayerPrefs.Save();
                }
            }
        }

        if (_abajoText.text == "pulsa una tecla...")
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    _abajoText.text = keyCode.ToString();
                    PlayerPrefs.SetString("Abajo", _abajoText.text);
                    _abajoText.fontSize = 50;
                    PlayerPrefs.Save();
                }
            }
        }

        if (_derechaText.text == "pulsa una tecla...")
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    _derechaText.text = keyCode.ToString();
                    PlayerPrefs.SetString("Derecha", _derechaText.text);
                    _derechaText.fontSize = 50;
                    PlayerPrefs.Save();
                }
            }
        }

        if (_izquierdaText.text == "pulsa una tecla...")
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    _izquierdaText.text = keyCode.ToString();
                    PlayerPrefs.SetString("Izquierda", _izquierdaText.text);
                    _izquierdaText.fontSize = 50;
                    PlayerPrefs.Save();
                }
            }
        }

        if (_pausaText.text == "pulsa una tecla...")
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    _pausaText.text = keyCode.ToString();
                    PlayerPrefs.SetString("Pausa", _pausaText.text);
                    _pausaText.fontSize = 50;
                    PlayerPrefs.Save();
                }
            }
        }
    }
}
