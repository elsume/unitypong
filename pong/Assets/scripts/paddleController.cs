using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public abstract class paddleController : NetworkBehaviour, ICollidable
{
    protected float speed = 8f;
    protected Rigidbody2D rb;

    private NetworkVariable<float> networkPositionY = new NetworkVariable<float>(
        0f, 
        NetworkVariableReadPermission.Everyone, 
        NetworkVariableWritePermission.Owner
    );

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void OnNetworkSpawn()
    {
        if (OwnerClientId == 0)
        {
            // Host paddle - left side
            transform.position = new Vector3(-8f, 0f, 0f);
            gameObject.name = "paddleL";
            Debug.Log("Host paddle spawned - use W/S");
        }
        else
        {
            // Client paddle - right side
            transform.position = new Vector3(8f, 0f, 0f);
            gameObject.name = "paddleR";
            Debug.Log("Client paddle spawned - use Up/Down");
        }
        
        networkPositionY.Value = transform.position.y;
    }

    void FixedUpdate()
    {
        if (IsOwner)
        {
            float input = Input.GetAxis(GetInputAxisName());
            rb.velocity = new Vector2(0, input * speed);
            
            networkPositionY.Value = transform.position.y;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y = networkPositionY.Value;
            transform.position = pos;
        }
    }

    protected abstract string GetInputAxisName();

    public void OnHit(Collision2D collision)
    {
        Debug.Log(gameObject.name + " was hit by Ball");
    }
}
