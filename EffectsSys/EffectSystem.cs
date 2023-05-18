using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// System that makes use of the EffectTrigger script
/// </summary>
public class EffectSystem : MonoBehaviour
{
    public List<EffectTrigger> effects; //List of all the effects a move can use


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayEffect(0);
        }
    }

    public EffectTrigger GetEffect(int index) //Returns effect from index
    {
        return effects[index];
    }

    public void PlayEffect(int index) //Activates effect from index in scene
    {
        effects[index].Activate();
    }

    public void MoveEffect(Vector3 pos, int index) //Move effect from index to new position
    {
        effects[index].gameObject.transform.position = pos;
    }

   

}
