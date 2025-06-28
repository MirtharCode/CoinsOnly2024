using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductUIItem : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Button addButton;

    private ProductData data;

    public void Setup(ProductData product)
    {
        data = product;
        iconImage.sprite = product.icon;
        nameText.text = product.productName;
        priceText.text = "$" + product.price.ToString("F2");

        addButton.onClick.AddListener(() =>
        {
            CartManager.Instance.AddProduct(product);
        });
    }
}

