using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveList : ScriptableObject
{
    public List<AttackAction> moveList;

    public void ResetList()
    {
        AttackAction temp = moveList[0];
        moveList.Clear();
        moveList.Add(temp);
    }
}
