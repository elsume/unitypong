using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleController : MonoBehaviour
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

    protected virtual string GetInputAxisName()
    {
        return "";
    }
}
