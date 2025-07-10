using UnityEngine;

public class EdgeScrollCamera : MonoBehaviour
{
    public float edgeThresholdPx = 200f;    //Es en cada dirección (izq o drch) en que posición pongo el raton
    public float extraScrollUnits = 3f;     //Es la distancia max a la que puedo moverme en cada lado (3unit = 300px) 
    public float minScrollSpeed = 1f;       //Minima velocidad a la que puede moverse la camara
    public float maxScrollSpeed = 5f;       //Maxima velocidad a la que puede moverse la camara
    public float returnSpeed = 6f;          //Velocidad a volver al punto de inicio

    private Vector3 initialPosition;
    private float targetOffsetX = 0f;
    private bool returningToCenter = false;

    void Start()
    {
        initialPosition = transform.position; //esto es para sacar la posición inicial de la camara
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ReturnToCenter();   // Llamarlo cuando caiga el cliente
        }
        if (returningToCenter)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
            {
                returningToCenter = false; // Ponerlo donde quiera que se desbloquee la fijación al centro
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
            float depth = (edgeThresholdPx - mousePos.x) / edgeThresholdPx; //Calculo de que tan cerca está el ratón de un lado u otro
            dynamicSpeed = Mathf.Lerp(minScrollSpeed, maxScrollSpeed, depth); //Y calculo la velocidad que debería tener
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

        //Muevo lentamente la cámara
        Vector3 targetPosition = new Vector3(initialPosition.x + targetOffsetX, initialPosition.y, initialPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxScrollSpeed * Time.deltaTime);

    }

    //Volver al centro
    public void ReturnToCenter()
    {
        returningToCenter = true;
    }
}