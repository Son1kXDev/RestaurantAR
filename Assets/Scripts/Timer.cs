using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI TimerText;

    private void Start()
    {
        time = 180;
    }

    private void Update()
    {
        Tick();
    }

    private void Tick()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            GameEvents.instance.GameOver.Invoke();
            Destroy(this);
        }
        DisplayText(time);
    }

    private void DisplayText(float time)
    {
        time += 1;
        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}