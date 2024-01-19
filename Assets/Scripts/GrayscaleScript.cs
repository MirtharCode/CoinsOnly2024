using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class GrayscaleScript : UIManager
{

    private Image image;
    private float duration = 1f;

    void Start()
    {
        image = GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError("No se encontró el componente Image en el objeto " + gameObject.name);
        }
    }

    public void StartGrayscaleRoutine()
    {
        if(currentCustomer.name.Contains("Detective"))
            StartCoroutine(GrayscaleRoutine(duration, true));
    }

    public void Reset()
    {
        StartCoroutine(GrayscaleRoutine(duration, false));
    }

    public IEnumerator GrayscaleRoutine(float duration, bool isGrayscale)
    {
        float time = 0;

        while (duration > time)
        {
            float durationFrame = Time.deltaTime;
            float ratio = time / duration;
            float grayAmount = isGrayscale
            ? ratio
            : 1 - ratio;
            SetGrayscale(grayAmount);
            time += durationFrame;
            yield return null;
        }
        SetGrayscale( isGrayscale? 1 : 0);
    }

    public void SetGrayscale(float amount = 1)
    {
        // Verifica si el componente Image es nulo antes de intentar acceder a su material
        if (image != null)
        {
            image.material.SetFloat("_EffectAmount", amount);
        }
        else
        {
            Debug.LogError("No se puede establecer la escala de grises. El componente Image es nulo.");
        }
    }
}
