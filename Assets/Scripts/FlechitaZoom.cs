using UnityEngine;

public class FlechitaZoom : MonoBehaviour
{
    private Animator animator;
    private bool animacionReproducida = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        if (!animacionReproducida)
        {
            animator.SetTrigger("FlechitaGrande");
            animacionReproducida = true;
        }
    }

    void OnDisable()
    {
        animacionReproducida = false;
    }
}
