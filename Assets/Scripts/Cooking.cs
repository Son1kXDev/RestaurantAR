using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public static Cooking instance;
    public bool isCooking = false;

    public List<string> playerIngredients;

    public string[] recipeIngredients;

    public Client client;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI ingredientText;

    private bool cookingTimerStarted = false;

    private float timer;

    private float cost;

    private int ingredientNum = 0;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    private void Update()
    {
        if (cookingTimerStarted)
        {
            timer -= Time.deltaTime;
            DisplayTime();

            if (timer <= 0)
            {
                GameEvents.instance.OnEndCooking.Invoke();
                DestroyIngredients();
                Money.instance.money += cost;
                Money.instance.DisplayMoney();
                timerText.text = "";
                Destroy(client.gameObject);
                ClientSpawner.instance.curClientCount++;
                ClientSpawner.instance.DisplayText();
                cookingTimerStarted = false;
                isCooking = false;
            }
        }
    }

    public void GetRecipeParams(string[] recipeIngredients, int timer, float cost)
    {
        this.recipeIngredients = recipeIngredients;
        this.timer = timer;
        this.cost = cost;
    }

    private void StartCooking() => cookingTimerStarted = true;

    public void DisplayIngredient()
    {
        ingredientText.text += $"{playerIngredients[ingredientNum]}\n";
        ingredientNum++;
    }

    public void Ready()
    {
        CheckIngredients();
    }

    private void CheckIngredients()
    {
        bool isRight = true;

        for (int i = 0; i < playerIngredients.Count; i++)
        {
            for (int j = 0; j < recipeIngredients.Length; j++)
            {
                if (recipeIngredients[j] == playerIngredients[i])
                {
                    isRight = true;
                    break;
                }
                else isRight = false;
            }
        }

        if (isRight)
        {
            GameEvents.instance.OnStartCooking.Invoke();
            playerIngredients.Clear();
            StartCooking();
        }
        else { DestroyIngredients(); GameEvents.instance.WrongIngredients.Invoke(); }
    }

    private void DestroyIngredients()
    {
        playerIngredients.Clear();
        ingredientNum = 0;
        ingredientText.text = "";
    }

    private void DisplayTime()
    {
        int seconds = Mathf.FloorToInt(timer);
        timerText.text = $"Приготовление: {seconds} секунд";
    }
}