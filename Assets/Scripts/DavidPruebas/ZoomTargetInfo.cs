using UnityEngine;

public class ZoomTargetInfo : MonoBehaviour
{
    [Header("Destino de la cámara")]
    public Vector3 targetPosition;
    public Vector3 targetRotationEuler;

    [Header("Tamaño de cámara si es ortográfica")]
    public float targetSize = 5f;

    [Header("Velocidades al volver")]
    public float backMoveSpeed = 5f;
    public float backRotationSpeed = 5f;

    [Header("Configuración de salida")]
    public ExitEdge exitDirection = ExitEdge.Left;
    public enum ExitEdge
    {
        Left,
        Right
    }

    public Quaternion TargetRotation => Quaternion.Euler(targetRotationEuler);
}