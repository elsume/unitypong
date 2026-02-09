using UnityEngine;

public class ballMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5.0f;
    private Vector2 direction;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(3f, 3f).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ICollidable collidable = collision.gameObject.GetComponent<ICollidable>();
        if (collidable != null)
        {
            collidable.OnHit(collision);
        }
        
        OnHit(collision);
    }

    public void OnHit(Collision2D collision)
    {
        if (collision.gameObject.name == "top" || collision.gameObject.name == "bottom")
        {
            direction = new Vector2(direction.x, -direction.y);
        }
        else if (collision.gameObject.name == "paddleL" || collision.gameObject.name == "paddleR")
        {
            direction = new Vector2(-direction.x, direction.y);
        }
        
        direction = direction.normalized;
    }
}