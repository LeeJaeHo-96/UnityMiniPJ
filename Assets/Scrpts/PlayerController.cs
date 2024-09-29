using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 3;


    Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
       
        Move();


    }

    


    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward.normalized * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right* x * moveSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 6;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3;
        }
        animator.SetFloat("moveSpeed", moveSpeed);

        if(new Vector3(x, 0 ,z) == Vector3.zero)
        {
            animator.SetFloat("moveSpeed", 0);
            

        }
        if (new Vector3(x, 0, z) == Vector3.forward)
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Back", false);
        }

        if (new Vector3(x, 0, z) == Vector3.left)
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Back", false);
        }
        if (new Vector3(x, 0, z) == Vector3.right)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Back", false);
        }
        if (new Vector3(x, 0, z) == Vector3.down)
        {
            animator.SetBool("Back", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }


    }
}
