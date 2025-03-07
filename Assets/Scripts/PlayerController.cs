using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Animator anim;
    public float speed;
    public float jump;
    public int lives;
    private Rigidbody2D playerRb;
    private bool isGrounded;
    public float deathHeight;

    private void Awake()
    {
        playerRb= GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //For death after falling
        if(!isGrounded && transform.position.y < deathHeight)
        {
            Die();
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        
        PlayMovementAnimation(horizontal, vertical);
        PlayerMovement(horizontal, vertical); 
    }
    public void PickUpKey()
    {
        //Key pickup logic
        SoundManager.Instance.Play(Sounds.Pickup);
        scoreController.IncreaseScore(10);
    }
    void Die() // Just for debug message when falling off platform
    {
        lives = 0;
        KillPlayer();
        Debug.Log("Player has died...");
    }
    public void PlayMovementAnimation(float horizontal, float vertical)
    {
        //For jump
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        if (vertical > 0 && isGrounded)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        //Turning Character
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            if (!SoundManager.Instance.isPlayingFootstep() && isGrounded)
                SoundManager.Instance.PlayFootstep();

            scale.x = -1f * Mathf.Abs(horizontal);
        }
        else if (horizontal > 0)
        {
            if(!SoundManager.Instance.isPlayingFootstep() && isGrounded)
                SoundManager.Instance.PlayFootstep();

            scale.x = Mathf.Abs(horizontal);
        }
        else
        {
            SoundManager.Instance.StopFootstep();
        }
        transform.localScale = scale;

        //For crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", true);
        }
        else
        {
            anim.SetBool("Crouch", false);
        }
    }

    public void PlayerMovement(float horizontal, float vertical)
    {
        //Horizontal movement
        Vector3 temp = transform.position;
        temp.x += horizontal * speed * Time.deltaTime;
        transform.position = temp;

        //Vertical movement
        if(isGrounded)
        {
            playerRb.AddForce(Vector2.up * jump * vertical, ForceMode2D.Impulse);
            //isGrounded = false;
        }
    }

    public void KillPlayer()
    {
        if(lives == 0)
        {
            anim.SetTrigger("isDead");
            Debug.Log("Player is killed..");
            gameOverController.PlayerHasDied();
            this.enabled = false;
        }
        else
        {
            lives--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Grounded logic
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
