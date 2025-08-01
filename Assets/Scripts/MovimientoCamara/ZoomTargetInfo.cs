using UnityEngine;

public class ZoomTargetInfo : MonoBehaviour
{
    [Header("Destino de la c�mara")]
    public Vector3 targetPosition;
    public Vector3 targetRotationEuler;

    [Header("Tama�o de c�mara si es ortogr�fica")]
    public float targetSize = 5f;

    [Header("Velocidades al volver")]
    public float backMoveSpeed = 5f;
    public float backRotationSpeed = 5f;

    [Header("Configuraci�n de salida")]
    public ExitEdge exitDirection = ExitEdge.Left;
    public enum ExitEdge
    {
        Left,
        Right
    }

    public Quaternion TargetRotation => Quaternion.Euler(targetRotationEuler);
}