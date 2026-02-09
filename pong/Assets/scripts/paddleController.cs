using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class paddleController : MonoBehaviour, ICollidable
{
    protected float speed = 8f;
    protected Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float input = Input.GetAxis(GetInputAxisName());
        
        rb.velocity = new Vector2(0, input * speed);
    }

    protected abstract string GetInputAxisName();

    public void OnHit(Collision2D collision)
    {
        Debug.Log(gameObject.name + " was hit by Ball");
    }
    
}
