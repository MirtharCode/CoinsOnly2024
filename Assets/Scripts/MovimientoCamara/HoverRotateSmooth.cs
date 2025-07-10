using UnityEngine;

public class HoverRotateSmooth : MonoBehaviour
{
    [Header("Rotación relativa al original")]
    public Vector3 rotationOffset = new Vector3(0, 180, 0); // Valores que se suman a la rotación original

    public float rotationSpeed = 5f;

    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private bool isHovered = false;

    private CameraZoomManager zoomManager;

    void Start()
    {
        originalRotation = transform.rotation;
        targetRotation = originalRotation;

        zoomManager = FindObjectOfType<CameraZoomManager>();
        if (zoomManager == null)
        {
            Debug.LogError("CameraZoomManager no encontrado en la escena.");
        }
    }

    void Update()
    {
        DetectHover();

        // Si no hay hover o estamos en zoom, volver a la rotación original
        if (!isHovered || (zoomManager != null && zoomManager.isInZoomMode))
        {
            targetRotation = originalRotation;
        }

        // Rotación suave
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void DetectHover()
    {
        if (zoomManager != null && zoomManager.isInZoomMode)
        {
            isHovered = false;
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                if (!isHovered)
                {
                    isHovered = true;

                    // Sumar rotación relativa
                    Vector3 newEuler = originalRotation.eulerAngles + rotationOffset;
                    targetRotation = Quaternion.Euler(newEuler);
                }
                return;
            }
        }

        isHovered = false;
    }
}