using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sal_Jugador : MonoBehaviour
{
    // Variables que necesita MOVE
    private Vector3 dir;
    public int infoDir;                 // Variable para saber en que dirección esta mirando el personaje
    public Vector3 destination;

    public float speed, delay;          // RELLENABLE EN EDITOR EN CADA NIVEL CON VALORES DE 2 y 0.06 RESPECTIVAMENTE.
    private float[] walking;
    private Animator ani;
    public RaycastHit2D hitObstaculo, hitBarro;  // Nos da la información de lo que detecte el Raycast
    public LayerMask obstacle, mud;     // RELLENABLE EN EDITOR EN CADA NIVEL.
    private Vector3 resbalar;
    public GameObject canvasMessage;
    public GameObject[] totalPaharos;

    public AudioSource snailDeath;

    public string _arriba, _abajo, _izquierda, _derecha, _pausa;

    [SerializeField] public Sal_GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        totalPaharos = GameObject.FindGameObjectsWithTag("Bird");   // Al iniciar, relleno el array con las que tengan tag Grass.
        dir = new Vector2(0, 0);                                // Inicializo el Vector que me va a señalar la dirección a la que me muevo.
        ani = GetComponent<Animator>();                         // Inicializo el animator de Anacleto.
        walking = new float[4];                                 // Inicializo el array para que tenga 4 huecos.
        destination = transform.position;                       // Le digo que mi destino al iniciar el juego es donde estoy colocado.

        //PlayerPrefs.DeleteAll();

        _arriba = PlayerPrefs.GetString("Arriba");

        if (PlayerPrefs.GetString("Arriba") == "")
        {
            PlayerPrefs.SetString("Arriba", KeyCode.W.ToString());
            _arriba = PlayerPrefs.GetString("Arriba");
            PlayerPrefs.Save();
        }
        _arriba = PlayerPrefs.GetString("Arriba");

        if (PlayerPrefs.GetString("Abajo") == "")
        {
            PlayerPrefs.SetString("Abajo", KeyCode.S.ToString());
            _abajo = PlayerPrefs.GetString("Abajo");
            PlayerPrefs.Save();
        }
        _abajo = PlayerPrefs.GetString("Abajo");

        if (PlayerPrefs.GetString("Izquierda") == "")
        {
            PlayerPrefs.SetString("Izquierda", KeyCode.A.ToString());
            _izquierda = PlayerPrefs.GetString("Izquierda");
            PlayerPrefs.Save();
        }
        _izquierda = PlayerPrefs.GetString("Izquierda");

        if (PlayerPrefs.GetString("Derecha") == "")
        {
            PlayerPrefs.SetString("Derecha", KeyCode.D.ToString());
            _derecha = PlayerPrefs.GetString("Derecha");
            PlayerPrefs.Save();
        }
        _derecha = PlayerPrefs.GetString("Derecha");

        if (PlayerPrefs.GetString("Pausa") == "")
        {
            PlayerPrefs.SetString("Pausa", KeyCode.Escape.ToString());
            _pausa = PlayerPrefs.GetString("Pausa");
            PlayerPrefs.Save();
        }
        _pausa = PlayerPrefs.GetString("Pausa");

        gM = GameObject.FindGameObjectWithTag("GM").GetComponent<Sal_GameManager>();
    }

    void Update()
    {
        //print("El barro es " + CheckMud());
        //print("La colisión es " + CheckCollision());
        MoveBarro();
    }

    private void OnGUI()
    {
        Move_();
        Pausa();
    }

    // Booleano que va a ser afirmativo cuando el Raycast choque contra
    // algo que esté en la capa obstáculo (es decir, un obstáculo).
    public bool CheckCollision()
    {
        // Coge información de lo que el rayo de tamaño 1 que sale del centro del personaje toque en la capa obstacle.
        hitObstaculo = Physics2D.Raycast(transform.position, dir, 1, obstacle);

        // Da un valor positivo si no es nulo, es decir, si ha detectado algo.
        if (hitObstaculo.collider != null)
            return true;
        else
            return false;
    }

    // Booleano que va a ser afirmativo cuando el Raycast choque contra
    // algo que esté en la capa mud (es decir, contra una casilla de barro).
    public bool CheckMud()
    {
        // Coge información de lo que el rayo de tamaño 1 que sale del centro del personaje toque en la capa obstacle.
        hitBarro = Physics2D.Raycast(transform.position, dir, 1, mud);

        // Da un valor positivo si no es nulo, es decir, si ha detectado algo.
        if (hitBarro.transform.tag == "Mud")
            return true;
        else
            return false;
    }

    // Esto simplemente sirve para ver dibujado el rayo en el modo editor.
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, dir);
    }

    // Función que nos permite movernos de casilla en casilla.
    public void Move_()
    {
        // Si mi posición actual es igual a mi última destination (es decir, estoy parado) y pulso la tecla W...
        if (Event.current.Equals(Event.KeyboardEvent(_arriba)) && transform.position == destination)
        {
            dir = new Vector2(0, 1);            // ... le digo que dir ahora vale uno hacia arriba...
            walking[0] += 1 * Time.deltaTime;   // ... le asigno un valor que siempre será mayor que 0.06...
            infoDir = 0;                        // ... y le digo a mi chivato de direcciones que me estoy moviendo hacia arriba.


            // Luego, solo si estoy parado (mi destino es donde me encuentro)...
            if (transform.position == destination)
            {
                //ani.SetFloat("movX", 0);
                //ani.SetFloat("movY", 1);

                // ...y además no tengo obstáculo delante y el valor que le di antes es mayor que 0.06 (spoiler, siempre lo va a ser)...
                if (!CheckCollision() && walking[0] > delay)
                {
                    //ani.SetBool("walk", true);
                    if (totalPaharos.Length > 0)
                        for (int i = 0; i < totalPaharos.Length; i++)
                            // ...hago que en caso que haya pájaro, se mueve una casilla al ser su booleano true.
                            totalPaharos[i].GetComponent<Sal_Bird>().paharoMoving = true;

                    destination += dir;                                         // ...hago que la destination sea ahora donde estaba más 1 hacia arriba.
                }

                // ...y hago que pase lo que pase (haya obstáculo o no) el sprite rote hacia arriba. 
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0f);
            }
        }

        // ...si no es igual, es que me estoy moviendo, entonces para que no sea infinito el movimiento,
        // hago que walking valga 0 para que no sea mayor a 0.06.
        else
        {
            walking[0] = 0;
        }
        // Si mi posición actual es igual a mi última destination (es decir, estoy parado) y pulso la tecla S...
        if (Event.current.Equals(Event.KeyboardEvent(_abajo)) && transform.position == destination)
        {
            dir = new Vector2(0, -1);           // ... le digo que dir ahora vale uno hacia abajo...
            walking[1] += 1 * Time.deltaTime;   // ... le asigno un valor que siempre será mayor que 0.06...
            infoDir = 1;                        // ... y le digo a mi chivato de direcciones que me estoy moviendo hacia abajo.

            // Luego, solo si estoy parado (mi destino es donde me encuentro)...
            if (transform.position == destination)
            {
                //ani.SetFloat("movX", 0);
                //ani.SetFloat("movY", -1);

                // ...y además no tengo obstáculo delante y el valor que le di antes es mayor que 0.06 (spoiler, siempre lo va a ser)...
                if (!CheckCollision() && walking[1] > delay)
                {
                    //ani.SetBool("walk", true);
                    if (totalPaharos.Length > 0)
                        for (int i = 0; i < totalPaharos.Length; i++)
                            // ...hago que en caso que haya pájaro, se mueve una casilla al ser su booleano true.
                            totalPaharos[i].GetComponent<Sal_Bird>().paharoMoving = true;

                    destination += dir;                                         // ...hago que la destination sea ahora donde estaba más 1 hacia abajo.
                }

                // ...y hago que pase lo que pase (haya obstáculo o no) el sprite rote hacia arriba.
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 180f);
            }
        }

        // ...si no es igual, es que me estoy moviendo, entonces para que no sea infinito el movimiento,
        // hago que walking valga 0 para que no sea mayor a 0.06.
        else
        {
            walking[1] = 0;
        }

        // Si mi posición actual es igual a mi última destination (es decir, estoy parado) y pulso la tecla D...
        if (Event.current.Equals(Event.KeyboardEvent(_derecha)) && transform.position == destination)
        {
            dir = new Vector2(1, 0);            // ... le digo que dir ahora vale uno hacia la derecha...
            walking[2] += 1 * Time.deltaTime;   // ... le asigno un valor que siempre será mayor que 0.06...
            infoDir = 2;                        // ... y le digo a mi chivato de direcciones que me estoy moviendo hacia la derecha.

            // Luego, solo si estoy parado (mi destino es donde me encuentro)...
            if (transform.position == destination)
            {
                //ani.SetFloat("movX", 1);
                //ani.SetFloat("movY", 0);

                // ...y además no tengo obstáculo delante y el valor que le di antes es mayor que 0.06 (spoiler, siempre lo va a ser)...
                if (!CheckCollision() && walking[2] > delay)
                {
                    //ani.SetBool("walk", true);

                    if (totalPaharos.Length > 0)
                        for (int i = 0; i < totalPaharos.Length; i++)
                            // ...hago que en caso que haya pájaro, se mueve una casilla al ser su booleano true.
                            totalPaharos[i].GetComponent<Sal_Bird>().paharoMoving = true;

                    destination += dir;                                         // ...hago que la destination sea ahora donde estaba más 1 hacia la derecha.
                }

                // ...y hago que pase lo que pase (haya obstáculo o no) el sprite rote hacia la derecha.
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 270f);
            }
        }

        // ...si no es igual, es que me estoy moviendo, entonces para que no sea infinito el movimiento,
        // hago que walking valga 0 para que no sea mayor a 0.06.
        else
        {
            walking[2] = 0;
        }

        // Si mi posición actual es igual a mi última destination (es decir, estoy parado) y pulso la tecla A...
        if (Event.current.Equals(Event.KeyboardEvent(_izquierda)) && transform.position == destination)
        {
            dir = new Vector2(-1, 0);           // ... le digo que dir ahora vale uno hacia la izquierda...
            walking[3] += 1 * Time.deltaTime;   // ... le asigno un valor que siempre será mayor que 0.06...
            infoDir = 3;                        // ... y le digo a mi chivato de direcciones que me estoy moviendo hacia la izquierda.

            // Luego, solo si estoy parado (mi destino es donde me encuentro)...
            if (transform.position == destination)
            {
                //ani.SetFloat("movX", -1);
                //ani.SetFloat("movY", 0);

                // ...y además no tengo obstáculo delante y el valor que le di antes es mayor que 0.06 (spoiler, siempre lo va a ser)...
                if (!CheckCollision() && walking[3] > delay)
                {
                    // ani.SetBool("walk", true);


                    if (totalPaharos.Length > 0)
                        for (int i = 0; i < totalPaharos.Length; i++)
                            // ...hago que en caso que haya pájaro, se mueve una casilla al ser su booleano true.
                            totalPaharos[i].GetComponent<Sal_Bird>().paharoMoving = true;

                    destination += dir;                                         // ...hago que la destination sea ahora donde estaba más 1 hacia la izquierda.
                }

                // ...y hago que pase lo que pase (haya obstáculo o no) el sprite rote hacia la izquierda.
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 90f);
            }
        }

        // ...si no es igual, es que me estoy moviendo, entonces para que no sea infinito el movimiento,
        // hago que walking valga 0 para que no sea mayor a 0.06.
        else
        {
            walking[3] = 0;

        }
        // ... por lo que finalmente me muevo a esa destination.
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }


    // Función que gestiona lo que ocurre si es una casilla de barro.
    public void MoveBarro()
    {
        // Me creo un array que lo que hará será tener el número de casillas de barro que tenga delante.
        RaycastHit2D[] rayitoBarro;

        // Ese array será un array de lo que esté a 0.49 de distancia en la capa mud.
        rayitoBarro = Physics2D.RaycastAll(transform.position, dir, 0.49f, mud);

        int barro = 0;  // Contador que nos dirá el número de casillas de barro que detecta.

        // Luego por cada hit que hayamos guardado...
        foreach (RaycastHit2D hit in rayitoBarro)
        {
            // ... si lo que ha tocado tiene de tag Mud...
            if (hit.collider.tag == "Mud")
                barro++;        // ... sumo uno al contador.

            //... pero si no tiene ese tag, se sale del bucle.
            else
                break;
        }

        //
        if (transform.position == destination)  // Mientras se está moviendo, no puede cambiar su dirección con esta condición.
        {
            // Si hay barro, no hay obstáculo delante y estoy mirando hacia arriba,
            // se moverá el número de casillas que detecte como barro hacia arriba,
            // hasta que haya un obstáculo o deje de haber barro.
            if (CheckMud() && !CheckCollision() && infoDir == 0)
            {
                resbalar = new Vector2(0, barro);
                destination += resbalar;
            }

            // Si hay barro, no hay obstáculo delante y estoy mirando hacia abajo,
            // se moverá el número de casillas que detecte como barro hacia abajo,
            // hasta que haya un obstáculo o deje de haber barro.
            if (CheckMud() && !CheckCollision() && infoDir == 1)
            {
                resbalar = new Vector2(0, -barro);
                destination += resbalar;
            }

            // Si hay barro, no hay obstáculo delante y estoy mirando hacia la derecha,
            // se moverá el número de casillas que detecte como barro hacia la derecha,
            // hasta que haya un obstáculo o deje de haber barro.
            if (CheckMud() && !CheckCollision() && infoDir == 2)
            {
                resbalar = new Vector2(barro, 0);
                destination += resbalar;
            }

            // Si hay barro, no hay obstáculo delante y estoy mirando hacia la izquierda,
            // se moverá el número de casillas que detecte como barro hacia la izquierda,
            // hasta que haya un obstáculo o deje de haber barro.
            if (CheckMud() && !CheckCollision() && infoDir == 3)
            {
                resbalar = new Vector2(-barro, 0);
                destination += resbalar;
            }
        }
    }

    public void Pausa()
    {
        if (Event.current.Equals(Event.KeyboardEvent(_pausa)))
        {
            if (!gM.heGanado)
            {
                canvasMessage.transform.GetChild(2).gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si contra lo que se choca mi trigger es contra un objeto que tiene un hijo 0 visible...
        if (collision.gameObject.transform.childCount > 0)
        {
            if (collision.gameObject.tag == "Grass" && collision.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled)
            {
                snailDeath.Play();
                canvasMessage.transform.GetChild(1).gameObject.SetActive(true); // Activo el cartel de derrota.
                Destroy(gameObject);                                            // Me hago la automorición.
            }
        }

        else if (collision.gameObject.tag == "Bird")
        {
            snailDeath.Play();
            canvasMessage.transform.GetChild(1).gameObject.SetActive(true); // Activo el cartel de derrota.
            Destroy(gameObject);                                            // Me hago la automorición.
        }
    }
}
