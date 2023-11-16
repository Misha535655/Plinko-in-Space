using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidCounter : MonoBehaviour
{
    [SerializeField] List<Sprite> Numbers;
    public static AsteroidCounter instance;
    [SerializeField] public int valueToWin;
    [SerializeField] Image counterUI;
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

    // Update is called once per frames
    void Update()
    {
        counterUI.sprite = Numbers[valueToWin];
    }

    public void DecreaseValueToWin()
    {
        if(valueToWin > 0)
        {
            valueToWin--;
        }
        
    }
}
