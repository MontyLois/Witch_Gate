using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Character_Explor_Depth : MonoBehaviour
{

    private float xspeed;
    private float yspeed;
    private float zspeed;
    private InputAction moveAction;

    private bool isGrounded;

    private Rigidbody rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindActionMap("Player").FindAction("3DMovement");
        xspeed = 150;
        yspeed = 80;
        zspeed = 150;
        isGrounded = true;
    }

    private void OnDisable()
    {
        moveAction = null;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FlipSprite();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + (GetMovement()*Time.deltaTime));
        //transform.DOMove(this.transform.position + (GetMovement()*Time.deltaTime), 1);
    }
    private Vector3 GetTargetDirection() => new Vector3()
    {
        x = moveAction.ReadValue<Vector3>().x,
        y = 0,
    };

    private Vector3 GetMovement() => new Vector3()
    {
        x = moveAction.ReadValue<Vector3>().x*xspeed,
        y = isGrounded? Mathf.Max(0f,moveAction.ReadValue<Vector3>().y*yspeed):moveAction.ReadValue<Vector3>().y*yspeed,
        z = moveAction.ReadValue<Vector3>().z*zspeed,
    };

    private void FlipSprite()
    {
        float x = moveAction.ReadValue<Vector3>().x;
        if (x != 0)
        {
            spriteRenderer.flipX = (x>0);
        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Grounded",isGrounded);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("Grounded",isGrounded);
        }
    }
}
