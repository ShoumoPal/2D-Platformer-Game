using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float maxHeight = 3.2f;
    private float minHeight = -1.3f;
    private float timeSpent = 0f;

    private void Update()
    {
        if (transform.position.y > maxHeight || transform.position.y < minHeight)
        {
            MoveVertical(0);
            if (timeSpent > 2f)
            {
                timeSpent = 0;
                speed *= -1;
                MoveVertical(speed);
            }
            else
            {
                timeSpent += Time.deltaTime;
            }
        }
        else
        {
            MoveVertical(speed);
        }
    }

    private void MoveVertical(float speed)
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
