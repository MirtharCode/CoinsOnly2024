using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sal_Bird : MonoBehaviour
{
    public int infoDir = -1;             // ESTE PARÁMETRO SE RELLENA DESDE EL MODO EDITOR DEPENDIENDO DE HACIA DONDE EMPIECE MIRANDO EL PÁJARO. 0 = ARRIBA, 1 = ABAJO, 2 = DER., 3 = IZQ.
    public RaycastHit2D hit;
    public LayerMask obstacle;
    [SerializeField] Vector3 dir;
    public Vector3 destination;
    private Animator ani;

    public bool paharoMoving;

    public float speed, delay;

    void Start()
    {
        ani = GetComponent<Animator>();
        dir = new Vector2(0, 0);
        destination = transform.position;                       // Le digo que mi destino al iniciar el juego es donde estoy colocado.
    }

    // Update is called once per frame
    void Update()
    {
        BirdMove();
    }
    // Booleano que va a ser afirmativo cuando el Raycast choque contra 
    // algo que esté en la capa obstáculo (es decir, un obstáculo).
    bool CheckCollision
    {
        get
        {
            // Coge información de lo que el rayo de tamaño 1 que sale del centro del personaje toque en la capa obstacle.
            hit = Physics2D.Raycast(transform.position, dir, 1, obstacle);
            return hit.collider != null;    // Da un valor positivo si no es nulo, es decir, si ha detectado algo.
        }
    }

    // Esto simplemente sirve para ver dibujado el rayo en el modo editor.
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, dir);
    }

   

    public void PaDondeMiraErPaharo()
    {
        if (infoDir == 0)
            dir = new Vector2(0, 1);            // ... le digo que dir ahora vale uno hacia arriba...

        if (infoDir == 1)
            dir = new Vector2(0, -1);           // ... le digo que dir ahora vale uno hacia abajo...

        if (infoDir == 2)
            dir = new Vector2(1, 0);            // ... le digo que dir ahora vale uno hacia la derecha...

        if (infoDir == 3)
            dir = new Vector2(-1, 0);           // ... le digo que dir ahora vale uno hacia la izquierda...
    }

    public void BirdMove()
    {
        if (infoDir==-1)
        {
            ani.SetBool("volar", false);
        }
        // Si me indican que el pájaro debería moverse...
        if (paharoMoving)
        {
            print("Entro en BirdMovingTrue");

            // ...y el pájaro está quieto...
            if (transform.position == destination)
            {
                // ...y no hay colisión enfrente de él...
                if (!CheckCollision)
                {
                    // ...Invoco al método que me dice hacia donde avanzo
                    PaDondeMiraErPaharo();

                    // ...y me chivan desde el editor que el pájaro está mirando hacia arriba
                    if (infoDir == 0)
                    {
                        //ani.SetFloat("movX", 1);
                        //ani.SetFloat("movY", 0);
                        //ani.SetBool("walk", true);
                        ani.SetBool("volar", true);

                        paharoMoving = false;         // ...lo pongo en falso para que no se mueva a tope.
                        destination += dir;                                                 // ...hago que la destination sea ahora donde estaba más 1 hacia arriba.                     
                        transform.eulerAngles =
                            new Vector3(transform.rotation.x, transform.rotation.y, 0f);    // ...y hago que el sprite rote hacia arriba.
                    }

                    // ...y me chivan desde el editor que el pájaro está mirando hacia abajo
                    if (infoDir == 1)
                    {
                        //ani.SetFloat("movX", 1);
                        //ani.SetFloat("movY", 0);
                        //ani.SetBool("walk", true);

                        paharoMoving = false;         // ...lo pongo en falso para que no se mueva a tope.
                        destination += dir;                                                 // ...hago que la destination sea ahora donde estaba más 1 hacia abajo.
                        transform.eulerAngles =
                            new Vector3(transform.rotation.x, transform.rotation.y, 180f);  // ...y hago que el sprite rote hacia abajo.
                    }

                    // ...y me chivan desde el editor que el pájaro está mirando hacia la derecha
                    if (infoDir == 2)
                    {
                        //ani.SetFloat("movX", 1);
                        //ani.SetFloat("movY", 0);
                        //ani.SetBool("walk", true);
                        ani.SetBool("volar", true);

                        paharoMoving = false;         // ...lo pongo en falso para que no se mueva a tope.
                        destination += dir;                                                 // ...hago que la destination sea ahora donde estaba más 1 hacia la derecha.
                        transform.eulerAngles =
                            new Vector3(transform.rotation.x, transform.rotation.y, 270f);  // ...y hago que el sprite rote hacia la derecha.
                    }

                    // ...y me chivan desde el editor que el pájaro está mirando hacia la izquierda
                    if (infoDir == 3)
                    {
                        //ani.SetFloat("movX", 1);
                        //ani.SetFloat("movY", 0);
                        //ani.SetBool("walk", true);
                        ani.SetBool("volar", true);

                        paharoMoving = false;         // ...lo pongo en falso para que no se mueva a tope.
                        destination += dir;                                                 // ...hago que la destination sea ahora donde estaba más 1 hacia la derecha.
                        transform.eulerAngles =
                            new Vector3(transform.rotation.x, transform.rotation.y, 90f);   // ...y hago que el sprite rote hacia la izquierda.
                    }
                }

                else
                {
                    if (infoDir == 0)
                    {
                        infoDir = 1;
                        PaDondeMiraErPaharo();
                        BirdMove();
                    }


                    else if (infoDir == 1)
                    {
                        infoDir = 0;
                        PaDondeMiraErPaharo();
                        BirdMove();
                    }

                    else if (infoDir == 2)
                    {
                        infoDir = 3;
                        PaDondeMiraErPaharo();
                        BirdMove();
                    }

                    else if (infoDir == 3)
                    {
                        infoDir = 2;
                        PaDondeMiraErPaharo();
                        BirdMove();
                    }
                }
            }

            // ... por lo que finalmente me muevo a esa destination.
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }
}