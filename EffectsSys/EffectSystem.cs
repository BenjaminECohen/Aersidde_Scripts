using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    public List<EffectTrigger> effects;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayEffect(0);
        }
    }

    public EffectTrigger GetEffect(int index)
    {
        return effects[index];
    }

    public void PlayEffect(int index)
    {
        effects[index].Activate();
    }

    public void MoveEffect(Vector3 pos, int index)
    {
        effects[index].gameObject.transform.position = pos;
    }

   

}
