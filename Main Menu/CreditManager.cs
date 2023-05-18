using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script to handle the scrolling credits
/// </summary>


public class CreditManager : MonoBehaviour
{
    public Animator creditAnim;


    public void OpenCredits()
    {
        creditAnim.SetTrigger("open");
    }


    public void CloseCredits()
    {
        creditAnim.SetTrigger("close");
    }
}
