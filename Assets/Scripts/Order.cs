using UnityEngine;
using TMPro;

public class Order : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;             //текст с названием блюда
    [SerializeField] private TextMeshProUGUI ingredients;       //текст со списоком ингредиентов
    [SerializeField] private TextMeshProUGUI time;              //текст с временем приготовления
    [SerializeField] private TextMeshProUGUI rank;              //текст с уровнем сложности
    [SerializeField] private TextMeshProUGUI cost;              //текст стоимости

    [SerializeField] private GameObject recipePanel, invPanel, ingredientsPanel;

    private Recipe currentRecipe;

    private void OnMouseDown()
    {
        if (!Cooking.instance.client)
        {
            ClientSpawner.instance.NewClient();
        }
    }

    public void Ordering()
    {
        if (!Cooking.instance.isCooking)
        {
            currentRecipe = JSONParser.instance.GenerateNewRecipe();
            DisplayText();

            recipePanel.SetActive(true);
            invPanel.SetActive(true);
            ingredientsPanel.SetActive(true);
            Cooking.instance.isCooking = true;
            Cooking.instance.GetRecipeParams(currentRecipe.ingredients, currentRecipe.time, currentRecipe.cost);
        }
    }

    /// <summary>
    /// Отображение текста
    /// </summary>
    private void DisplayText()
    {
        title.text = currentRecipe.title;
        time.text = $"{currentRecipe.time} сек.";
        rank.text = $"{currentRecipe.rank}";
        cost.text = $"{currentRecipe.cost} руб.";
        ingredients.text = "";
        for (int i = 0; i < currentRecipe.ingredients.Length; i++)
        {
            ingredients.text += $"{currentRecipe.ingredients[i]} \n";
        }
    }
}