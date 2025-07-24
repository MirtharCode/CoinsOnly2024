using UnityEngine;
using System.Collections;

public class TabletMover : MonoBehaviour
{
    public Transform tablet;               //Aqui se pone el objeto padre
    public float maxMoveDistance = 4f;     //Lo que se mueve
    public float mouseSensitivity = 0.01f; //Y la velocidad a la que se mueve

    private Vector3 initialPosition;
    private float currentOffsetY = 0f;
    private bool isDragging = false;
    private float lastMouseY;
    private bool canDrag = true;

    public GameObject tabletMover;

    void Start()
    {
        CogerPosicionTablet();
    }

    void Update()
    {
        if (!canDrag) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.transform == tabletMover.transform)
                {
                    Debug.Log("Click detectado en el collider hijo");
                    isDragging = true;
                    lastMouseY = Input.mousePosition.y;
                }
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            float deltaY = Input.mousePosition.y - lastMouseY;
            lastMouseY = Input.mousePosition.y;

            float moveAmount = deltaY * mouseSensitivity;
            currentOffsetY = Mathf.Clamp(currentOffsetY + moveAmount, 0f, maxMoveDistance);

            Vector3 targetPosition = initialPosition + Vector3.up * currentOffsetY;
            tablet.position = targetPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    public void CogerPosicionTablet() 
    {
        initialPosition = tablet.position;
    }

    public void BloquearMovimiento() //CUANDO SE VAYA A COBRAR A UN CLIENTE, SE ACTIVA ESTO
    {
        canDrag = false;
        isDragging = false;
        currentOffsetY = 0f;

        //Mover hacia abajo
        StopAllCoroutines();
        StartCoroutine(MoverTabletSuavemente(initialPosition - Vector3.up * 2f));

        StartCoroutine(ReactivarMovimientoDespues(1f));
    }

    public void BloquearMovimientoTutorial() //CUANDO SE HAGA EL TUTORIAL DE LA TABLET, SE LLAMA AQUI
    {
        canDrag = false;
        isDragging = false;
        currentOffsetY = 0f;

        //Mover hacia abajo
        StopAllCoroutines();
        StartCoroutine(MoverTabletSuavemente(initialPosition));

        StartCoroutine(ReactivarMovimientoDespues(1f));
    }

    private IEnumerator ReactivarMovimientoDespues(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        canDrag = true;
    }

    public void ActivarMovimiento() //CUANDO SE TERMINE DE COBRAR AL CLIENTE, SE ACTIVA ESTA OPCIÓN
    {
        canDrag = true;

        // Mover hacia arriba
        StopAllCoroutines();
        Debug.Log("Sube :(");
        StartCoroutine(MoverTabletSuavemente(initialPosition));
    }

    private IEnumerator MoverTabletSuavemente(Vector3 destino)
    {
        float duracion = 0.5f; 
        float tiempo = 0f;

        Vector3 inicio = tablet.position;

        while (tiempo < duracion)
        {
            tablet.position = Vector3.Lerp(inicio, destino, tiempo / duracion);
            tiempo += Time.deltaTime;
            yield return null;
        }

        tablet.position = destino; 
    }

    public void ByeByeAnimator() //ESTO ES PARA EL DIA 1
    {
        Invoke(nameof(ByeBye),0.2f);
        initialPosition = tablet.position - Vector3.up * 3.6f;
        currentOffsetY = 3.6f;
    }

    public void ByeBye()
    {
        GetComponent<Animator>().enabled = false;
    }
}