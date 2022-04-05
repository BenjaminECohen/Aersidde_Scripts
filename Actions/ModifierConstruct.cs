using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierConstruct
{
    public static Modifier<float, int> CreateModifier(float value, int duration)
    {
        Modifier<float, int> newMod = new Modifier<float, int>();
        newMod.value = value;
        newMod.duration = duration;
        return newMod;
    }
}