using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Referenced from https://www.youtube.com/watch?v=G1bd75R10m4&ab_channel=InfallibleCode

public class BattleSystem : StateMachine
{
    public VictorySys victorySystem;
    public ProgressData progressData;

    [Header("Audio")]
    public AudioSource actionAudioSource;

    [Header("UI Elements")]
    public Canvas BattleUI;
    public GameObject playerActionMenu;
    public GameObject playerMoveUI;
    public Text healCount;
    public GameObject playerSys;
    public GameObject enemySys;

    [Header("Player")]
    public PlayerStatus player;
    public GameObject pRig;


    [Header("Enemy")]
    public List<EntityAnimController> enemyList;
    public EnemyStatus enemy;
    public enum EnemyRig
    {
        BOSS = 0,
        FODDER = 1,
        SPEEDER = 2,
        DEFENDER = 3,
        ATKBUFFER = 4
    }


    [Header("Effect Height")]
    public float effectHeight = 0f;

    public bool isPlayerTurn = true;

    [SerializeField] PlayerMoveListManager moveListManager;

    [Header("Heal Variables")]
    public GameObject healParticleEffect;
    public AudioClip healSound;

    [Header("System")]
    public int mapSceneIndex = 1;
    public int mainMenuIndex = 2;

    

    int currentMoveIndex = 0; //On button press, knows which move to execute. Last pressed move button


    private void Awake()
    {
        if (!enemy)
        {
            enemy = GameObject.FindObjectOfType<EnemyStatus>();
        }
        enemy.EnemyAwakeSetup(enemyList[(int)progressData.selectedEnemy.enemyRigVariation],
            progressData.selectedEnemy);
    }


    // Start is called before the first frame update
    void Start()
    {
        
        victorySystem.victoryScreen.SetActive(false);
        player.healthUI.Init(player.entityHealth);
        player.manaUI.Init(player.entityMana);

        enemy.enemyAIPattern.ResetValues();
        enemy.healthUI.Init(enemy.entityHealth);
        

        healCount.text = player.stats.storedHeals.ToString();
        //Determine turn order
        if (enemy.stats.Speed > player.stats.Speed)
        {
            playerActionMenu.SetActive(false);
            SetState(new EnemyState(this));
        }
        else
        {
            SetState(new PlayerState(this));
        }
        
        
    }

    public void ShowVictorySys()
    {
        playerSys.SetActive(false);
        enemySys.SetActive(false);
        victorySystem.Init();
    }


    #region AttackUI

    public void ToggleAttackMenu()
    {
        if (moveListManager.MoveUI.activeInHierarchy)
        {
            moveListManager.UnlistButtons();
            moveListManager.MoveUI.SetActive(false);
        }
        else
        {
            moveListManager.GenerateButtonList(player);
            moveListManager.MoveUI.SetActive(true);
        }
    }

    public void SetActiveMoveUI(bool b)
    {
        playerMoveUI.SetActive(b);
    }

    


    #endregion


    public void PlayerAttack()
    {
        //Get current moveIndex
        int index = moveListManager.getCurrentMoveIndex();

        //Check to make sure there is enough mana
        if (player.enoughMana(index))
        {
            //Unlist MoveUI and ToggleOff
            moveListManager.UnlistButtons();
            ToggleAttackMenu();
            playerActionMenu.SetActive(false);

            StartCoroutine(Attack(player, enemy, index));
            
        }
        else
        {
            //Not enough mana
            Debug.Log($"<color=red>Not Enough Mana</color>");
            //Play error sound
        }
        
        


    }

    public IEnumerator Attack(EntityStatus user, EntityStatus target, int moveIndex)
    {
        Debug.Log("Attacking");
        //Get Action
        AttackAction usedAction = user.attackActions[moveIndex];

        if (usedAction.isModifier && usedAction.targetSelf) //Target self if  the user
        {
            target = user;
        }
        

        //Play animations and Sounds
        if (usedAction.atkAnimation == 1)
        {
            user.animController.PlayAttackAnimOne();
        }
        else if (usedAction.atkAnimation == 2)
        {
            user.animController.PlayAttackAnimTwo(); 
        }
        else
        {
            user.animController.PlayAttackAnimThree();
        }

        //Move effect to correct position
        float yHeight = 0;
        if (usedAction.particleEffect)
        {

            Vector3 targetPos = new Vector3(target.gameObject.transform.position.x, yHeight + usedAction.yOffset, target.gameObject.transform.position.z);
            GameObject newEffect = Instantiate(usedAction.particleEffect, targetPos, Quaternion.identity);

            yield return new WaitForSeconds(usedAction.effectDelay); //Wait for animation timing

            
            newEffect.GetComponent<EffectTrigger>().Activate();
            
            
            
        }
        if (user != target)
        {
            target.animController.PlayHitAnim();
        }
       

        //PLAY AUDIO
        if (usedAction.actionSound)
        {
            actionAudioSource.PlayOneShot(usedAction.actionSound);
        }
        //Apply Damage
        int remainingHealth = usedAction.Execute(user, target);


        if (user != enemy)
        {
            user.manaUI.adjustMana();

        }
        

        //Adjust enemy Health
        target.healthUI.adjustHealth();



        yield return new WaitForSeconds(1.5f);
        if (remainingHealth == 0)
        {
            SetState(new End(this));
        }
        else
        {          
            StartCoroutine(State.End());
        }
    }

    public void PlayerDeath()
    {
        SetState(new End(this));
    }

    public void PlayerDefend()
    {
        //Defend
        playerActionMenu.SetActive(false);
        playerMoveUI.SetActive(false);


        StartCoroutine(cPlayerDefend());

        

    }

    public IEnumerator cPlayerDefend()
    {
        Action usedAction = player.getDefenseAction();
        usedAction.Execute(player, enemy);

        float yHeight = 0;
        if (usedAction.particleEffect)
        {

            Vector3 targetPos = new Vector3(player.gameObject.transform.position.x, yHeight, player.gameObject.transform.position.z);
            GameObject newEffect = Instantiate(usedAction.particleEffect, targetPos, Quaternion.identity);


            newEffect.GetComponent<EffectTrigger>().Activate();

        }
        if (usedAction.actionSound)
        {
            actionAudioSource.PlayOneShot(usedAction.actionSound);
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(State.End());
    }

    public void PlayerHeal()
    {

        //Heal if can
        if (player.stats.storedHeals > 0)
        {
            player.stats.storedHeals--;
            healCount.text = player.stats.storedHeals.ToString();
            playerActionMenu.SetActive(false);
            playerMoveUI.SetActive(false);
            playerActionMenu.SetActive(false);
            StartCoroutine(cPlayerHeal());
        }
    }

    public IEnumerator cPlayerHeal()
    {
        float yHeight = effectHeight;
        if (healParticleEffect)
        {

            Vector3 targetPos = new Vector3(player.gameObject.transform.position.x, yHeight, player.gameObject.transform.position.z);
            GameObject newEffect = Instantiate(healParticleEffect, targetPos, Quaternion.identity);


            newEffect.GetComponent<EffectTrigger>().Activate();

        }
        if (healSound)
        {
            actionAudioSource.PlayOneShot(healSound);
        }
        player.entityHealth.Heal(Mathf.RoundToInt((float)player.stats.MaxHealth / 2f));
        player.healthUI.adjustHeal();
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(State.End());

    }


    public void NextState()
    {
        if (isPlayerTurn)
        {
            SetState(new PlayerState(this));
        }
        else
        {
            SetState(new EnemyState(this));
        }
    }


    
}
