using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clickSounds;

    private int lastSoundIndex = -1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    PlayRandomClickSound();
                }
            }
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
