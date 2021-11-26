using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject plusOneCanvas;
    [SerializeField] private GameObject fail;
    [SerializeField] private GameObject success;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private Text coinCountText;

    public int coinCount;
    public bool isFall;
    public bool isFinish;
    [SerializeField]private PlayerMovement playerMovement;

    private void Start()
    {
        coinCount = 0;
    }

    IEnumerator CanvasActive()
    {
        yield return new WaitForSeconds(0.5f);
        plusOneCanvas.SetActive(false);

    }

    // TriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.transform.position = transform.GetChild(transform.childCount - 1).position;
            transform.position += new Vector3(0, 1f, 0);
            other.transform.parent = transform;
            other.tag = "Player";
            plusOneCanvas.SetActive(true);
            StartCoroutine(CanvasActive());
            other.isTrigger = false;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            if (transform.childCount > 1)
            {
                Destroy(transform.GetChild(transform.childCount - 1).gameObject);
                transform.position += new Vector3(0, -1f, 0);
                transform.GetChild(transform.childCount - 1).parent = transform;
                Destroy(other.gameObject);
            }
            else
            {
                playerMovement.canMove = false;
                isFall = true;
                retryButton.SetActive(true);

            }
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            coinCountText.text = coinCount.ToString();
            Destroy(other.gameObject);

        }
        
        else if (other.gameObject.CompareTag("FastPlatform"))
        {
            playerMovement.speed = 32;
        }
        
    }

    //Trigger Exit
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wheel"))
        {
            if (transform.childCount > 1)
            {
                Destroy(transform.GetChild(transform.childCount - 1).gameObject);
                transform.position += new Vector3(0, -1f, 0);
                transform.GetChild(transform.childCount - 1).parent = transform;
            }
            else
            {
                playerMovement.canMove = false;
                isFall = true;
                retryButton.SetActive(true);

            }
        }
    }

    // Collision Enter
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (transform.childCount > 1)
            {
                transform.GetChild(transform.childCount - 1).parent = null;
            }
            else
            {
                Debug.Log("duvadfr");
                isFall = true;
                //Retry
                playerMovement.canMove = false;
                retryButton.SetActive(true);

            }
        }
        
         else if (collision.gameObject.CompareTag("Finish"))
         {
             if (transform.childCount > 1)
             {
                 transform.GetChild(transform.childCount - 1).parent = null;
             }
             else
             {
                isFinish = true;
                success.SetActive(true);
                playerMovement.canMove = false;

             }
        }
        else if (collision.gameObject.CompareTag("FinishEnd"))
        {
           
                isFinish = true;
                success.SetActive(true);
                playerMovement.canMove = false;
               
            

        }
    }
    
}
