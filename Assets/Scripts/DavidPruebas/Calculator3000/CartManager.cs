using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartManager : MonoBehaviour
{
    public static CartManager Instance;

    [SerializeField] private Transform cartContentParent;
    [SerializeField] private GameObject cartItemPrefab;
    [SerializeField] private TextMeshProUGUI totalText;

    private Dictionary<ProductData, int> cart = new();
    private Dictionary<ProductData, CartItemUI> uiItems = new();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddProduct(ProductData product)
    {
        if (!cart.ContainsKey(product))
        {
            cart[product] = 1;
            GameObject obj = Instantiate(cartItemPrefab, cartContentParent);
            CartItemUI itemUI = obj.GetComponent<CartItemUI>();
            itemUI.Setup(product, 1);
            uiItems[product] = itemUI;
        }
        else
        {
            cart[product]++;
            uiItems[product].SetQuantity(cart[product]);
        }

        UpdateTotal();
    }

    public void RemoveProduct(ProductData product)
    {
        if (!cart.ContainsKey(product)) return;

        cart[product]--;

        if (cart[product] <= 0)
        {
            Destroy(uiItems[product].gameObject);
            cart.Remove(product);
            uiItems.Remove(product);
        }
        else
        {
            uiItems[product].SetQuantity(cart[product]);
        }

        UpdateTotal();
    }

    private void UpdateTotal()
    {
        float total = 0f;
        foreach (var pair in cart)
            total += pair.Key.price * pair.Value;

        totalText.text = "$" + total.ToString("F2");
    }

    public void ClearCart()
    {
        foreach (var ui in uiItems.Values)
            Destroy(ui.gameObject);

        cart.Clear();
        uiItems.Clear();
        UpdateTotal();
    }
}