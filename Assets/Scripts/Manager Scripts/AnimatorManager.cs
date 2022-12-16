using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    Animator anim ;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayWalkAnim()
    {
        anim.Play("Walk");
        // anim.SetBool("IsWalk",true);
    }
    public void PLayeIdleAnim()
    {
        anim.Play("Idle");
        // anim.SetBool("IsWalk",false);
    }
}
