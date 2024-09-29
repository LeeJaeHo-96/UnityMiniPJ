using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 3;
    Rigidbody rigid;

    Vector3 dir = Vector3.zero;

    Animator animator;



    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Turn();
        TMove();


    }

    private void FixedUpdate()
    {
        //Move();
    }

    private void Move()
    {
        
        rigid.MovePosition(rigid.position + dir * moveSpeed * Time.deltaTime);
        if (dir != Vector3.zero)
        {
            animator.SetFloat("moveSpeed", moveSpeed);
        }
        else
        {
            animator.SetFloat("moveSpeed", 0);
        }
    }

    private void Turn()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        if (dir != Vector3.zero)
        {
            transform.forward = dir.normalized;
        }
    }

    private void TMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward.normalized * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right.normalized * x * moveSpeed * Time.deltaTime);

    }
}
