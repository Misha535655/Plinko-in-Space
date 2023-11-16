using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AsteroidCreator : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    public static AsteroidCreator instance;
    public bool isActiveTouch;
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

    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && isActiveTouch)
            {
                
                CreatorAsteroid(asteroid);
                isActiveTouch = false;
            }
        }

    }

    public void CreatorAsteroid(GameObject asteroid)
    {
        if (isActiveTouch)
        {
            Instantiate(asteroid, transform.position, Quaternion.identity);
        }
        
    }

}