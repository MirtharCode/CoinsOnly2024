using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SALSoonTransitions : MonoBehaviour
{
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite frame4;
    public Sprite frame5;

    [SerializeField] public TMP_Text soonText;
    [SerializeField] public GameObject SALIcon;
    [SerializeField] public GameObject pixelAntonio;

    void Start()
    {
        if (gameObject.name == "BG_SAL")
            StartCoroutine(nameof(FadeIn));
    }

    private IEnumerator FadeIn()
    {
        GetComponent<AudioSource>().volume = 0f;

        for (float t = 0; t < 5f; t += Time.deltaTime)
        {
            GetComponent<AudioSource>().volume = Mathf.Lerp(0f, .33f, t / 5f);
            yield return null;
        }

        GetComponent<AudioSource>().volume = 0.33f;
    }

    public void ActivarFadeOut()
    {
        StartCoroutine(nameof(FadeOut));
    }

    public IEnumerator FadeOut()
    {
        Debug.Log("Blabla");
        float startVolume = GetComponent<AudioSource>().volume;

        for (float t = 0; t < 7; t += Time.deltaTime)
        {
            GetComponent<AudioSource>().volume = Mathf.Lerp(startVolume, 0f, t / 7);
            yield return null;
        }

        GetComponent<AudioSource>().volume = 0f;
    }

    public void ChangingSprite1()
    {
        GetComponent<Image>().sprite = frame1;
    }

    public void ChangingSprite2()
    {
        GetComponent<Image>().sprite = frame2;
    }

    public void ChangingSprite3()
    {
        GetComponent<Image>().sprite = frame3;
    }

    public void ChangingSprite4()
    {
        GetComponent<Image>().sprite = frame4;
    }

    public void ChangingSprite5()
    {
        GetComponent<Image>().sprite = frame5;
    }

    public void ActivateAntonio_Icon()
    {
        GetComponent<Image>().enabled = false;
        SALIcon.SetActive(true);
        pixelAntonio.SetActive(true);
    }

    public void ActivateSoonText()
    {
        soonText.gameObject.SetActive(true);
        SALIcon.SetActive(false);
        pixelAntonio.SetActive(false);
    }


}
