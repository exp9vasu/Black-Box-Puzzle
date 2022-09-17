using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RedBoxController : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 offset;
    public Vector3 startPos, initialPos;
    public bool isReleased;
    
    private void Start()
    {
        initialPos = transform.position;
        startPos = transform.position;
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        initialPos = transform.position;

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = Vector3.zero;
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        //curPosition.z = curPosition.y;

        curPosition.y = startPos.y;
        transform.position = curPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.CompareTag("Exit"))
            {
                if (transform.name == "Red")
                {
                    isReleased = true;
                    print("red");
                    //transform.position = Vector3.Lerp(transform.position, GameManager.instance.EndPos.position, 0.1f);
                    transform.DOMove(GameManager.instance.EndPos.position, 1f);
                    transform.GetComponent<Rigidbody>().freezeRotation = false;

                    transform.GetComponent<Rigidbody>().isKinematic = true;
                    transform.GetComponent<Rigidbody>().useGravity = false;
                    transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                    StartCoroutine(FinalMove());

                    GameManager.instance.PaticlFX.SetActive(true);
                    transform.GetComponent<Collider>().enabled = false;

                    Invoke("Win", 4);
                }
                else
                {
                    //Invoke("Lose", 2);
                    print("Fail");
                }

                
            }
        }
    }

    IEnumerator FinalMove()
    {
        yield return new WaitForSeconds(1);
        transform.DOMove(GameManager.instance.FinalPos.position, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Boundary") && !isReleased)
        {
            transform.DOMove(initialPos, 0.5f);
        }
        if (collision.transform.CompareTag("Block"))
        {
            transform.DOMove(startPos, 0.5f);
        }
    }

    public void Win()
    {
        UIManager.instance.Win.SetActive(true);
    }
    public void Lose()
    {
        UIManager.instance.Lose.SetActive(true);
    }
}
