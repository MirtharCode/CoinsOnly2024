using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotitoPersonajeMenu : MonoBehaviour
{
    public Sprite[] sprites;


    void Start()
    {
        int randomIndex = Random.Range(0, sprites.Length);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[randomIndex];

    }

    void Update()
    {
        
    }
}
