using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player centric scriptable object that contains the player specific defensive action
/// </summary>

public class PlayerStatus : EntityStatus
{

    [SerializeField] Action defendAction;

    public Action getDefenseAction()
    {
        return defendAction;
    }


}
