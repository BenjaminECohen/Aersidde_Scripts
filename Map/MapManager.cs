using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [Header("Player Stats")]
    public EntityStats playerStats;

    [Header("System")]
    [SerializeField] ProgressData progressData;
    public List<Button> buttons;
    public HoloManager holoManager;
    public HealManager healManager;

    [Header("UI")]
    public GameObject Popup;
    public GameObject HoloPanel;
    public GameObject ActionPanel;
    public GameObject HealPanel;
    public GameObject BattlePanel;

    [Header("Action Buttons")]
    public List<Button> actionButtons;
    private Node currentActionNode;
    private int actionNodeIndex;

    const int MAXBUTTONS = 3;

    [Header("Battle Loader")]
    public Image battleFillBar;
    public Text battleMessage;
    public string loadingMessage = "Battle Loading...";
    public string sendOffMessage = "Engaging!";
    private int nextEnemySceneIndex;

    [Space(20)]
    public GameObject iconBlocker;
    public GameObject iconHolder;

    [Header("Testing Only")]
    public bool TestMode = false;
    public Text progressNum;

    // Start is called before the first frame update
    void Start()
    {
        iconHolder.SetActive(false);
        Setup();


    }

    private void Update()
    {
        if (TestMode)
        {
            progressNum.text = "Index: " + progressData.ProgressIndex.ToString();
        }
        
    }

    public void ClosePopup()
    {
        holoManager.ResetClip();
        //Unload all Listeners
        UnloadListeners();

        //Increase Index
        progressData.IncreaseIndex();

        //Close All
        ActionPanel.SetActive(false);
        HoloPanel.SetActive(false);
        HealPanel.SetActive(false);
        Popup.SetActive(false);

        

        //Restart
        Setup();
        
    }

    public void Setup()
    {
        if (progressData.ProgressIndex == progressData.mapList.sectionList.Count)
        {
            iconHolder.SetActive(false);
            StartCoroutine(LoadScene());
        }
        else
        {
            iconBlocker.SetActive(true);
            LoadNodes();
            iconHolder.SetActive(true); //Play Animation instead
            iconBlocker.SetActive(false);
        }
        
    }

    public void LoadNodes()
    {
        int index = progressData.ProgressIndex;

        if (index < progressData.mapList.sectionList.Count)
        {
            List<Node> section = progressData.mapList.sectionList[index].nodeSection;
            //Load Section Nodes
            for (int i = 0; i < MAXBUTTONS && i < section.Count; i++)
            {
                buttons[i].image.sprite = section[i].image;

                #region Assign Listener
                switch (section[i].nodeType)
                {
                    
                    case NodeType.Action:
                        //Load Action Buttons
                        currentActionNode = section[i];
                        Debug.Log($"Action node: {currentActionNode.name}");
                        buttons[i].onClick.AddListener(() => LoadActionPanel());
                        break;

                    case NodeType.Enemy:
                        nextEnemySceneIndex = section[i].sceneIndex;
                        progressData.selectedEnemy = section[i].enemy;
                        buttons[i].onClick.AddListener(() => LoadBattleScene());
                        break;

                    case NodeType.Heal:
                        buttons[i].onClick.AddListener(() => LoadHealPanel());
                        break;

                    case NodeType.Holo:
                        buttons[i].onClick.AddListener(() => LoadHoloPanel());
                        holoManager.LoadAudioClip(section[i].audioClip);
                        break;

                    default:
                        Debug.LogError("Bad node type. Cannot assign Listener");
                        break;
                }
                #endregion
                buttons[i].gameObject.SetActive(true);
            }
            if (section.Count < MAXBUTTONS)
            {
                for (int i = MAXBUTTONS - 1; i > section.Count - 1; i--)
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }
    }


    public void UnloadListeners()
    {
        foreach(Button button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }

    public void LoadActionPanel()
    {
        Debug.Log("Loading Action Panel");

        //Fill out actions
        int i = 0;
        foreach(Button button in actionButtons)
        {
            if (i >= currentActionNode.actionsList.Count)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.gameObject.SetActive(true);
                ActionButton actBut = button.GetComponent<ActionButton>();
                actBut.Initialize(currentActionNode.actionsList[i]);
                button.onClick.AddListener(() => actBut.GivePlayerAction(playerStats.entityMoveSet));
                button.onClick.AddListener(() => ActionButtonClosePopups());
            }         
            i++;
        }

        ActionPanel.SetActive(true);
        BasicPopupFunctions();
    }

    public void LoadHealPanel()
    {
        Debug.Log("Loading Heal Panel");
        healManager.DisplayInfo(playerStats);
        HealPanel.SetActive(true);
        BasicPopupFunctions();
    }

    public void LoadHoloPanel()
    {
        Debug.Log("Loading Holo Panel");

        HoloPanel.SetActive(true);
        BasicPopupFunctions();


    }

    public void LoadBattleScene()
    {
        Debug.Log("Loading Battle Scene");
        battleFillBar.fillAmount = 0f;
        battleMessage.text = loadingMessage;
        BattlePanel.SetActive(true);
        BasicPopupFunctions();

        progressData.IncreaseIndex();
        //SceneManager.LoadScene(nextEnemySceneIndex);
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(3);

    }

    IEnumerator LoadSceneAsync()
    {
        yield return null;
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(nextEnemySceneIndex);
        asyncOp.allowSceneActivation = false;
        while (!asyncOp.isDone)
        {
            Debug.Log("Load Progress: " + asyncOp.progress);
            battleFillBar.fillAmount = asyncOp.progress / 0.9f;
            if (asyncOp.progress >= 0.9f)
            {
                
                battleMessage.text = sendOffMessage;
                yield return new WaitForSeconds(1f);
                asyncOp.allowSceneActivation = true;

            }
            yield return null;
        }

    }

    public void ActionButtonClosePopups()
    {
        foreach (Button button in actionButtons)
        {
            button.onClick.RemoveAllListeners();
        }
        ClosePopup();
        
    }

    void BasicPopupFunctions()
    {
        iconHolder.SetActive(false);
        Popup.SetActive(true);
        iconBlocker.SetActive(true);
    }

    
}
