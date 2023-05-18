using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script to handle the functions of the main menu
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    public ProgressData progressData;
    public EntityStats playerStats;

    [Header("Scene Indices")]
    public int mapIndex = 1;
    public int creditsIndex = 5;

    //Reset all values to make sure that player is set to base stats
    public void StartGameButton()
    {
        progressData.ResetProgress();
        playerStats.ResetStats();
        StartCoroutine(StartGame());


    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(mapIndex);

    }

    public void Quit()
    {
        Application.Quit();
    }



}
