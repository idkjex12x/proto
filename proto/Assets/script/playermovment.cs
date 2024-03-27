using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement  : MonoBehaviour
{
// Relates to animation controller //
    

    public float playerspeed;
    private  Rigidbody2D rb;
    public Vector2 playerDirection;
    private Animator anim;
    float directionX;
    float directionY;


    bool facingLeft = true;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");
        //anim.SetFloat("xSpeed", directionX);
        //anim.SetFloat("ySpeed", directionY);

        playerDirection = new Vector2(directionX, directionY).normalized;
        IsRunning();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerspeed, playerDirection.y * playerspeed);

        

        

// the script down here flips the player sprite when moving
        if (playerDirection.x > 0 && facingLeft)
        {
            Flip();
        }
        if (playerDirection.x < 0 && !facingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }

    private void IsRunning()
    {
        if ((directionX < 0 || directionY < 0 || directionX > 0 || directionY > 0))
        { 
            anim.SetBool("isRunning", true);
        }

        if (directionX == 0 && directionY == 0)
        {
            anim.SetBool("isRunning", false);
        }
    }
 }