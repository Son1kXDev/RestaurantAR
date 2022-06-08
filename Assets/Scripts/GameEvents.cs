using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    public UnityEvent OnReadyToCooking, WrongIngredients, OnStartCooking, OnEndCooking, GameOver;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }
}