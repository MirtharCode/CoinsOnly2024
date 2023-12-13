using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    [Header("CURSOR RESHULO")]
    [SerializeField] public GameObject cursor;

    [Header("TRAMPILLA")]
    [SerializeField] public GameObject trampilla;

    [Header("CHARACTERS THAT CAN APPEAR")]

    [Header("EL JEFE")]
    [SerializeField] public GameObject Jefe;

    [Header("Day1")]
    [SerializeField] public GameObject currentCustomer;
    [SerializeField] public int customerNumber = 0;
    [SerializeField] public List<GameObject> dailyCustomers;
    [SerializeField] public GameObject evilWizardGerard;
    [SerializeField] public GameObject hybridElvog;
    [SerializeField] public GameObject limbasticAntonio;
    [SerializeField] public GameObject elementalTapicio;
    [SerializeField] public GameObject electropedDenjirenji;
    [SerializeField] public GameObject hybridMara;
    [SerializeField] public GameObject limbasticGiovanni;
    [SerializeField] public GameObject elementalRockon;

    [Header("Day2")]

    [SerializeField] public GameObject electropedMagmaDora;
    [SerializeField] public GameObject evilWizardManolo;
    [SerializeField] public GameObject limbasticCululu;
    [SerializeField] public GameObject elementalHandy;
    [SerializeField] public GameObject hybridPetra;
    [SerializeField] public GameObject elementalJissy;
    [SerializeField] public GameObject electropedMasermati;
    [SerializeField] public GameObject evilWizardPijus;

    [Header("Day3")]

    [SerializeField] public GameObject limbasticSergio;
    [SerializeField] public GameObject hybridSaltaralisis;
    [SerializeField] public GameObject evilWizardManoloMano;
    [SerializeField] public GameObject electropedRaven;
    [SerializeField] public GameObject elementalHueso;
    [SerializeField] public GameObject limbasticPatxi;
    //[SerializeField] public GameObject hybridElvog; //(Aparece de nuevo en el día 3)
    [SerializeField] public GameObject evilWizardElidora;
    [SerializeField] public GameObject electropedRustica;

    [Header("RELATED TO THE DROPDOWN MENU WITH THE LIST OF ITEMS")]
    [SerializeField] public bool listOpen;
    [SerializeField] public GameObject dropDownPanel;
    [SerializeField] public GameObject dropDownButton;
    [SerializeField] public TMP_Text dropDownButtonText;
    [SerializeField] public GameObject position1;
    [SerializeField] public GameObject position2;

    [Header("ITS ALL ABOUT THE MONEY MONEY MONEY")]
    [SerializeField] public GameObject leDinero;
    [SerializeField] public GameObject leCajaRegistradora;
    [SerializeField] public GameObject lesPropinas;
    [SerializeField] public TMP_Text leDineroText;
    [SerializeField] public TMP_Text lePropinasText;
    [SerializeField] public float propinasNumber = 0;
    [SerializeField] public bool estaToPagao = false;

    [Header("PRODUCTS PLACES")]
    [SerializeField] public Transform oneProduct;
    [SerializeField] public Transform twoProducts1;
    [SerializeField] public Transform twoProducts2;

    [Header("PRODUCTS LIST")]
    [SerializeField] public GameObject energeticDrink;
    [SerializeField] public GameObject beer;
    [SerializeField] public GameObject crystallBall;
    [SerializeField] public GameObject deadCat;
    [SerializeField] public GameObject voodooDoll;
    [SerializeField] public GameObject manaPotion;
    [SerializeField] public GameObject magicBattery;
    [SerializeField] public GameObject magicRamen;
    [SerializeField] public GameObject magicRune;
    [SerializeField] public GameObject venomPotion;

    [Header("CHARACTERS ENTRY/EXIT")]
    [SerializeField] public Transform showUpPoint;
    [SerializeField] public Transform exitPoint;

    [Header("DIALOGUE")]
    [SerializeField] public bool conversationOn;
    [SerializeField] public bool optionsSet;
    [SerializeField] public TMP_Text dialogueText;
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public int internalCount = 0;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvasPausa;
    [SerializeField] public GameObject victoryPanel;
    public Scene currentScene;

    [SerializeField] GameObject normativas;
    [SerializeField] GameObject precios;

    public bool broncaFin = true;
    public bool mostrarJefe = false;
    public GameObject jefePanel;

    public GameObject telefono;

    public List<string> quejas;

    [SerializeField] public TMP_Text textoJefe;

    [SerializeField] public GameObject botonPlegado;
    [SerializeField] public GameObject botonDesplegado;

    [SerializeField] public TMP_Text traductorText;



    #region Código Antiguo
    [SerializeField] public TMP_Text initialConversationText;
    [SerializeField] public char[] chars;
    [SerializeField] public string[] words;
    [SerializeField] public int[] wordsDuration;
    [SerializeField] public AudioSource conversationSound;
    [SerializeField] public AudioClip[] marianoSounds;
    #endregion

    void Start()
    {
        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! CHICO NUEVO, MENOS SUELDO…"); //Si no le has cobrado y sí deberias
        quejas.Add("¡Tendrías que haberle echado a patadas, no tenía el dinero suficiente!"); //Si sí le has cobrado y no deberías
        quejas.Add("¡Aquí tenemos unas normas! ¡¿Las recuerdas?!"); //Cuando no cumple las normativas y no te has enterado
        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! ¡Tenía dinero y no rompía ninguna norma!"); //Si no le has cobrado y sí deberias (A partir del día 2)

        GameObject newCursor = Instantiate(cursor, canvas.transform);
        currentScene = SceneManager.GetActiveScene();
        dropDownButton.SetActive(false);
        estaToPagao = false;

        if (currentScene.name == "Day1")
            Day1();
        if (currentScene.name == "Day2")
            Day2();
        if (currentScene.name == "Day3")
            Day3();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasPausa.activeSelf)
            {
                canvasPausa.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                canvasPausa.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public IEnumerator BossCalling()
    {
        telefono.gameObject.GetComponent<Animator>().SetBool("LlamaJefe", true);

        yield return new WaitForSeconds(1);

        telefono.gameObject.GetComponent<Animator>().SetBool("LlamaJefe", false);

        jefePanel.SetActive(true);
    }

    public void OpenList()
    {
        if (listOpen)
        {
            leDinero.gameObject.GetComponent<Button>().enabled = true;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = true;
            dropDownPanel.transform.position = position2.transform.position;
            botonDesplegado.SetActive(true);
            botonPlegado.SetActive(false);
            listOpen = false;
        }

        else
        {
            leDinero.gameObject.GetComponent<Button>().enabled = false;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = false;
            dropDownPanel.transform.position = position1.transform.position;
            botonDesplegado.SetActive(false);
            botonPlegado.SetActive(true);
            listOpen = true;
        }

    }

    public void CharacterShowUp(GameObject character)
    {
        GameObject clon = Instantiate(character, showUpPoint);
    }

    public void Day1()
    {
        LaVoluntad(50);

        dailyCustomers.Clear();
        dailyCustomers.Add(Jefe);
        dailyCustomers.Add(evilWizardGerard);
        dailyCustomers.Add(hybridElvog);
        dailyCustomers.Add(limbasticAntonio);
        dailyCustomers.Add(elementalTapicio);
        dailyCustomers.Add(electropedDenjirenji);
        dailyCustomers.Add(hybridMara);
        dailyCustomers.Add(limbasticGiovanni);
        dailyCustomers.Add(elementalRockon);

        CharacterShowUp(dailyCustomers[customerNumber]);
    }

    public void Day2()
    {
        dailyCustomers.Clear();
        dailyCustomers.Add(Jefe);
        dailyCustomers.Add(electropedMagmaDora);
        dailyCustomers.Add(evilWizardManolo);
        dailyCustomers.Add(limbasticCululu);
        dailyCustomers.Add(elementalHandy);
        dailyCustomers.Add(hybridPetra);
        dailyCustomers.Add(elementalJissy);
        dailyCustomers.Add(electropedMasermati);
        dailyCustomers.Add(evilWizardPijus);

        CharacterShowUp(dailyCustomers[customerNumber]);
    }

    public void Day3()
    {
        dailyCustomers.Clear();
        dailyCustomers.Add(Jefe);
        dailyCustomers.Add(limbasticSergio);
        dailyCustomers.Add(hybridSaltaralisis);
        dailyCustomers.Add(evilWizardManoloMano);
        dailyCustomers.Add(electropedRaven);
        dailyCustomers.Add(elementalHueso);
        dailyCustomers.Add(limbasticPatxi);
        dailyCustomers.Add(hybridElvog);
        dailyCustomers.Add(evilWizardElidora);
        dailyCustomers.Add(electropedRustica);

        CharacterShowUp(dailyCustomers[customerNumber]);
    }

    public void ShowText()
    {
        FindTheCustomer();
        conversationOn = true;
        dialoguePanel.gameObject.SetActive(true);

        traductorText.text = currentCustomer.GetComponent<Client>().raza;

        // Si el actual cliente tiene como nombre "qhsjdjkqshdkq"
        // Llamo al método DialogueTexts al que le paso la cantidad de líneas que tiene su diálogo y que el diálogo en cuestión.


        if (currentCustomer.name.Contains("Jefe") && internalCount < currentCustomer.GetComponent<Client>().dialogue.Count)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            internalCount++;

            //if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count)
            //    currentCustomer.GetComponent<Client>().ByeBye();
            //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        }

        else if (internalCount < currentCustomer.GetComponent<Client>().dialogue.Count - 2 && !currentCustomer.name.Contains("Jefe"))
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            //SoundCreator(dialogueText.text);
            internalCount++;
            //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        }

        else
            HideText();
    }

    public void HideText()
    {
        FindTheCustomer();
        conversationOn = false;
        dialoguePanel.gameObject.SetActive(false);

        if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count && currentCustomer.name.Contains("Jefe"))
        {
            estaToPagao = true;
            currentCustomer.GetComponent<Client>().ByeBye();
        }

        else if (!estaToPagao)
        {
            leDinero.gameObject.SetActive(true);
            leDinero.gameObject.GetComponent<Button>().enabled = true;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = true;
            dropDownButton.SetActive(true);

            if (currentScene.name == "Day1")
            {
                if (currentCustomer.name.Contains("Geraaaard"))
                    currentCustomer.GetComponent<MO_Geeraard>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Sapopotamo"))
                    currentCustomer.GetComponent<H_Elvog>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Antonio"))
                    currentCustomer.GetComponent<L_Antonio>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Tapiz"))
                    currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Denjirenji"))
                    currentCustomer.GetComponent<T_Denjirenji>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Mara"))
                    currentCustomer.GetComponent<H_Mara>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Giovanni"))
                    currentCustomer.GetComponent<L_Giovanni>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Rockon"))
                    currentCustomer.GetComponent<E_Rockon>().ShowProductsAndMoney();


            }

            else if (currentScene.name == "Day2")
            {
                if (currentCustomer.name.Contains("Magma"))
                    currentCustomer.GetComponent<T_MagmaDora>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Manolo"))
                    currentCustomer.GetComponent<MO_ManoloCabezaPico>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Cululu"))
                    currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Handy"))
                    currentCustomer.GetComponent<E_Handy>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Petra"))
                    currentCustomer.GetComponent<H_Petra>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Jissy"))
                    currentCustomer.GetComponent<E_Jissy>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Masermati"))
                    currentCustomer.GetComponent<T_Masermati>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Pijus"))
                    currentCustomer.GetComponent<MO_PijusMagnus>().ShowProductsAndMoney();
            }

            else if (currentScene.name == "Day3")
            {
                if (currentCustomer.name.Contains("Sergio"))
                    currentCustomer.GetComponent<L_Sergio>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Saltaralisis"))
                    currentCustomer.GetComponent<H_Saltaralisis>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("ManoloMano"))
                    currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Raven"))
                    currentCustomer.GetComponent<T_Raven>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Hueso"))
                    currentCustomer.GetComponent<E_ElementalHueso>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Patxi"))
                    currentCustomer.GetComponent<L_Patxi>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Sapopotamo"))
                    currentCustomer.GetComponent<H_Elvog>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Elidora"))
                    currentCustomer.GetComponent<MO_Elidora>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Rustica"))
                    currentCustomer.GetComponent<T_Rustica>().ShowProductsAndMoney();

            }

            internalCount++;
        }

        else
        {
            currentCustomer.GetComponent<Client>().ByeBye();
        }
    }

    public void CollectMoney()
    {
        dropDownButton.SetActive(false);
        FindTheCustomer();
        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);
        MoneyText();
    }

    public void IDontBelieveIt()
    {
        dropDownButton.SetActive(false);
        FindTheCustomer();
        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);
        IDontBelieveText();

    }

    public void LaVoluntad(float cantidad)
    {
        propinasNumber += cantidad;
        lesPropinas.GetComponent<Image>().fillAmount = (propinasNumber) / 100;
        lePropinasText.text = "" + propinasNumber;
    }

    public void FindTheCustomer()
    {
        currentCustomer = GameObject.FindGameObjectWithTag("CurrentCustomer");
    }

    public string MoneyText()
    {
        dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 2];
        //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());

        if (currentScene.name == "Day1")
        {
            if (currentCustomer.name.Contains("Geraaaard") || currentCustomer.name.Contains("Sapopotamo") || currentCustomer.name.Contains("Tapiz") || currentCustomer.name.Contains("Mara") || currentCustomer.name.Contains("Giovanni"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Antonio") || currentCustomer.name.Contains("Denjirenji") || currentCustomer.name.Contains("Rockon"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[1];
                LaVoluntad(-10);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day2")
        {
            if (currentCustomer.name.Contains("Pijus"))
            {
                //Mostrar queja de que no tiene suficiente dinero
                mostrarJefe = true;
                textoJefe.text = quejas[1];
                LaVoluntad(-15);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Magma") || currentCustomer.name.Contains("Handy") || currentCustomer.name.Contains("Jissy"))
            {
                //Mostrar queja de que no cumplen normas
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Manolo") || currentCustomer.name.Contains("Cululu") || currentCustomer.name.Contains("Petra") || currentCustomer.name.Contains("Masermati"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day3")
        {
            if (currentCustomer.name.Contains("Saltaralisis") || currentCustomer.name.Contains("ManoloMano") || currentCustomer.name.Contains("Raven")
                || currentCustomer.name.Contains("Patxi") || currentCustomer.name.Contains("Rustica"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Sapopotamo"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(5);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Sergio") || currentCustomer.name.Contains("Hueso") || currentCustomer.name.Contains("Elidora"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
                return dialogueText.text;
            }
        }


        return null;
    }

    public string IDontBelieveText()
    {
        dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 1];
        //currentCustomer.GetComponent<Client>().lineIndex += 1;
        //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());


        if (currentScene.name == "Day1")
        {
            if (currentCustomer.name.Contains("Geraaaard") || currentCustomer.name.Contains("Sapopotamo") || currentCustomer.name.Contains("Tapiz")
                || currentCustomer.name.Contains("Mara") || currentCustomer.name.Contains("Giovanni"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[0];
                LaVoluntad(-10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Antonio") || currentCustomer.name.Contains("Denjirenji") || currentCustomer.name.Contains("Rockon"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day2")
        {
            if (currentCustomer.name.Contains("Manolo") || currentCustomer.name.Contains("Cululu")
                || currentCustomer.name.Contains("Petra") || currentCustomer.name.Contains("Masermati"))
            {
                //Queja de que si que tenía el dinero suficiente
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Magma") || currentCustomer.name.Contains("Handy") || currentCustomer.name.Contains("Jissy"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Pijus"))
            {
                mostrarJefe = false;
                LaVoluntad(-1);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day3")
        {
            if (currentCustomer.name.Contains("Sergio") || currentCustomer.name.Contains("Hueso") || currentCustomer.name.Contains("Sapopotamo") || currentCustomer.name.Contains("Elidora"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Saltaralisis") || currentCustomer.name.Contains("ManoloMano") || currentCustomer.name.Contains("Raven")
                || currentCustomer.name.Contains("Patxi") || currentCustomer.name.Contains("Rustica"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
                return dialogueText.text;
            }
        }


        return null;
    }

    public void SaltarJefe()
    {
        broncaFin = true;
        mostrarJefe = false;
        jefePanel.SetActive(false);
    }

    public void MoreSpeed()
    {
        currentCustomer.GetComponent<Client>().typingTime = 0;
    }

    public void Reanudar()
    {
        canvasPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void Titulo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void SiguienteDia2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void SiguienteDia3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void ActivarNormas()
    {
        normativas.SetActive(true);
        precios.SetActive(false);
    }

    public void ActivarPrecios()
    {
        precios.SetActive(true);
        normativas.SetActive(false);
    }

    #region Código Antiguo
    //void firstEntrance(int random)
    //{
    //    if (random == 1)
    //    {
    //        luffyOn = true;
    //        luffy.SetActive(true);
    //        initialConversationText.text = "Hola, vengo a comprar el One Piece, pero como no se que es, espero que tú sepas separ lo que sepo no saber, porque sabiendo lo\n" +
    //            " que es el ser, será mucho más para ti con tu beneficio, bueno, vamos a la mandanga, que es very difficult todo esto, sabes...\n" +
    //            " ¡¡Algún día seré el rey de las patatas!!";


    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }

    //    }
    //    else if (random == 2)
    //    {
    //        doraOn = true;
    //        dora.SetActive(true);
    //        initialConversationText.text = "Hola, hola! Soy Dora la Explotadora Hi, hi! I`m Dora and you are my bitch! ¿Donde hay bananas? \n" +
    //            " Dime donde hay bananas sucio e indigno ser WHERE ARE THE BANANAS? También si tienes ideas para juegos me las debes dar\n" +
    //            " ¡Me encanta el talento de los jóvenes! I love easy money!!";

    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }
    //    }
    //    else if (random == 3)
    //    {
    //        terryOn = true;
    //        terry.SetActive(true);
    //        initialConversationText.text = "Making my way downtown, Walking fast, faces pass and I'm homebound,\n" +
    //            " Staring blankly ahead, Just making my way, Making a way through the crowd. \n" +
    //            "And I need you (chururu churururú) And I miss you (chururu churururú) And now I wonder...\n";

    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }
    //    }
    //    else if (random == 4)
    //    {
    //        franceOn = true;
    //        france.SetActive(true);
    //        initialConversationText.text = "Hola queguido comegciante, me podgría cobgag estos gagos gábanos silvegtges y estas vegdugas de tempogada\n" +
    //            " Me lamo Gigobegto Gampagdez, me encanta gapeag y ggapag ggupos de folios con mi ggapadoga. \n" +
    //            "Viva le Fgance!\n";

    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }
    //    }
    //    else if (random == 5)
    //    {
    //        duolingOn = true;
    //        duoling.SetActive(true);
    //        initialConversationText.text = "Espero que hayas hecho hoy tu lección de Quichua, porque si no te lo recordaré con el cuchill...\n" +
    //            "Oh perdona... la costumbre jeje Bueno, cóbrame estos productos y aprende otro idioma exclusivamente con mi app jijiji\n" +
    //            "¿Me cobras o te enseño una lección?\n";

    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }
    //    }
    //}

    //public void SoundCreator(string texto)
    //{
    //    chars = new char[texto.Length];
    //    string[] provisionalWords = new string[texto.Length];
    //    int pauses = 0;
    //    int huecoPalabra = 0;


    //    for (int i = 0; i < texto.Length; i++)
    //    {
    //        if (texto[i] == ' ')
    //        {
    //            pauses++;
    //            huecoPalabra++;
    //        }

    //        else if (texto[i] != ' ')
    //            provisionalWords[huecoPalabra] += texto[i];

    //        chars[i] = texto[i];
    //    }

    //    int palabrasTotales = huecoPalabra + 1;
    //    words = new string[palabrasTotales];

    //    for (int i = 0; i < palabrasTotales; i++)
    //    {
    //        words[i] = provisionalWords[i];
    //    }

    //    wordsDuration = new int[words.Length];

    //    for (int i = 0; i < wordsDuration.Length; i++)
    //    {
    //        for (int j = 0; j < words[i].Length; j++)
    //        {
    //            wordsDuration[i]++;
    //        }
    //    }

    //    //StartCoroutine(SoundMaker());
    //}

    //IEnumerator SoundMaker()
    //{

    //    for (int i = 0; i < wordsDuration.Length; i++)
    //    {
    //        if (wordsDuration[i] < 3)
    //        {
    //            conversationSound.clip = marianoSounds[1];

    //            float duration = conversationSound.clip.length / 2f;
    //            float randomPitch = Random.Range(0.9f, 1.1f);

    //            conversationSound.pitch = randomPitch;
    //            conversationSound.Play();

    //            yield return new WaitWhile(() => conversationSound.isPlaying);
    //        }

    //        else if (wordsDuration[i] < 7)
    //        {
    //            conversationSound.clip = marianoSounds[4];

    //            float duration = conversationSound.clip.length / 2f;
    //            float randomPitch = Random.Range(0.9f, 1.1f);

    //            conversationSound.pitch = randomPitch;
    //            conversationSound.Play();

    //            yield return new WaitWhile(() => conversationSound.isPlaying);
    //        }

    //        else
    //        {
    //            conversationSound.clip = marianoSounds[7];

    //            float duration = conversationSound.clip.length / 32;
    //            float randomPitch = Random.Range(0.9f, 1.1f);

    //            conversationSound.pitch = randomPitch;
    //            conversationSound.Play();

    //            yield return new WaitWhile(() => conversationSound.isPlaying);
    //        }
    //    }
    //}

    #endregion
}