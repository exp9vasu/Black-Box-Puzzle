using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour
{
    public static Ballcontroller instance;

    //public EnemyController enemyController;

    private float thrust = 40f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float wallDistance = 5f;
    [SerializeField] private float minCamDistance = 3f;
    public bool onObject;
    private Vector3 force;

    private Vector2 lastMousePos;
    public GameObject RivalBall;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseExit()
    {
        lastMousePos = Vector2.zero;
        onObject = false;
    }

    private void OnMouseOver()
    {
        //onObject = true;
    }

    private void OnMouseDrag()
    {
        //onObject = true;
    }
    private void OnMouseUp()
    {
        lastMousePos = Vector2.zero;
        //onObject = false;
    }
    private void OnMouseDown()
    {
        onObject = true;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!onObject)
        {
            return;
        }

        Vector2 deltaPos = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            //RivalBall.GetComponent<Animator>().enabled = true;

            Vector2 currentmousePos = Input.mousePosition;

            if (lastMousePos == Vector2.zero)
                lastMousePos = currentmousePos;

            deltaPos = currentmousePos - lastMousePos;
            lastMousePos = currentmousePos;

            force = new Vector3(deltaPos.x, 0, deltaPos.y) * thrust;
            
            rb.AddForce(force);

            //rb.MovePosition(force);

            //rb.transform.Translate()

            /*if (Mathf.Abs(deltaPos.x) > Mathf.Abs(deltaPos.y))
            {
                force = new Vector3(deltaPos.x, 0, 0) * thrust;
            }
            else if (Mathf.Abs(deltaPos.y) > Mathf.Abs(deltaPos.x))
            {
                force = new Vector3(0, 0, deltaPos.y) * thrust;
            }*/
        }
        else
        {
            lastMousePos = Vector2.zero;
        }
    }

    private void LateUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {    
    
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }*/
}