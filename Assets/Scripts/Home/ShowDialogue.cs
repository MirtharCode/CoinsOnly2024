using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    [SerializeField] public HomeManager hM;

    void Start()
    {
        hM = GameObject.FindGameObjectWithTag("HM").GetComponent<HomeManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WakingUpText()
    {
        hM.dialoguePanel.gameObject.SetActive(true);
    }

    public void MusicBegins()
    {
        if (gameObject.name.Contains("Giovanni"))
        {
            hM.musicBox.transform.GetChild(0).GetComponent<AudioSource>().mute = false;
            hM.musicBox.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(2).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(3).GetComponent<AudioSource>().mute = true;
        }

        else if (gameObject.name.Contains("Elidora"))
        {
            hM.musicBox.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
            hM.musicBox.transform.GetChild(2).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(3).GetComponent<AudioSource>().mute = true;
        }

        else if (gameObject.name.Contains("Manolo"))
        {
            hM.musicBox.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(2).GetComponent<AudioSource>().mute = false;
            hM.musicBox.transform.GetChild(3).GetComponent<AudioSource>().mute = true;
        }

        else if (gameObject.name.Contains("Tapicio"))
        {
            hM.musicBox.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(2).GetComponent<AudioSource>().mute = true;
            hM.musicBox.transform.GetChild(3).GetComponent<AudioSource>().mute = false;
        }
    }
}
