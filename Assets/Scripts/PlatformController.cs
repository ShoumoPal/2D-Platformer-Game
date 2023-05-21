using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool hasCollided = false;
    private float timeDelay = 0;

    private void Update()
    {
        if (hasCollided)
        {
            Move(0);
            if(timeDelay > 2f)
            {
                hasCollided = false;
                speed *= -1;
                timeDelay = 0;
            }
            else
            {
                timeDelay += Time.deltaTime;
            }
        }
        else
        {
            Move(speed);
        }
    }
    private void Move(float _speed)
    {
        Vector3 temp = transform.position;
        temp.x += _speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("Platform collided!");
            hasCollided = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = this.transform;
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
