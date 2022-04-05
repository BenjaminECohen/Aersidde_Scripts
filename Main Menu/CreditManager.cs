using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    public Animator creditAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenCredits()
    {
        creditAnim.SetTrigger("open");
    }


    public void CloseCredits()
    {
        creditAnim.SetTrigger("close");
    }
}
