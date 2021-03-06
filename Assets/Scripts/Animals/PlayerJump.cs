﻿using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {
	public float jumpForce = 200f;
	public LayerMask layerMask;
	public AudioClip jumpSound;

	Rigidbody2D rigidBody;
	Animator animator;
    float distToGround;
    string jumpInput;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponentInChildren<Animator>();
		distToGround = gameObject.GetComponent<CircleCollider2D>().bounds.extents.y;
        jumpInput = PlayerManager.GetPlayerInputStr(gameObject.GetComponent<InputMapper>().playerId, "A");
    }
	
	// Update is called once per frame
	void Update () {
		IsGrounded();
		Jump();
	}

    bool IsGrounded()
    {
		return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f, layerMask);
    }

    void Jump(){
        //if(Input.GetButtonDown(jumpInput) && IsGrounded()) {
		if(Input.GetButtonDown(PlayerManager.GetPlayerInputStr(GetComponent<InputMapper>().playerId, "A"))  && IsGrounded()) {
			rigidBody.AddForce(Vector2.up *jumpForce);
			SoundManager.PlaySoundEffect(jumpSound);
			animator.SetBool("isJumping", true);
			StartCoroutine("StopJump");
		}
	}

	IEnumerator StopJump(){
		yield return new WaitForSeconds(0.3f);
		animator.SetBool("isJumping", false);
	}
}
