using UnityEngine;

public class ScreenEffectFader : MonoBehaviour
{
    [Header("Material con el shader de efecto")]
    public Material effectMaterial;

    [Header("Tiempo de transición en segundos")]
    public float fadeDuration = 1.0f;

    [Header("Valor actual (0-1)")]
    [Range(0, 1)]
    public float currentAmount = 0f;

    private float targetAmount = 0f;
    private float fadeSpeed = 0f;
    private bool isFading = false;

    void Start()
    {
        // Inicializa el parámetro en el valor actual
        effectMaterial.SetFloat("_EffectAmount", currentAmount);
    }

    void Update()
    {
        if (isFading)
        {
            currentAmount = Mathf.MoveTowards(currentAmount, targetAmount, fadeSpeed * Time.deltaTime);
            effectMaterial.SetFloat("_EffectAmount", currentAmount);

            if (Mathf.Approximately(currentAmount, targetAmount))
            {
                isFading = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            FadeIn();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            FadeOut();
        }
    }

    //Empieza un fade in (0 -> 1)
    public void FadeIn()
    {
        StartFade(1f);
    }

    //Empieza un fade out (1 -> 0)
    public void FadeOut()
    {
        StartFade(0f);
    }

    /// <param name="target">0 o 1</param>
    private void StartFade(float target)
    {
        targetAmount = target;
        fadeSpeed = Mathf.Abs(currentAmount - targetAmount) / fadeDuration;
        isFading = true;
    }
}
