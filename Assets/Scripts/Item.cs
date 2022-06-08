using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string Name;
    public int Count = 1;

    public void Click()
    {
        gameObject.GetComponent<Button>().interactable = false;
        Cooking.instance.playerIngredients.Add(Name);
        Cooking.instance.DisplayIngredient();
        if (Cooking.instance.playerIngredients.Count == Cooking.instance.recipeIngredients.Length)
        {
            GameEvents.instance.OnReadyToCooking.Invoke();
        }
    }
}