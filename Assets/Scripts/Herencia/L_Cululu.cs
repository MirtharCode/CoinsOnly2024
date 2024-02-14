using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Cululu : Limbasticos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    protected override void Start()
    {
        base.Start();
        nombre = "Cululu";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().limbasticCululu;
            data.GetComponent<Data>().SettingDialogues();

            if (currentScene.name == "Day2")
            {
                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Buenos días mi dependiente favorito, ¿no es preciosa la vida?");
                dialogue.Add("...");
                dialogue.Add("Veo que mi pregunta te dejo mudo al igual que yo cuando veo a mi nueva diosa.");
                dialogue.Add("La cita del otro día no sólo fue genial, fue perfecta.");
                dialogue.Add("Cuando la ví, quedé perdido en su ojos de mantis, y no paraba de querer acariciar sus preciosas y afiladas garras.");
                dialogue.Add("Obvio fuí un caballero y no me atreví a tocar sus hermosas garras.");
                dialogue.Add("Además de que no quería perder mi mano.");
                dialogue.Add("Pero bueno, lo mejor de la cita fue cuando nos sentamos juntos y cenamos.");
                dialogue.Add("Y esa cangumantis me dijo 10 palabras, ¡10 PALABRAS!");
                dialogue.Add("Solo una hembra me había dicho más palabras que esas, mi madre.");
                dialogue.Add("Mis palabras favoritas fueron “¿Pagas tú, no?” Quiso que pagara yo, qué romántico");
                dialogue.Add("Tengo pensado decirle de tener otra cita, y creo que esto de aquí será necesario para la cita, así que si pudieras cobrarme.");

                dialogue.Add("Te informaré sobre mi próxima cita, mi dependiente favorito.");
                dialogue.Add("Tú, enemigo del amor, gracias por arruinar mi cita.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Hola colega, tengo una mala noticia para ti.");
                dialogue.Add("La cangumantis y yo lo hemos dejado, me echó spray de pimienta en la esfera cuando la encontré.");
                dialogue.Add("Es una de las maneras en la que me han dejado, la peor una de mis exs que me dejó por mi hermano.");
                dialogue.Add("Pero esto ha hecho que abra los ojos y me dé cuenta que de tanto pensar en el amor, me perdí en el sendero de la vida.");
                dialogue.Add("Así que tome una decisión importante y me desinstalé Hybrinder, aunque me quedara un año de premium.");
                dialogue.Add("Creo que ahora voy a rehacer mi vida, ahora que soy un limbástico.");
                dialogue.Add("Puedo intentar ser un monje, perdido en la montaña, para encontrar un nuevo camino.");
                dialogue.Add("Pero creo que me quedaré trabajando en la gasolinera como siempre, hasta que encuentre mi camino.");
                dialogue.Add("Hablando de la gasolinera, cóbrame que tengo dentro de nada el turno.");

                dialogue.Add("Voy a empezar con ganas mi nuevo camino, si es que me llega.");
                dialogue.Add("Espero que empezar mi nuevo camino no se vea afectado por mi nulas capacidades de contar monedas.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day2")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "16";
        }

        else if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().crystallBall, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "22";
        }

        else if (currentScene.name == "Day5")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().beer, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "18";
        }

    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        Destroy(product3);
        base.ByeBye();
    }

    // Cululu Tenía 150 líneas de código siendo un personaje que aparecía en 3 días
}
