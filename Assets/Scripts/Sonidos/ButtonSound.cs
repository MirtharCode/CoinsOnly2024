using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{

    public AudioClip hoverSound;
    public AudioClip clickSound;
    public AudioSource audioSource;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && audioSource != null)
            audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null && audioSource != null && Data.instance.sePueTocar)
        {
            audioSource.PlayOneShot(clickSound);
            GetComponent<Animator>().SetTrigger("Sleep");
        }
            
    }
}
