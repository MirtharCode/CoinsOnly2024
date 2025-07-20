using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePanelScript : MonoBehaviour
{
    public void PlayPanelAnimation(int direction)
    {

        if (direction == 1)
        {
            GetComponent<Animator>().Play("RacePanelUP"); // desde el inicio
        }
        else if (direction == -1)
        {
            // ¡Esto es importante! Al ir en reversa, debes empezar al final
            GetComponent<Animator>().Play("RacePanelDOWN");
        }
    }
}
