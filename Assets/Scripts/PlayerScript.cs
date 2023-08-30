using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    public float jump;

    public LayerMask ground;
    public LayerMask deathGround;

    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Animator animator;

    public AudioSource deathSound;
    public AudioSource jumpSound;

    public float mileStone;
    public float speedMultiplier;
    private float mileStoneCount;

    public GameOverScript gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        mileStoneCount = mileStone;
    }

    // Update is called once per frame
    void Update()
    {

        bool death = Physics2D.IsTouchingLayers(playerCollider, deathGround);

        if(death)
        {
            GameOver();
        }

        if (transform.position.x > mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed *= speedMultiplier;
            mileStone += mileStone * speedMultiplier;
            Debug.Log("M" + mileStone + ", MC" + mileStoneCount + ", MS" + speed);
        }

        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);

        bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded)
            {
                jumpSound.Play();
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
            }            
        }

        animator.SetBool("Grounded", grounded);
    }

    void GameOver() 
    {
        gameOver.GameOver();
    }
}
