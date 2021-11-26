using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    [SerializeField] private GameObject startPanel;

    public PathCreator pathCreator;
    float distanceTravelled;

    private float min = -4.0f;
    private float max = 4.0f;
    private Vector3 newPos;
    public bool canMove;

    private void Start()
    {
        canMove = false;
    }


    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (canMove)
        {
           
           transform.Translate(0,0,1f * speed * Time.deltaTime);
           //distanceTravelled += speed * Time.deltaTime;
           //transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            if (Input.GetMouseButton(0))
            {
                float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
                swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
                transform.Translate(swerveAmount, 0, 0);

                newPos = transform.position;
                newPos.x = Mathf.Clamp(newPos.x, min, max);
                transform.position = newPos;
            }
        }
    }

   public void StartClick()
    {
        canMove = true;
        startPanel.SetActive(false);
    }

}
