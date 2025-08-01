using UnityEngine;

public class EdgeScrollCamera : MonoBehaviour
{
    public float edgeThresholdPx = 200f;    //Es en cada direcci�n (izq o drch) en que posici�n pongo el raton
    public float extraScrollUnits = 3f;     //Es la distancia max a la que puedo moverme en cada lado (3unit = 300px) 
    public float minScrollSpeed = 1f;       //Minima velocidad a la que puede moverse la camara
    public float maxScrollSpeed = 5f;       //Maxima velocidad a la que puede moverse la camara
    public float returnSpeed = 6f;          //Velocidad a volver al punto de inicio

    private Vector3 initialPosition;
    private float targetOffsetX = 0f;
    private bool returningToCenter = true;

    void Start()
    {
        initialPosition = transform.position; //esto es para sacar la posici�n inicial de la camara
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReturnToCenter();   // Llamarlo cuando caiga el cliente y vuelva a hablar el cliente
        } 
        if (Input.GetKeyDown(KeyCode.J))
        {
            ReturnToMove();   // Llamarlo cuando deje de hablar el cliente
        }
        if (returningToCenter)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
            {
                targetOffsetX = 0f;
            }
            return;  
        }
        Vector3 mousePos = Input.mousePosition;
        float screenWidth = Screen.width;

        int direction = 0;
        float dynamicSpeed = 0f;

        if (mousePos.x <= edgeThresholdPx)
        {
            //IZQ
            float depth = (edgeThresholdPx - mousePos.x) / edgeThresholdPx; //Calculo de que tan cerca est� el rat�n de un lado u otro
            dynamicSpeed = Mathf.Lerp(minScrollSpeed, maxScrollSpeed, depth); //Y calculo la velocidad que deber�a tener
            direction = -1;
        }
        else if (mousePos.x >= screenWidth - edgeThresholdPx)
        {
            //DRCH
            float depth = (mousePos.x - (screenWidth - edgeThresholdPx)) / edgeThresholdPx;
            dynamicSpeed = Mathf.Lerp(minScrollSpeed, maxScrollSpeed, depth);
            direction = 1;
        }

        //Actualizo el movimiento de la camara
        if (direction != 0)
        {
            targetOffsetX += direction * dynamicSpeed * Time.deltaTime;
            targetOffsetX = Mathf.Clamp(targetOffsetX, -extraScrollUnits, extraScrollUnits);
        }

        //Muevo lentamente la c�mara
        Vector3 targetPosition = new Vector3(initialPosition.x + targetOffsetX, initialPosition.y, initialPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxScrollSpeed * Time.deltaTime);

    }

    //Volver al centro
    public void ReturnToCenter()
    {
        returningToCenter = true;
    }
    public void ReturnToMove()
    {
        returningToCenter = false;
    }

    public void TurnOffAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }

    public void TurnOnDialogueCollider()
    {
        DialogueManager.Instance.dialoguePanelFirstCollider.GetComponent<BoxCollider>().enabled = true;
    }
}