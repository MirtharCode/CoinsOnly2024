using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class BegginingCinematicEnd : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    [Header("Cámara a animar")]
    public Camera targetCamera;

    [Header("Objetivos de tamaño/FOV")]
    public float midSize = 5.5f;
    public float endSize = 0.1f;

    [Header("Tiempos y velocidades")]
    public float smoothTimeToMid = 0.8f; // suavizado hacia 5.5
    public float speedToEnd = 1f;        // velocidad lineal hacia 0.1

    private bool startedSequence = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (targetCamera == null)
            targetCamera = Camera.main;

        if (videoPlayer != null)
            videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }

    void Update()
    {
        if (!startedSequence && videoPlayer != null && !videoPlayer.isPlaying && videoPlayer.frame > 0)
        {
            OnVideoFinished(videoPlayer);
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        if (startedSequence) return;
        startedSequence = true;
        StartCoroutine(CameraSequenceThenLoad());
    }

    private IEnumerator CameraSequenceThenLoad()
    {
        if (targetCamera == null)
        {
            Debug.LogWarning("No hay cámara asignada. Cargando escena sin animación.");
            SceneManager.LoadScene("SavedSlots");
            yield break;
        }

        if (targetCamera.orthographic)
        {
            float velocity = 2f;

            while (Mathf.Abs(targetCamera.orthographicSize - midSize) > 0.01f)
            {
                targetCamera.orthographicSize = Mathf.SmoothDamp(
                    targetCamera.orthographicSize, midSize, ref velocity, smoothTimeToMid);
                yield return null;
            }
            targetCamera.orthographicSize = midSize;

            while (targetCamera.orthographicSize > endSize)
            {
                targetCamera.orthographicSize -= Time.deltaTime * speedToEnd;
                yield return null;
            }
            targetCamera.orthographicSize = endSize;
        }
        else
        {
            float velocity = 1.5f;

            while (Mathf.Abs(targetCamera.fieldOfView - midSize) > 0.01f)
            {
                targetCamera.fieldOfView = Mathf.SmoothDamp(
                    targetCamera.fieldOfView, midSize, ref velocity, smoothTimeToMid);
                yield return null;
            }
            targetCamera.fieldOfView = midSize;

            while (targetCamera.fieldOfView > endSize)
            {
                targetCamera.fieldOfView -= Time.deltaTime * speedToEnd * 10f;
                yield return null;
            }
            targetCamera.fieldOfView = endSize;
        }

        SceneManager.LoadScene("SavedSlots");
    }
}