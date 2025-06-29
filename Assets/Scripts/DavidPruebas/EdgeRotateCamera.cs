using UnityEngine;

public class EdgeRotateCamera : MonoBehaviour
{
    public float edgeThresholdPx = 200f;
    public float maxRotation = 15f;
    public float minRotateSpeed = 20f;
    public float maxRotateSpeed = 80f;
    public float returnSpeed = 100f;

    private float targetYRotation = 0f;
    private float currentYRotation = 0f;
    private bool returningToCenter = false;

    void Start()
    {
        currentYRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ReturnToCenter();
        }

        if (returningToCenter)
        {
            float distance = Mathf.Abs(Mathf.DeltaAngle(currentYRotation, 0f));
            float t = Mathf.Clamp01(distance / maxRotation); 
            float dynamicSpeed1 = Mathf.Lerp(minRotateSpeed, returnSpeed, t);
            currentYRotation = Mathf.MoveTowardsAngle(currentYRotation, 0f, dynamicSpeed1 * Time.deltaTime);
            ApplyRotation();

            if (distance < 0.1f)
            {
                returningToCenter = false;
                targetYRotation = 0f;
            }

            return;
        }

        Vector3 mousePos = Input.mousePosition;
        float screenWidth = Screen.width;

        int direction = 0;
        float dynamicSpeed = 0f;

        if (mousePos.x <= edgeThresholdPx)
        {
            float depth = (edgeThresholdPx - mousePos.x) / edgeThresholdPx;
            dynamicSpeed = Mathf.Lerp(minRotateSpeed, maxRotateSpeed, depth);
            direction = -1;
        }
        else if (mousePos.x >= screenWidth - edgeThresholdPx)
        {
            float depth = (mousePos.x - (screenWidth - edgeThresholdPx)) / edgeThresholdPx;
            dynamicSpeed = Mathf.Lerp(minRotateSpeed, maxRotateSpeed, depth);
            direction = 1;
        }

        if (direction != 0)
        {
            targetYRotation += direction * dynamicSpeed * Time.deltaTime;
            targetYRotation = Mathf.Clamp(targetYRotation, -maxRotation, maxRotation);
        }

        float angleDiff = Mathf.Abs(Mathf.DeltaAngle(currentYRotation, targetYRotation));
        float lerpSpeed = Mathf.Lerp(minRotateSpeed, maxRotateSpeed, angleDiff / maxRotation);
        currentYRotation = Mathf.MoveTowardsAngle(currentYRotation, targetYRotation, lerpSpeed * Time.deltaTime);
        ApplyRotation();
    }

    void ApplyRotation()
    {
        Vector3 euler = transform.eulerAngles;
        euler.y = currentYRotation;
        transform.eulerAngles = euler;
    }

    public void ReturnToCenter()
    {
        returningToCenter = true;
    }
}