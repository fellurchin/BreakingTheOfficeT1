using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimatorControllerScript : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        
    }

    void Update()
    {
        animator.SetBool("Attack", true);
    }
}
