using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoCasa: MonoBehaviour
{

    [SerializeField] public VideoClip video;
    [SerializeField] public GameObject fTBObject;
    [SerializeField] public GameObject data;
    [SerializeField] public GameObject transicionesGameobject;
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void VideoShown()
    {
        data.GetComponent<Data>().videoVisto = true;
        data.GetComponent<Data>().videoActivo = false;
        data.GetComponent<Data>().sePueTocar = true;
        fTBObject.GetComponent<Image>().enabled = true;
        transicionesGameobject.GetComponent<Transiciones>().FTBRegular();
        //SceneManager.LoadScene("Day5");
    }
}
