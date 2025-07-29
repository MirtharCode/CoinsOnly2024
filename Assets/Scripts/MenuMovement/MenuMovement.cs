using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuMovement : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform cameraTargetPosition;        
    public float cameraMoveDuration = 2f;
    public float cameraReturnDuration = 2f;

    [Header("Fade Object")]
    public RawImage fadeImage;                   
    public float fadeInDelay = 0f;
    public float fadeInDuration = 1f;
    public float fadeOutDelay = 0f;
    public float fadeOutDuration = 1f;

    [Header("Activatable Object")]
    public GameObject objectToToggle;
    public float activateDelay = 0f;
    public float deactivateDelay = 0f;

    private Vector3 cameraInitialPosition;
    private Coroutine activeRoutine;

    void Start()
    {
        if (Camera.main != null)
            cameraInitialPosition = Camera.main.transform.position;
    }

    public void TriggerSequence()
    {
        if (activeRoutine != null) StopCoroutine(activeRoutine);
        activeRoutine = StartCoroutine(Sequence(true));
    }

    public void ReverseSequence()
    {
        if (activeRoutine != null) StopCoroutine(activeRoutine);
        activeRoutine = StartCoroutine(Sequence(false));
    }

    IEnumerator Sequence(bool forward)
    {
        if (forward)
        {
            StartCoroutine(MoveCamera(Camera.main.transform.position, cameraTargetPosition.position, cameraMoveDuration));
            yield return new WaitForSeconds(activateDelay);
            if (objectToToggle != null) objectToToggle.SetActive(true);
            yield return new WaitForSeconds(fadeInDelay);
            StartCoroutine(FadeUI(0f, 1f, fadeInDuration));
        }
        else
        {
            StartCoroutine(MoveCamera(Camera.main.transform.position, cameraInitialPosition, cameraReturnDuration));
            yield return new WaitForSeconds(fadeOutDelay);
            StartCoroutine(FadeUI(1f, 0f, fadeOutDuration));
            yield return new WaitForSeconds(deactivateDelay);
            if (objectToToggle != null) objectToToggle.SetActive(false);
        }
    }

    IEnumerator MoveCamera(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            Camera.main.transform.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = to;
    }

    IEnumerator FadeUI(float from, float to, float duration)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;
        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(from, to, elapsed / duration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, to);
    }
}

