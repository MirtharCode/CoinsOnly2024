using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public bool luffyOn, doraOn, terryOn, franceOn, duolingOn;
    [SerializeField] public GameObject luffy, dora, terry, france, duoling;
    [SerializeField] public TMP_Text initialConversationText;


    // Start is called before the first frame update
    void Start()
    {
        int randomEntrance = Random.Range(1, 6);
        if (randomEntrance == 1)
        {
            luffyOn = true;
            luffy.SetActive(true);
            initialConversationText.text = "Hola, vengo a comprar el One Piece, pero como no se que es, espero que t� sepas separ lo que sepo no saber, porque sabiendo lo\n" +
                " que es el ser, ser� mucho m�s para ti con tu beneficio, bueno, vamos a la mandanga, que es very difficult todo esto, sabes...\n" +
                " ��Alg�n d�a ser� el rey de las patatas!!";
        }
        else if (randomEntrance == 2)
        {
            doraOn = true;
            dora.SetActive(true);
            initialConversationText.text = "Hola, hola! Soy Dora la Explotadora Hi, hi! I`m Dora and you are my bitch! �Donde hay bananas? \n" +
                " Dime donde hay bananas sucio e indigno ser WHERE ARE THE BANANAS? Tambi�n si tienes ideas para juegos me las debes dar\n" +
                " �Me encanta el talento de los j�venes! I love easy money!!";
        }
        else if (randomEntrance == 3)
        {
            terryOn = true;
            terry.SetActive(true);
            initialConversationText.text = "Making my way downtown, Walking fast, faces pass and I'm homebound,\n" +
                " Staring blankly ahead, Just making my way, Making a way through the crowd. \n" +
                "And I need you (chururu chururur�) And I miss you (chururu chururur�) And now I wonder...\n";
        }
        else if (randomEntrance == 4)
        {
            franceOn = true;
            france.SetActive(true);
            initialConversationText.text = "Hola queguido comegciante, me podgr�a cobgag estos gagos g�banos silvegtges y estas vegdugas de tempogada\n" +
                " Me lamo Gigobegto Gampagdez, me encanta gapeag y ggapag ggupos de folios con mi ggapadoga. \n" +
                "Viva le Fgance!\n";
        }
        else if (randomEntrance == 5)
        {
            duolingOn = true;
            duoling.SetActive(true);
            initialConversationText.text = "Espero que hayas hecho hoy tu lecci�n de Quichua, porque si no te lo recordar� con el cuchill...\n" +
                "Oh perdona... la costumbre jeje Bueno, c�brame estos productos y aprende otro idioma exclusivamente con mi app jijiji\n" +
                "�Me cobras o te ense�o una lecci�n?\n";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
