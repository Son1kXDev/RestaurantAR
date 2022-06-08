using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MoneyText;
    [SerializeField] private TextMeshProUGUI OrderCountText;
    [SerializeField] private TextMeshProUGUI ResultText;

    public void GameEnd()
    {
        OrderCountText.text = $"Выполнено заказов: {ClientSpawner.instance.curClientCount}";
        MoneyText.text = $"Всего заработано: {Money.instance.money} руб";

        if (ClientSpawner.instance.curClientCount >= ClientSpawner.instance.MaxClientCount)
        {
            ResultText.text = $"Победа!";
        }
        else
        {
            ResultText.text = $"Поражение";
        }
    }
}