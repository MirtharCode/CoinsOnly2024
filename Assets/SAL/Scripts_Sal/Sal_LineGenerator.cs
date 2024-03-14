using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Sal_LineGenerator : MonoBehaviour
{
    public GameObject lineGenerate;
    public GameObject Player;
    public float distanciaMinima = 1f; // Distancia mínima entre puntos para dibujar una nueva línea
    private Sal_Line Line;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Line = Instantiate(lineGenerate, Player.transform.position, Quaternion.identity).GetComponent<Sal_Line>();
    }

    private void Update()
    {
        if (Line != null && Player != null)
        {
            Vector3 playerPosition = Player.transform.position;
            Line.DibujarLinea(playerPosition, distanciaMinima);
        }
    }
}
