using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTimer : MonoBehaviour
{
    [SerializeField] public GameObject pM;
    void Start()
    {
        pM = GameObject.FindGameObjectWithTag("PM");
    }

    void Update()
    {
        
    }

    public void ActivarTemporizador()
    {
        pM.GetComponent<PilaManager>().tiempoActual = pM.GetComponent<PilaManager>().tiempoMaximo;
        pM.GetComponent<PilaManager>().slider.maxValue = pM.GetComponent<PilaManager>().tiempoMaximo;
        pM.GetComponent<PilaManager>().CambiarTemporizador(true);
        pM.GetComponent<PilaManager>().pila1.GetComponent<Pila>().enabled = true;
    }
}
