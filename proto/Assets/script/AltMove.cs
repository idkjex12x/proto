using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltMove : MonoBehaviour
{
    // Relates to animation controller //
    public enum PlayerState
    {
        Idle,
        Run,
        Kick
    }
    PlayerState state;

    bool stateComplete;

    public float playerspeed;
    private Rigidbody2D rb;
    public Vector2 playerDirection;
    private Animator anim;

    bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        anim.SetFloat("xSpeed", rb.velocity.x);
        anim.SetFloat("ySpeed", rb.velocity.y);

        if (stateComplete)
        {
            SelectState();
        }
        UpdateState();
        // Relates to player animations //
        void SelectState()
        {
            stateComplete = false;

            if (!Input.GetKeyDown("Space"))
            {
                if (playerDirection.x == 0)
                    if (playerDirection.y == 0)
                    {
                        state = PlayerState.Idle;

                    }
                    else
                    {
                        state = PlayerState.Run;
                    }
            }
            else
            {
                state = PlayerState.Kick;
            }
        }

        void UpdateState()
        {
            switch (state)
            {
                case PlayerState.Idle:
                    UpdateIdle();
                    break;
                case PlayerState.Run:
                    UpdateRun();
                    break;
                case PlayerState.Kick:
                    UpdateKick();
                    break;
            }
        }

        void UpdateIdle()
        {
            if (playerDirection.x != 0)
                if (playerDirection.y != 0)
                    stateComplete = true;
            state = PlayerState.Run;
        }

        void UpdateRun()
        {
            if (playerDirection.x == 0)
                if (playerDirection.y == 0)
                    stateComplete = true;
            state = PlayerState.Idle;
        }

        void UpdateKick()
        {
            if (Input.GetKeyDown("Space")) ;
            stateComplete = true;
            state = PlayerState.Kick;
        }
        //////////////////////////////////
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