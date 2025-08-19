using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuReferences : MonoBehaviour
{
    public GameObject playButton;
    public GameObject minigamesButton;
    public GameObject optionsButton;
    public GameObject creditsButton;
    public GameObject exitButton;
    public GameObject languageButton;
    public GameObject musicTextContainer;
    public GameObject muteTextContainer;

    private void Start()
    {
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.SetMenuReferences(playButton, minigamesButton, optionsButton, creditsButton, exitButton, languageButton, musicTextContainer, muteTextContainer);
        }
    }
}
