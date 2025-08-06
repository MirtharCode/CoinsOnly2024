using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMoveSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] moveSounds;
    public float delayBetweenSounds = 0.1f;

    private int lastSoundIndex = -1;
    private bool isClicked = false;
    private bool isMouseOver = false;
    private Vector3 lastMousePosition;
    private float lastSoundTime;

    void Update()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(currentMousePosition);
        RaycastHit hit;

        isMouseOver = false;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                isMouseOver = true;

                if (Input.GetMouseButtonDown(0))
                {
                    isClicked = true;
                }
            }
        }

        if (isClicked && isMouseOver && MouseMoved(currentMousePosition))
        {
            if (Time.time - lastSoundTime > delayBetweenSounds)
            {
                PlayRandomMoveSound();
                lastSoundTime = Time.time;
            }
        }

        if (Input.GetMouseButtonUp(0) || !isMouseOver)
        {
            isClicked = false;
        }

        lastMousePosition = currentMousePosition;
    }

    bool MouseMoved(Vector3 currentMousePosition)
    {
        return currentMousePosition != lastMousePosition;
    }

    void PlayRandomMoveSound()
    {
        if (moveSounds.Length == 0 || audioSource == null)
            return;

        int index;
        do
        {
            index = Random.Range(0, moveSounds.Length);
        } while (moveSounds.Length > 1 && index == lastSoundIndex);

        audioSource.PlayOneShot(moveSounds[index]);
        lastSoundIndex = index;
    }
}