using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBGMManager : MonoBehaviour
{

    public AudioSource audio;

    public AudioClip normalBGM;
    public AudioClip bossBGM;


    public BattleSystem bs;


    // Start is called before the first frame update
    void Start()
    {
        audio.Stop();
        if (bs.progressData.selectedEnemy.enemyRigVariation == BattleSystem.EnemyRig.BOSS)
        {
            audio.clip = bossBGM;
        }
        else
        {
            audio.clip = normalBGM;
        }
        audio.Play();
    }


}
