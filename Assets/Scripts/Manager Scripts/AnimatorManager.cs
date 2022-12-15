using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    Animator anim ;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayWalkAnim()
    {
        anim.Play("Walk");
    }
    public void PLayeIdleAnim()
    {
        anim.Play("Idle");
    }
}
