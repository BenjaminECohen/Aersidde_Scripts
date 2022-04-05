using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    [Header("Effect GameObjects")]
    public GameObject particleEffect;
    public AudioClip actionSound;


    // Start is called before the first frame update
    public virtual int Execute(EntityStatus actor, EntityStatus target)
    {
        return 0;
    }

    

}
