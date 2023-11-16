using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIControl : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] Slider slider;
    [SerializeField] GameObject sliderActive;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject winPanelUI;
    [SerializeField] TextMeshProUGUI wintext;

    private void Update()
    {
        if (TimerMain.instance.countdownTime % 10 == 0)
        {

            StartCoroutine(StartSliderAnimation());
            StartCoroutine(Gravity());
        }
        ActiveateWinPanel();
    }

    IEnumerator StartSliderAnimation()
    {
        sliderActive.SetActive(true);
        slider.value = 3f;

        yield return StartCoroutine(SmoothSliderDecrease());

        sliderActive.SetActive(false);
    }

    IEnumerator SmoothSliderDecrease()
    {
        float duration = 3f;
        float initialValue = slider.value;
        float targetValue = 0f;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float progress = (Time.time - startTime) / duration;
            slider.value = Mathf.Lerp(initialValue, targetValue, progress);
            yield return null;
        }

        slider.value = targetValue;
    }

    IEnumerator Gravity()
    {
        Physics2D.gravity = new Vector2(0, -1f);
        yield return new WaitForSeconds(3f);
        Physics2D.gravity = new Vector2(0, -9.81f);
    }

    public void TogglePause()
    {
        
        isPaused = !isPaused;
        pauseUI.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0;
            Debug.Log("Игра на паузе");
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("Игра продолжается");
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 0;
        SceneLoader.instance.LoadScene("Menu");
    }

    public void ActiveateWinPanel()
    {
        if (winPanelUI.active)
        {
            return;
        }
        if (AsteroidCounter.instance.valueToWin == 0)
        {
            winPanelUI.SetActive(true);
            Time.timeScale = 0;
            wintext.text = "You Win!";
        }
        if(TimerMain.instance.countdownTime == 0) 
        {
            winPanelUI.SetActive(true);
            Time.timeScale = 0;
            wintext.text = "You Lose!";
        }
        
    }


}
