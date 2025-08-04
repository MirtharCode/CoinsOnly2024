using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class InitialCinematicEnd : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (!videoPlayer.isPlaying && videoPlayer.frame > 0)
        {
            Debug.Log("Vídeo detenido manualmente. Cargando escena...");
            SceneManager.LoadScene("Day");
        }
    }
}
