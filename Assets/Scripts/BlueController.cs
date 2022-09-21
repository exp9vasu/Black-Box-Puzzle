using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueController : MonoBehaviour
{
    Rigidbody rb;
    public int speed = 5;
    public float horizontal, vertical;
    public Vector2 lastPos, currentPos, swipe;
    Vector3 force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Vector3 move = new Vector3(horizontal, 0, vertical);
        //rb.MovePosition(transform.position + move * Time.deltaTime* speed);

        if (Input.GetMouseButton(0))
        {
            //lastPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentPos = Input.mousePosition;

            swipe = (Vector2)Input.mousePosition - lastPos;

            if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
            {
                force = new Vector3(swipe.x, 0, 0) * speed;
            }
            else if (Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x))
            {
                force = new Vector3(0, 0, swipe.y) * speed;
            }

            rb.MovePosition(force);
        }
        
    }

    private void OnMouseDown()
    {
        lastPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
    
    private void OnMouseDrag()
    {
        //swipe = (Vector2)Input.mousePosition - lastPos;

        //horizontal = swipe.x;
        //vertical = swipe.y;
    }

    private void OnMouseUp()
    {
        lastPos = Vector2.zero;
        
    }
}
