using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStatus : MonoBehaviour
{
    [Header("Stat Info")]
    public EntityStats stats;
    public ActionAttribute weakness = ActionAttribute.NONE;

    [Header("Components")]
    public HealthUI healthUI;
    public ManaUI manaUI;

    public Health entityHealth;
    public Mana entityMana;
    public EntityAnimController animController;

    public List<AttackAction> attackActions;


    [Header("Modifiers")]
    public List<Modifier<float, int>> attackModifiers = new List<Modifier<float, int>>();
    public List<Modifier<float, int>> defenseModifiers = new List<Modifier<float, int>>();

    private void Awake()
    {
        entityHealth.AssignValues(stats.MaxHealth, stats.currentHealth);
        entityMana.AssignValues(stats.MaxMana);
        entityMana.ResetMana();

        attackActions.Clear();
        attackActions = stats.entityMoveSet.moveList;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartTick()
    {
        List<Modifier<float, int>> temp = new List<Modifier<float, int>>(defenseModifiers);

        foreach (Modifier<float,int> mod in temp)
        {
            mod.duration--;
            if (mod.duration == 0)
            {
                defenseModifiers.Remove(mod);
                Debug.Log($"Removed a Def Buff for {name}");
            }
        }     

    }

    public void EndTick()
    {
        List<Modifier<float, int>> temp = new List<Modifier<float, int>>(attackModifiers);

        foreach (Modifier<float, int> mod in temp)
        {
            mod.duration--;
            if (mod.duration == 0)
            {
                attackModifiers.Remove(mod);
                Debug.Log($"Removed an ATk Buff for {name}");
            }
        }
    }

    public bool enoughMana(int moveIndex)
    {
        if (attackActions[moveIndex].manaCost <= entityMana.CurrentMana)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
