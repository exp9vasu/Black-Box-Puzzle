using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class NewBoxMovement : MonoBehaviour
{
    public bool isReleased;

    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.position.x+0.1 <= transform.position.x || collision.collider.transform.position.x -0.01 > transform.position.x)
        {
            return;
        }

        if (collision.collider.CompareTag("Exit"))
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

            //GameManager.instance.Trophy.SetActive(true);
            //int temp = PlayerPrefs.GetInt("Level");
            //PlayerPrefs.SetInt("Level", temp + 1);

            Invoke("Win", 4);

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
}
