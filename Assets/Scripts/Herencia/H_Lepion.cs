using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Lepion : Hibridos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
    bool repetirunavez = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            if (currentScene.name == "Day2")
            {
                dialogue.Add("你好人類。\n (Hola humano.)");
                dialogue.Add("等等，你就是個不會數數的傻瓜\n (Espera, tu eres el tonto que no sabía contar.)");
                dialogue.Add("昨天微波爐來了\n(Ayer vino aquí ese microondas.)");
                dialogue.Add("那東西應該再給你一枚硬幣 \n(Y ese cacharro debió darte una moneda más)");
                dialogue.Add("至少現在我可以證明他被解僱是合理的\n(Al menos ahora puedo justificar su despido)");
                dialogue.Add("雖然傻瓜開始說切腹之類的話\n (Aunque el bobo se puso a decir cosas de hacer el harakiri o cosas así.)");
                dialogue.Add("無論如何，該死的日本機器\n (En fin, malditas máquinas japonesas.)");
                dialogue.Add("當你這樣做的時候，向我指控這一點，我必須繼續我的洗錢工作。\n(Ya que estás, cobrame esto, que debo seguir con mi trabajo de blanqueamiento de dinero.)");

                dialogue.Add("再見，愚蠢的人類，他甚至不知道如何為微波爐充電 \n(Adiós)");
                dialogue.Add("愚蠢的人類學會了數數 \n(Ni contar sabes, ¿de verdad? Acabas de perder todos los clientes chinos por la zona, \n y espero que pronto pierdas tú el trabajo.)");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "13";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
