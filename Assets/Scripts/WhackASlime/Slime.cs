using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Vector2 startPosition = new Vector2 (0f, -2.56f);   // El 2.56 es porque el sprite es de 256 píxeles.
    private Vector2 endPosition = Vector2.zero;

    // Lo que tarda en mostrarse entero y luego en esconderse.
    private float showDuration = 0.5f;
    private float duration = 1f;

    void Start()
    {
        StartCoroutine(ShowHide(startPosition, endPosition))
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // Empezamos en el inicio
        transform.localPosition = start;

        // A mostrar el topo mi ciela
        float elapsed = 0f;

        while (elapsed < showDuration) 
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Acabamos en el final
        transform.localPosition = end;

        // Hacemos la esperación
        yield return new WaitForSeconds(duration);

        // Escondemos el slime
        elapsed = 0f;

        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        // Nos aseguramos que acabamos donde empezamos
        transform.localPosition = start;
    }
}
