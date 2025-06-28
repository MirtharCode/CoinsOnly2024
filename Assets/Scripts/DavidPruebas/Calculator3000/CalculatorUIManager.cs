using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculatorUIManager : MonoBehaviour
{
    public GameObject productButtonPrefab;
    public Transform productListContainer;
    public TextMeshProUGUI categoryTitleText;
    public Image backgroundPanel;

    public Color foodColor;
    public Color potionColor;
    public Color darkMagicColor;
    public Color magicItemColor;

    public ProductData[] allProducts;

    public void ShowCategory(int categoryIndex)
    {
        ClearProductList();
        Category selected = (Category)categoryIndex;

        categoryTitleText.text = selected.ToString();
        backgroundPanel.color = GetColorForCategory(selected);

        foreach (var p in allProducts)
        {
            if (p.category != selected) continue;

            GameObject obj = Instantiate(productButtonPrefab, productListContainer);
            obj.GetComponent<ProductUIItem>().Setup(p);
        }
    }

    void ClearProductList()
    {
        foreach (Transform child in productListContainer)
        {
            Destroy(child.gameObject);
        }
    }

    Color GetColorForCategory(Category c)
    {
        return c switch
        {
            Category.FoodDrink => foodColor,
            Category.Potions => potionColor,
            Category.DarkMagic => darkMagicColor,
            Category.MagicItems => magicItemColor,
            _ => Color.white,
        };
    }
}
