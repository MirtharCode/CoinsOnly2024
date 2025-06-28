using UnityEngine;

[CreateAssetMenu(fileName = "NewProduct", menuName = "Calculator3000/Product")]
public class ProductData : ScriptableObject
{
    public string productName;
    public Sprite icon;
    public float price;
    public Category category;
    public string variantTag; 
}

public enum Category
{
    FoodDrink,
    Potions,
    DarkMagic,
    MagicItems
}

