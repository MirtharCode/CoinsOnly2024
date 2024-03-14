using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sal_Line : MonoBehaviour
{
    private LineRenderer line;
    private List<Vector3> puntos;
    private Vector3 ultimoPunto;
    private float zOffset = 0.1f; // Ajuste para controlar la posición Z de la línea abajo del jugador

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        puntos = new List<Vector3>();
    }

    public void DibujarLinea(Vector3 nuevaPosicion, float distanciaMinima)
    {
        if (Vector3.Distance(ultimoPunto, nuevaPosicion) >= distanciaMinima)
        {
            DibujarPunto(nuevaPosicion);
        }
    }

    private void DibujarPunto(Vector3 punto)
    {
        punto.z += zOffset; // Ajustar la posición Z para estar abajo del jugador
        puntos.Add(punto);
        line.positionCount = puntos.Count;
        line.SetPositions(puntos.ToArray());
        ultimoPunto = punto;
    }
}
