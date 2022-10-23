using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class NewBoxMovement : MonoBehaviour
{
    public static NewBoxMovement instance;

    public bool isReleased;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.position.x+0.1 <= transform.position.x || collision.collider.transform.position.x -0.1 > transform.position.x)
        {
            return;
        }

        if (collision.collider.CompareTag("Exit"))
        {
            ReleaseBox();
        }
    }

    IEnumerator FinalMove()
    {
        yield return new WaitForSeconds(1);
        transform.DOMove(GameManager.instance.FinalPos.position, 1f);
    }
    public void Win()
    {
        UIManager.instance.Win.SetActive(true);
    }
    public void Lose()
    {
        UIManager.instance.Lose.SetActive(true);
    }

    public void ReleaseBox()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.position.x + 0.1 <= transform.position.x || other.transform.position.x - 0.1 > transform.position.x)
        {
            return;
        }

        if (other.CompareTag("Exit"))
        {
            ReleaseBox();
        }
    }
}
