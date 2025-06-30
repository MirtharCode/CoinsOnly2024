using UnityEngine;

public class ZoomTargetInfo : MonoBehaviour
{
    [Header("Destino de la c�mara")]
    public Vector3 targetPosition;
    public Vector3 targetRotationEuler;

    [Header("Tama�o de c�mara si es ortogr�fica")]
    public float targetSize = 5f;

    public Quaternion TargetRotation => Quaternion.Euler(targetRotationEuler);
}
