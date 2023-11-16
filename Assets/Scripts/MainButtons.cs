using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
   // private SceneLoader loader;
    [SerializeField] GameObject optionUI;
    [SerializeField] GameObject menuUI;


    public void PlayGame()
    {
        SceneLoader.instance.LoadScene("Level");
    }

    public void LoadShop()
    {
        SceneLoader.instance.LoadScene("Shop");
    }
    public void LoadOption()
    {
        optionUI.SetActive(true);
        menuUI.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneLoader.instance.LoadScene("Menu");
        optionUI.SetActive(false);
        menuUI.SetActive(true);
    }
}
