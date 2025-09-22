using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Explor_Depth : MonoBehaviour
{
    
    public PlayerInput PlayerInput { get; private set; }

    private float xspeed;
    private float yspeed;
    private float zspeed;
    private InputAction moveAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = PlayerInput.actions.FindActionMap("Player").FindAction("Move");
        xspeed = 3;
        yspeed = 0;
        zspeed = (float)1.5;
    }

    private void OnDisable()
    {
        moveAction = null;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.DOMove(this.transform.position + (GetMovement()), 1);
    }
    private Vector2 GetTargetDirection() => new Vector2()
    {
        x = moveAction.ReadValue<Vector2>().x,
        y = 0,
    };

    private Vector3 GetMovement() => new Vector3()
    {
        x = moveAction.ReadValue<Vector2>().x*xspeed,
        y = 0,
        z = moveAction.ReadValue<Vector2>().y*zspeed,
    };
}
