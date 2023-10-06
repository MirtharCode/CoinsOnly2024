using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputationSymbolFade : MonoBehaviour
{
    [SerializeField] Color puppetColor;
    // Start is called before the first frame update
    void Start()
    {
        puppetColor = transform.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.6f, 0);
        Fade(ref puppetColor.a);
        transform.GetComponent<Image>().color = puppetColor;
        Destroy(gameObject, 1);
    }

    void Fade(ref float alphaChannel)
    {
        alphaChannel -= 0.0025f;
    }
}
