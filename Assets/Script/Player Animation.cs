using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public enum state { idle, walk, jump, fall,dash };
    public state playerState;
    private Animator playerAnimator;
    private PlayerMovement player;
    public SpriteRenderer playerSr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<Animator>();
        playerSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animationControl();
    }
    private void animationControl()
    {
        if (player.xRaw != 0)
        {
            playerState = state.walk;
        }
       
        else
        {
            playerState = state.idle;
        }

       
       if (player.floating || player.isTryingToJumpDuringDash || player.isDashing)
        {
            playerState = state.dash;
        }
        else if (player.isFalling)
        {
            playerState = state.fall;
        }
        else if (player.isJumping || player.isJumpCut || player.isWallJumping)
        {
            playerState = state.jump;
        }
        //else if (player.isSliding)
        //{
        //    playerState = state.wallSlide;
        //    playerSr.flipX = true;

        //}
        //else if (!player.isSliding)
        //{
        //    playerSr.flipX = false;
        //}

        playerAnimator.SetInteger("playerState", (int)playerState);
    }
}
