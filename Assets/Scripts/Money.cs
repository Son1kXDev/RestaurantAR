using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public static Money instance;

    public float money;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    private void Start()
    {
        DisplayMoney();
    }

    public void DisplayMoney()
    {
        moneyText.text = $"{money} руб.";
    }
}