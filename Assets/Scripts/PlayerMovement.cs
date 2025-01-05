using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;        
    [SerializeField] private Vector2 timeToFullSpeed; 
    [SerializeField] private Vector2 timeToStop;      
    [SerializeField] private Vector2 stopClamp;       

    private Vector2 moveDirection;   
    private Vector2 moveVelocity;    
    private Vector2 moveFriction;    
    private Vector2 stopFriction;    
    private Rigidbody2D rb;          

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }
    public void Move()
    {

    
    float xInput = Input.GetAxis("Horizontal");
    float yInput = Input.GetAxis("Vertical");
    moveDirection = new Vector2(xInput, yInput).normalized;

    
    Vector2 appliedFriction = (moveDirection == Vector2.zero) ? stopFriction : moveFriction;

    
    Vector2 finalVelocity = (moveDirection * maxSpeed) - (appliedFriction * Time.fixedDeltaTime);

    
    rb.velocity = new Vector2(
        Mathf.Clamp(finalVelocity.x, -maxSpeed.x, maxSpeed.x),
        Mathf.Clamp(finalVelocity.y, -maxSpeed.y, maxSpeed.y)
    );

    
    if (Mathf.Abs(rb.velocity.x) < stopClamp.x && Mathf.Abs(rb.velocity.y) < stopClamp.y)
    {
        rb.velocity = Vector2.zero;
    }
}


    Vector2 GetFriction()
    {
       
    if (moveDirection == Vector2.zero)
    {
        return stopFriction;
    }
    else
    {
        return moveFriction;
    }
    }

    /*void MoveBound()
    {
        
    }*/

    public bool IsMoving()
    {
        
        return rb.velocity != Vector2.zero;
    }

}
