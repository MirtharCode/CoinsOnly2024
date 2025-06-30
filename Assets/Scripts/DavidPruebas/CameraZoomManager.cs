using UnityEngine;

public class CameraZoomManager : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public float edgeThreshold = 200f;
    public float edgeMaxRotationX = 10f;
    public float edgeMaxRotationY = 15f;
    public float zoomRotateSpeed = 5f;
    public float backMoveSpeed = 5f;


    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float originalCamSize;

    private bool isInZoomMode = false;
    private ZoomTargetInfo currentZoomInfo;

    private EdgeScrollCamera edgeScroll;
    private EdgeRotateCamera edgeRotate;

    private void Start()
    {
        edgeScroll = GetComponent<EdgeScrollCamera>();
        edgeRotate = GetComponent<EdgeRotateCamera>();
        originalCamSize = Camera.main.orthographicSize;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("ZoomTarget") && isInZoomMode == false)
                {
                    ZoomTargetInfo info = hit.collider.GetComponent<ZoomTargetInfo>();
                    if (info != null)
                    {
                        EnterZoomMode(info);
                    }
                }
                else if (hit.collider.CompareTag("ReturnToFreeView") && isInZoomMode == true)
                {
                    ExitZoomMode();
                }
            }
        }

        if (isInZoomMode && currentZoomInfo != null)
        {
            // Mover y rotar suavemente hacia el objetivo
            transform.position = Vector3.Lerp(transform.position, currentZoomInfo.targetPosition, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, currentZoomInfo.TargetRotation, rotateSpeed * Time.deltaTime);

            // Zoom (solo si la cámara es ortográfica)
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, currentZoomInfo.targetSize, moveSpeed * Time.deltaTime);

            ApplyEdgeRotationWhileZoomed();
        }
    }

    void EnterZoomMode(ZoomTargetInfo info)
    {
        if (!isInZoomMode)
        {
            originalPosition = transform.position;
            originalRotation = transform.rotation;
            originalCamSize = Camera.main.orthographicSize;
        }

        isInZoomMode = true;
        currentZoomInfo = info;

        if (edgeScroll) edgeScroll.enabled = false;
        if (edgeRotate) edgeRotate.enabled = false;
    }

    void ExitZoomMode()
    {
        isInZoomMode = false;
        currentZoomInfo = null;

        if (edgeScroll) edgeScroll.enabled = true;
        if (edgeRotate) edgeRotate.enabled = true;

        StartCoroutine(SmoothReturnToFreeView());
    }

    System.Collections.IEnumerator SmoothReturnToFreeView()
    {
        float t = 0f;
        float startSize = Camera.main.orthographicSize;

        while (t < 1f)
        {
            t += Time.deltaTime * backMoveSpeed;
            transform.position = Vector3.Lerp(transform.position, originalPosition, t);
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, t);
            Camera.main.orthographicSize = Mathf.Lerp(startSize, originalCamSize, t);
            yield return null;
        }
    }

    void ApplyEdgeRotationWhileZoomed()
    {
        if (currentZoomInfo == null) return;

        Vector2 mousePos = Input.mousePosition;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float offsetX = 0f;
        float offsetY = 0f;

        if (mousePos.x <= edgeThreshold)
            offsetY = edgeMaxRotationY;
        else if (mousePos.x >= screenWidth - edgeThreshold)
            offsetY = -edgeMaxRotationY;

        if (mousePos.y <= edgeThreshold)
            offsetX = -edgeMaxRotationX;
        else if (mousePos.y >= screenHeight - edgeThreshold)
            offsetX = edgeMaxRotationX;

        Quaternion baseRotation = currentZoomInfo.TargetRotation;
        Quaternion targetRotation = baseRotation * Quaternion.Euler(offsetX, offsetY, 0f);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, zoomRotateSpeed * Time.deltaTime);
    }
}