using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle2 : MonoBehaviour
{
    public float moveSpeed;
    
    Vector3 change;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        change.x = 0;
        MovePosition();
    }

    private void MovePosition()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            change.y = moveSpeed;
            rb.MovePosition(transform.position + change * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            change.y = -moveSpeed;
            rb.MovePosition(transform.position + change * Time.deltaTime);
        }
        else
        {
            change = Vector3.zero;
        }
    }
}
