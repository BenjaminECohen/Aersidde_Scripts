using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProgressData : ScriptableObject
{
    [SerializeField] int progressIndex = 0;
    public NodeList mapList;

    [Header("Enemy AI Data")]
    public EnemyStats selectedEnemy;

    public int ProgressIndex { get => progressIndex; private set => progressIndex = value; }

    public int IncreaseIndex()
    {
        progressIndex++;
        return progressIndex;
    }


    public int ResetProgress()
    {
        progressIndex = 0;
        return progressIndex;
    }


}
