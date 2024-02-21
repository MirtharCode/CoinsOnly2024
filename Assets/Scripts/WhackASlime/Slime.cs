using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private Sprite slime;
    [SerializeField] private Sprite slimeMagicHat;
    [SerializeField] private Sprite slimeMagicHatBroken;
    [SerializeField] private Sprite slimeHit;
    [SerializeField] private Sprite slimeMagicHatHit;
    [SerializeField] private Sprite elidora;

    [SerializeField] private SlimeManager sM;

    private Vector2 startPosition = new Vector2(0f, -2.56f);   // El 2.56 es porque el sprite es de 256 píxeles.
    private Vector2 endPosition = Vector2.zero;

    // Lo que tarda en mostrarse entero y luego en esconderse.
    private float showDuration = 0.5f;
    private float duration = 1f;

    private SpriteRenderer sR;
    private BoxCollider2D bC2D;
    private Vector2 boxOffset;
    private Vector2 boxSize;
    private Vector2 boxOffsetHidden;
    private Vector2 boxSizeHidden;

    private bool hittable = true;

    public enum SlimeType { Standard, MagicHat, Elidora };
    private SlimeType slimeType;
    private float magicHatRate = 0.25f;
    private float elidoraRate = 0f;
    private int lives;
    private int slimeIndex = 0;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
        bC2D = GetComponent<BoxCollider2D>();
        boxOffset = bC2D.offset;
        boxSize = bC2D.size;
        boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f);
        boxSizeHidden = new Vector2(boxSize.x, 0f);
    }

    void Start()
    {
        sM = GameObject.FindGameObjectWithTag("SM").GetComponent<SlimeManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (hittable)
        {
            switch (slimeType)
            {
                case SlimeType.Standard:
                    sR.sprite = slimeHit;
                    sM.AddScore(slimeIndex);
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());
                    hittable = false;
                    break;
                case SlimeType.MagicHat:

                    if (lives == 2)
                    {
                        sR.sprite = slimeMagicHatBroken;
                        lives--;
                    }

                    else
                    {
                        sR.sprite = slimeMagicHatHit;
                        sM.AddScore(slimeIndex);
                        StopAllCoroutines();
                        StartCoroutine(QuickHide());
                        hittable = false;
                    }
                    break;
                case SlimeType.Elidora:
                    sM.GameOver(1);
                    break;
                default:
                    break;
            }
            sR.sprite = slimeHit;
            StopAllCoroutines();
            StartCoroutine(QuickHide());

            hittable = false;
        }

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
            bC2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);
            bC2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Acabamos en el final
        transform.localPosition = end;
        bC2D.offset = boxOffset;
        bC2D.size = boxSize;

        // Hacemos la esperación
        yield return new WaitForSeconds(duration);

        // Escondemos el slime
        elapsed = 0f;

        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            bC2D.offset = Vector2.Lerp(boxOffset, boxOffsetHidden, elapsed / showDuration);
            bC2D.size = Vector2.Lerp(boxSize, boxSizeHidden, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        // Nos aseguramos que acabamos donde empezamos
        transform.localPosition = start;
        bC2D.offset = boxOffsetHidden;
        bC2D.size = boxSizeHidden;

        if (hittable)
        {
            hittable = false;

            sM.Missed(slimeIndex, slimeType != SlimeType.Elidora);
        }
    }

    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);

        if (!hittable) Hide();
    }

    public void Hide()
    {
        transform.localPosition = startPosition;
        bC2D.offset = boxOffsetHidden;
        bC2D.size = boxSizeHidden;
    }

    private void CreateNext()
    {
        float random = Random.Range(0f, 1f);
        if (random < elidoraRate)
        {
            Debug.Log("Soy la maguita");
            slimeType = SlimeType.Elidora;
            sR.sprite = elidora;
        }
        else
        {
            if (random < magicHatRate)
            {
                Debug.Log("Tengo Sombrero");
                slimeType = SlimeType.MagicHat;
                sR.sprite = slimeMagicHat;
                lives = 2;
            }

            else
            {
                Debug.Log("Soy normal");
                slimeType = SlimeType.Standard;
                sR.sprite = slime;
                lives = 1;
            }
        }

        hittable = true;
    }

    private void SetLevel(int level)
    {
        elidoraRate = Mathf.Min(level * 0.025f, 0.25f); // En el nivel 10 será de 0.25
        magicHatRate = Mathf.Min(level * 0.025f, 1f);   // En el nivel 40 será del 100%

        float durationMin = Mathf.Clamp(1 - level * 0.1f, 0.01f, 1f);
        float durationMax = Mathf.Clamp(2 - level * 0.1f, 0.01f, 2f);

        duration = Random.Range(durationMin, durationMax);
    }

    public void Activate(int level)
    {
        Debug.Log(level);
        SetLevel(level);
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    public void SetIndex(int index)
    {
        slimeIndex = index;
    }
}
