using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerMain : MonoBehaviour
{
    [SerializeField] public float countdownTime = 6f; 
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] public GameObject ability;
    public static TimerMain instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (countdownTime >= 0)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1.0f);
            countdownTime--;
        }

        Debug.Log("Время вышло!");
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime()
    {
        countdownTime += 120f;
        ability.SetActive(false);
        
    }
}
