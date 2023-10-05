using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public Animator animator;

    public float waitSecond;

    public bool anim = true;
    public void AnimControl(string check)
    {
        if (check == "Stop")
        {
            animator.SetBool("StartAnim", false);
            anim = false;
        }
        else if (check == "Start")
        {
            animator.SetBool("StartAnim", true);

            anim = true;
        }
        StartCoroutine(startAnim());
    }
    IEnumerator startAnim()
    {
        yield return new WaitForSeconds(waitSecond);
        AnimControl("Start");
    }
}
