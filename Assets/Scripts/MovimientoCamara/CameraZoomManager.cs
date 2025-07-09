using UnityEngine;
using UnityEngine.UI;

public class CameraZoomManager : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public float edgeThreshold = 200f;
    public float edgeMaxRotationX = 10f;
    public float edgeMaxRotationY = 15f;
    public float zoomRotateSpeed = 5f;

    public Image edgeGradientLeftImage;
    public Image edgeGradientRightImage;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float originalCamSize;

    private bool isInZoomMode = false;
    private ZoomTargetInfo currentZoomInfo;
    private float currentBackMoveSpeed;
    private float currentBackRotationSpeed;

    private EdgeScrollCamera edgeScroll;
    private EdgeRotateCamera edgeRotate;

    private void Start()
    {
        edgeScroll = GetComponent<EdgeScrollCamera>();
        edgeRotate = GetComponent<EdgeRotateCamera>();
        originalCamSize = Camera.main.orthographicSize;

        if (edgeGradientLeftImage != null) edgeGradientLeftImage.enabled = false;
        if (edgeGradientRightImage != null) edgeGradientRightImage.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("ZoomTarget") && !isInZoomMode)
                {
                    ZoomTargetInfo info = hit.collider.GetComponent<ZoomTargetInfo>();
                    if (info != null)
                    {
                        EnterZoomMode(info);
                    }
                }
            }
        }

        if (isInZoomMode && currentZoomInfo != null)
        {
            transform.position = Vector3.Lerp(transform.position, currentZoomInfo.targetPosition, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, currentZoomInfo.TargetRotation, rotateSpeed * Time.deltaTime);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, currentZoomInfo.targetSize, moveSpeed * Time.deltaTime);

            ApplyEdgeRotationWhileZoomed();
            CheckExitByMouseEdge();
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
        currentBackMoveSpeed = info.backMoveSpeed;
        currentBackRotationSpeed = info.backRotationSpeed;

        if (edgeScroll) edgeScroll.enabled = false;
        if (edgeRotate) edgeRotate.enabled = false;

        if (edgeGradientLeftImage != null) edgeGradientLeftImage.enabled = false;
        if (edgeGradientRightImage != null) edgeGradientRightImage.enabled = false;

        if (info.exitDirection == ZoomTargetInfo.ExitEdge.Left && edgeGradientLeftImage != null)
        {
            edgeGradientLeftImage.enabled = true;
        }
        else if (info.exitDirection == ZoomTargetInfo.ExitEdge.Right && edgeGradientRightImage != null)
        {
            edgeGradientRightImage.enabled = true;
        }
    }

    void ExitZoomMode()
    {
        isInZoomMode = false;

        if (edgeScroll) edgeScroll.enabled = true;
        if (edgeRotate) edgeRotate.enabled = true;

        if (edgeGradientLeftImage != null) edgeGradientLeftImage.enabled = false;
        if (edgeGradientRightImage != null) edgeGradientRightImage.enabled = false;

        StartCoroutine(SmoothReturnToFreeView());
        currentZoomInfo = null;
    }

    System.Collections.IEnumerator SmoothReturnToFreeView()
    {
        float tMove = 0f;
        float tRot = 0f;
        float startSize = Camera.main.orthographicSize;
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        while (tMove < 1f || tRot < 1f)
        {
            if (tMove < 1f)
            {
                tMove += Time.deltaTime * currentBackMoveSpeed;
                transform.position = Vector3.Lerp(startPos, originalPosition, tMove);
                Camera.main.orthographicSize = Mathf.Lerp(startSize, originalCamSize, tMove);
            }

            if (tRot < 1f)
            {
                tRot += Time.deltaTime * currentBackRotationSpeed;
                transform.rotation = Quaternion.Slerp(startRot, originalRotation, tRot);
            }

            yield return null;
        }
    }

    void CheckExitByMouseEdge()
    {
        float mouseX = Input.mousePosition.x;

        if (currentZoomInfo.exitDirection == ZoomTargetInfo.ExitEdge.Left && mouseX < 400f)
        {
            float intensity = Mathf.InverseLerp(400f, 50f, mouseX);
            SetGradientAlpha(intensity);

            if (mouseX <= 50f)
            {
                ExitZoomMode();
            }
        }
        else if (currentZoomInfo.exitDirection == ZoomTargetInfo.ExitEdge.Right && mouseX > Screen.width - 400f)
        {
            float intensity = Mathf.InverseLerp(Screen.width - 400f, Screen.width - 50f, mouseX);
            SetGradientAlpha(intensity);

            if (mouseX >= Screen.width - 50f)
            {
                ExitZoomMode();
            }
        }
        else
        {
            SetGradientAlpha(0f);
        }
    }

    void SetGradientAlpha(float alpha)
    {
        Image targetImage = currentZoomInfo.exitDirection == ZoomTargetInfo.ExitEdge.Left ? edgeGradientLeftImage : edgeGradientRightImage;

        if (targetImage != null)
        {
            Color color = targetImage.color;
            color.a = Mathf.Clamp01(alpha);
            targetImage.color = color;
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