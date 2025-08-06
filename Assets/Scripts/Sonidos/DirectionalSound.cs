using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundUp;
    public AudioClip soundDown;
    public AudioClip soundLeft;
    public AudioClip soundRight;

    public float directionThreshold = 5f; 

    private bool isClicked = false;
    private bool isMouseOver = false;
    private Vector3 lastMousePosition;
    private string lastDirection = "";

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
                    lastDirection = ""; 
                }
            }
        }

        if (isClicked && isMouseOver && !audioSource.isPlaying)
        {
            Vector3 delta = currentMousePosition - lastMousePosition;

            if (delta.magnitude > directionThreshold)
            {
                string currentDirection = GetDirection(delta);

                if (currentDirection != lastDirection)
                {
                    PlayDirectionSound(currentDirection);
                    lastDirection = currentDirection;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) || !isMouseOver)
        {
            isClicked = false;
        }

        lastMousePosition = currentMousePosition;
    }

    string GetDirection(Vector3 delta)
    {
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            return delta.x > 0 ? "right" : "left";
        }
        else
        {
            return delta.y > 0 ? "up" : "down";
        }
    }

    void PlayDirectionSound(string direction)
    {
        if (audioSource == null) return;

        switch (direction)
        {
            case "up":
                if (soundUp) audioSource.PlayOneShot(soundUp);
                break;
            case "down":
                if (soundDown) audioSource.PlayOneShot(soundDown);
                break;
            case "left":
                if (soundLeft) audioSource.PlayOneShot(soundLeft);
                break;
            case "right":
                if (soundRight) audioSource.PlayOneShot(soundRight);
                break;
        }
    }
}

