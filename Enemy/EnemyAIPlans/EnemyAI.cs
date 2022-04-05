using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyAI : ScriptableObject
{

    public virtual int GetAIDecision(EnemyStatus enemyStatus)
    {
        return 0;
    }

    public virtual void ResetValues()
    {
        
    }
}
