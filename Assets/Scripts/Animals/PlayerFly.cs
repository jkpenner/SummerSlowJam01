﻿using UnityEngine;
using System.Collections;

public class PlayerFly : MonoBehaviour {

    public float flyForce = 2000f;

    Rigidbody2D rigidBody;
    Animator animator;
    string flyInput;
    float distToGround;

    // Use this for initialization 
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        flyInput = PlayerManager.GetPlayerInputStr(gameObject.GetComponent<InputMapper>().playerNumber, "A");
        distToGround = gameObject.GetComponent<CircleCollider2D>().bounds.extents.y;
    }

    // Update is called once per frame 
    void Update()
    {
        Fly();
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.1f);
    }

    void Fly()
    {
        if (Input.GetButtonDown(flyInput) && IsGrounded())
        {
            rigidBody.AddForce(Vector2.up * flyForce);
            animator.SetBool("isJumping", true);
            StartCoroutine("StopJump");
        }
    }

    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isJumping", false);
    }
}
