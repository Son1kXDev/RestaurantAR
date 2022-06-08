using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsynsLoad : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private Slider proggresBar;

    private void Start()
    {
        StartCoroutine(AsynsLoading());
    }

    private IEnumerator AsynsLoading()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            proggresBar.value = async.progress;
            print(async.progress);
            progressText.text = $"{Mathf.RoundToInt(async.progress * 100)}%";
            yield return null;
        }
    }
}