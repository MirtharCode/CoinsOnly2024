using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartItemUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI subtotalText;
    public Button plusButton;
    public Button minusButton;

    private ProductData product;
    private int quantity;

    public void Setup(ProductData p, int q)
    {
        product = p;
        quantity = q;
        Refresh();

        plusButton.onClick.AddListener(() =>
        {
            CartManager.Instance.AddProduct(product);
        });

        minusButton.onClick.AddListener(() =>
        {
            CartManager.Instance.RemoveProduct(product);
        });
    }

    public void Refresh()
    {
        nameText.text = product.productName;
        quantityText.text = quantity.ToString();
        subtotalText.text = "$" + (product.price * quantity).ToString("F2");
    }

    public void SetQuantity(int q)
    {
        quantity = q;
        Refresh();
    }

    public ProductData GetProduct() => product;
}