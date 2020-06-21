﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

     [SerializeField]
    private float speed;

    protected Vector3 change;

    private Rigidbody2D myRigidbody;

    protected Animator animator;

    public bool isMoving
    {
        get
        {
        return change.x != 0 || change.y != 0;
        }
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {  
        AnimateMovement(change);
    }  

    public void AnimateMovement(Vector3 change)
    {
        if ((Vector3)change != Vector3.zero)
        {
            Move();
            animator.SetFloat("x", change.x);
            animator.SetFloat("y", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

    }

    public void Move()
    {
        myRigidbody.MovePosition(
        transform.position + change.normalized*speed*Time.deltaTime
        );

    }
}
