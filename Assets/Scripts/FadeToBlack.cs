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

        if (currentScene.name == "MenuInicial")
            GetComponent<Animator>().SetTrigger("PumPum");
    }

    // Update is called once per frame
    void Update()
    {

    }
    // TRANSICI�N A NEGRO DEL MEN� AL PRIMER D�A
    public void FirstFadeToBlack()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);

        if (currentScene.name != "Home" || currentScene.name == "MenuInicial")
            Invoke(nameof(CallingFirstDay), fadeToblackClipTime);
    }

    public void CallingFirstDay()
    {
        SceneManager.LoadScene("Day1");
    }

    // TRANSICI�N A NEGRO DE LA TIENDA A CASA
    public void FadeToBlackAnywhere()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);

        if (currentScene.name != "Home" || currentScene.name == "MenuInicial")
            Invoke(nameof(CallingNextday), fadeToblackClipTime);
    }

    public void CallingNextday()
    {
        data.GetComponent<Data>().uIManager.GetComponent<UIManager>().NextDay();
    }

    // TRANSICI�N A NEGRO DE LOS FINALES A MEN� INICIAL
    public void LastFadeToBlack()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);
        Invoke(nameof(CallingMenu), fadeToblackClipTime);
    }
    public void CallingMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    // ENTRADA CLIENTE A CASA
    public void ClientEntrance()
    {
        if (currentScene.name == "Home")
            data.GetComponent<Data>().homeManager.SomeoneIsKnocking();
    }
}
