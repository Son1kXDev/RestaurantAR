using UnityEngine;

public class UIHelper : MonoBehaviour
{
    [SerializeField] private GameObject loadPanel;

    public void ButtonStart()
    {
        loadPanel.SetActive(true);
        loadPanel.GetComponent<AsynsLoad>().sceneName = "Game";
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonRestart()
    {
        ButtonStart();
    }

    public void ButtonMenu()
    {
        loadPanel.SetActive(true);
        loadPanel.GetComponent<AsynsLoad>().sceneName = "Menu";
    }
}