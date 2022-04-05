using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Node : ScriptableObject
{
    public Sprite image;
    public NodeType nodeType;

    [Header("Enemy")]
    //Enemy AI
    public EnemyStats enemy;
    public int sceneIndex = 2;

    [Header("Heal")]
    public float value = 0.5f;

    [Header("Action")]
    public List<AttackAction> actionsList;

    [Header("Holo")]
    public AudioClip audioClip;



}
