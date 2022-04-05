using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public ProgressData progressData;
    public EntityStats playerStats;

    [Header("Scene Indices")]
    public int mapIndex = 1;
    public int creditsIndex = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
