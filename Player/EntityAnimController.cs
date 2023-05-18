using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animation controller that handles the generic actions an entity will enact in battle
/// </summary>

public class EntityAnimController : MonoBehaviour
{

    public Animator anim;

    private void Start()
    {
        PlayIdle();
    }

    /*
    private void Update() //Functions to test animations for the developer
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayAttackAnimOne();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayAttackAnimTwo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayAttackAnimThree();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayHitAnim();
        }

    }*/

    public void PlayIdle()
    {

    }

    public void PlayHitAnim()
    {
        anim.SetTrigger("hit");
    }

    public void PlayDeadAnim()
    {
        anim.SetTrigger("dead");
    }

    public void PlayAttackAnimOne()
    {
        anim.SetTrigger("attack1");
    }

    public void PlayAttackAnimTwo()
    {
        anim.SetTrigger("attack2");
    }

    public void PlayAttackAnimThree()
    {
        anim.SetTrigger("attack3");
    }


}
