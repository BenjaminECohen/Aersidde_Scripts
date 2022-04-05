using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : EntityStatus
{

    [SerializeField] Action defendAction;

    public Action getDefenseAction()
    {
        return defendAction;
    }


}
