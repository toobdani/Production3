using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_State_Controler : MonoBehaviour
{
    public movementTest PlayerHitbox;
    Animator animator;

    [SerializeField] bool Lobby;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey("w"))
        {
            animator.SetBool("isWalking", true);
        }

        else if (Input.GetKey("a"))
        {
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey("s"))
        {
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey("d"))
        {
            animator.SetBool("isWalking", true);
        }

        else
        {
            animator.SetBool("isWalking", false);
        }

        if (animator.GetBool("roomRotate"))
        {
            if (animator.GetBool("onGround"))
            {
                animator.SetBool("roomRotate", false);
            }
        }

        if(Lobby == false)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                animator.SetBool("roomRotate", true);
            }

            if (PlayerHitbox.MoveAllow == 0)
            {
                animator.SetBool("onGround", true);
            }

            else
            {
                animator.SetBool("onGround", false);
            }
        }
    }
}
