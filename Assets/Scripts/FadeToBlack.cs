using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] public GameObject data;
    [SerializeField] public AnimationClip fadeToblackClip;
    [SerializeField] public float fadeToblackClipTime;
    [SerializeField] public Scene currentScene;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
        fadeToblackClipTime = fadeToblackClip.length;
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeToBlackAnywhere()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);

        if (currentScene.name != "Home")
            Invoke(nameof(CallingNextday), fadeToblackClipTime);
    }

    public void ClientEntrance()
    {
        if (currentScene.name == "Home")
            data.GetComponent<Data>().homeManager.SomeoneIsKnocking();
    }

    public void CallingNextday()
    {
        data.GetComponent<Data>().uIManager.GetComponent<UIManager>().NextDay();
    }
}
