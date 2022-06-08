using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MoneyText;
    [SerializeField] private TextMeshProUGUI OrderCountText;
    [SerializeField] private TextMeshProUGUI ResultText;

    public void GameEnd()
    {
        OrderCountText.text = $"��������� �������: {ClientSpawner.instance.curClientCount}";
        MoneyText.text = $"����� ����������: {Money.instance.money} ���";

        if (ClientSpawner.instance.curClientCount >= ClientSpawner.instance.MaxClientCount)
        {
            ResultText.text = $"������!";
        }
        else
        {
            ResultText.text = $"���������";
        }
    }
}