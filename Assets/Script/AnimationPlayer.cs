using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Animator animator;
    public PlayerController playerController;
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        animator.SetBool("isStart", true);

        if (playerController.isFall)
        {
            animator.SetBool("isFall", true);
        }
        else if (playerController.isFinish)
        {
            animator.SetBool("isFinish", true);

        }
    }
}
