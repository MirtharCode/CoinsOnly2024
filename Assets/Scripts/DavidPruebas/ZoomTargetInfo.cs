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

    public Quaternion TargetRotation => Quaternion.Euler(targetRotationEuler);
}