using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class JSONParser : MonoBehaviour
{
    public static JSONParser instance;

    public Responce responce;

    [SerializeField] private string url = "https://raw.githubusercontent.com/jkl5252/WSR/main/Recipes.json";

    private Recipe lastRecipe;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;

        StartCoroutine(GetJSON());
    }

    public Recipe GenerateNewRecipe()
    {
        Recipe newRecipe = responce.recipes[Random.Range(0, responce.recipes.Length)];

        if (newRecipe.title == lastRecipe.title) return GenerateNewRecipe();
        else
        {
            lastRecipe = newRecipe;
            return newRecipe;
        }
    }

    private IEnumerator GetJSON()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError || request.isNetworkError)
            Debug.LogError("Downloading Error");
        else Debug.Log("Downloading Done!");

        responce = JsonUtility.FromJson<Responce>(request.downloadHandler.text);
    }
}