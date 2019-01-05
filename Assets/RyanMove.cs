using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyanMove : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rigidbody2D;

    float horizontalMove = 0f;
    float runSpeed = 40f;
    float jumpTotal = 0;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
       
        if (Input.GetButtonDown("Jump"))
        {
            jumpTotal += 1;
            jump = true;
            animator.SetBool("Jump", true);

            /*
            if(jumpTotal >= 2)
            {
                controller.Move(horizontalMove, false, true);

            }
            */
        }
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
        jumpTotal = 0;
        jump = false;
    }

    private void FixedUpdate()
    {
        // Moves our character
        controller.Move(horizontalMove, false, jump);
        //jump = false;
    }
}
