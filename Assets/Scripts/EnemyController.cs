using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Variables
    private Vector2 directionX = new Vector2(1, 0);
    private Vector2 directionY = new Vector2(0, -1);
    private bool shouldFlip = false;
    private float timer = 0f;

    public int speed;
    public float castLength;
    public int idleTimer;

    public Transform origin;

    private Rigidbody2D rb;
    private Animator anim;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        Debug.DrawRay(origin.position, directionX * castLength);
        Debug.DrawRay(origin.position, directionY * castLength);

        RaycastHit2D hitY = Physics2D.Raycast(origin.position, directionY, castLength);
        RaycastHit2D hitX = Physics2D.Raycast(origin.position, directionX, castLength);
        if (hitY == false) //Reached end of platform
        {
            Move(false);
            timer += Time.deltaTime;
            if (timer >= idleTimer)
            {
                timer = 0;
                shouldFlip = true;
            }      
        }
        else if(hitX == true && hitX.collider.tag != "Enemy") //Hit a wall or object
        {
            Move(false);
            timer += Time.deltaTime;
            if (timer >= idleTimer)
            {
                timer = 0;
                shouldFlip = true;
            } 
        }
        else
        {
            Move(true);
        }
    }

    private void FixedUpdate()
    {
        if (shouldFlip)
        {
            FlipSprite();
        }
    }
    void Move(bool move)
    {
        if (move)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetBool("isRunning", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("isRunning", false);
        }
    }
    void FlipSprite()
    {
        speed *= -1;
        directionX *= -1;
        shouldFlip = false;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
}
