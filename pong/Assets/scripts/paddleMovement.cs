using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 currentPosition = transform.position;
        currentPosition.y += verticalInput * speed * Time.deltaTime;
        currentPosition.y = Mathf.Clamp(currentPosition.y, -4f, 4f);
        transform.position = currentPosition;
    }

}
