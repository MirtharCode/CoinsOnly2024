using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ButtonRandom : MonoBehaviour
{
    public AudioSource audioSource;      
    public AudioClip[] clickSounds;     
    private int lastSoundIndex = -1;    

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlayRandomClickSound);
        }
    }

    void PlayRandomClickSound()
    {
        if (clickSounds.Length == 0 || audioSource == null)
            return;

        int index;
        do
        {
            index = Random.Range(0, clickSounds.Length);
        } while (clickSounds.Length > 1 && index == lastSoundIndex);

        audioSource.PlayOneShot(clickSounds[index]);
        lastSoundIndex = index;
    }
}
