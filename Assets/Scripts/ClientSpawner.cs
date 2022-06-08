using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClientSpawner : MonoBehaviour
{
    public static ClientSpawner instance;

    public int MaxClientCount;
    public int curClientCount;

    [SerializeField] private List<GameObject> Clients;

    [SerializeField] private TextMeshProUGUI maxClientCount;
    [SerializeField] private TextMeshProUGUI CurClientCount;

    private void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        DisplayText();
    }

    public void NewClient()
    {
        if (!Cooking.instance.client)
        {
            Vector3 spawnpos = new Vector3(transform.position.x, Clients[0].transform.position.y, transform.position.z);
            Instantiate(Clients[Random.Range(0, Clients.Count)], spawnpos, Quaternion.identity);
        }
    }

    public void DisplayText()
    {
        CurClientCount.text = $"Выполнено заказов: {curClientCount}";
        maxClientCount.text = $"Нужно выполнить: {MaxClientCount}";
    }
}