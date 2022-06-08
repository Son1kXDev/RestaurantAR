using UnityEngine;
using TMPro;

public class Order : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;             //����� � ��������� �����
    [SerializeField] private TextMeshProUGUI ingredients;       //����� �� �������� ������������
    [SerializeField] private TextMeshProUGUI time;              //����� � �������� �������������
    [SerializeField] private TextMeshProUGUI rank;              //����� � ������� ���������
    [SerializeField] private TextMeshProUGUI cost;              //����� ���������

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
    /// ����������� ������
    /// </summary>
    private void DisplayText()
    {
        title.text = currentRecipe.title;
        time.text = $"{currentRecipe.time} ���.";
        rank.text = $"{currentRecipe.rank}";
        cost.text = $"{currentRecipe.cost} ���.";
        ingredients.text = "";
        for (int i = 0; i < currentRecipe.ingredients.Length; i++)
        {
            ingredients.text += $"{currentRecipe.ingredients[i]} \n";
        }
    }
}