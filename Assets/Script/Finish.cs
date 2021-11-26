using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private int finishValue;
    [SerializeField] private Text scoreText;

    [SerializeField]private PlayerController playerController;

    public int score;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score = playerController.coinCount * finishValue;
            scoreText.text = score.ToString();
        }
    }
}
