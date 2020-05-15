using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Ball : MonoBehaviour
{
    public float moveSpeed;
    
    private Vector3 change;
    

    private Rigidbody2D rb;

    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        change = new Vector3(Random.Range(-1f, 1f), Random.Range(-.5f, .5f), 0);
        

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MoveBall();
    }

    private void MoveBall()
    {
        change.Normalize();
        rb.MovePosition(transform.position + change * moveSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Paddle");
            change.x *= -1;
           
        }
        else if (collision.CompareTag("Wall"))
        {
            FindObjectOfType<AudioManager>().Play("Wall");
            change.y *= -1;
            
        }
        else if(collision.CompareTag("Score Left"))
        {
            FindObjectOfType<GameManager>().PlayerTwo();
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Score Right"))
        {
            FindObjectOfType<GameManager>().PlayerOne();
            Destroy(gameObject);
        }
    }
}
