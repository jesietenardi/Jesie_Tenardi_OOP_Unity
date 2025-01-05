using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public PlayerMovement playerMovementComponent;
    private Animator movementAnimator;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        playerMovementComponent = GetComponent<PlayerMovement>();
        movementAnimator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerMovementComponent.Move();
    }

    void LateUpdate()
    {
        movementAnimator.SetBool("IsMoving", playerMovementComponent.IsMoving());
    }
}
