using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    public float moveForce = 10f;
    public float bounceForce = 5f;

    private void Start()
    {

    }

    private void Update()
    {
        if (gameObject.transform.position.y < -10) 
        {
            DeleteAsteroid();
        }
        


        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);

            
            if (touch.position.x < Screen.width / 2)
            {
               
                Move(-1);
            }
            else
            {
                
                Move(1);
            }
        }
    }

    void Move(float direction)
    {
        
        Vector2 moveDirection = new Vector2(direction, 0);

        
        GetComponent<Rigidbody2D>().AddForce(moveDirection * moveForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            
            AsteroidCounter.instance.DecreaseValueToWin();
            DeleteAsteroid();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "SmallPlanet")
        {

            // –ассчитываем направление отскока
            Vector2 bounceDirection = (transform.position - collision.transform.position).normalized;

            // ѕримен€ем силу отскока с использованием AddForce
            GetComponent<Rigidbody2D>().AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }


    private void DeleteAsteroid()
    {
        
        Destroy(gameObject);
        AsteroidCreator.instance.isActiveTouch = true;
    }
}
