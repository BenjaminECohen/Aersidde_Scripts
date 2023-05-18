using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Also known as the game map, node list contains the flow of the players progression through the game with node sections, each section being an index where the player may choose only 1 node to visit
/// </summary>

[CreateAssetMenu]
public class NodeList : ScriptableObject
{
    public List<NodeSection> sectionList;
}



