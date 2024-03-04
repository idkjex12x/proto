using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement  : MonoBehaviour
{
    public float playerspeed;
    private  Rigidbody2D rb;
    public Vector2 playerDirection;

    bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;
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
}