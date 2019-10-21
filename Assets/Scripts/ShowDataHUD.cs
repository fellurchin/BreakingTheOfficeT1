using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShowDataHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreHud;

    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] TextMeshProUGUI countingTimeText;

    [SerializeField] TextMeshProUGUI muestraResultados;


    public float timeInMission;

    int score;
    float timeLeft;
    [Header("Pause Variables")]
    public bool isPaused = false;
    public bool isTimerFreezed = false;
    [SerializeField] Button PauseBT;
    [SerializeField] Button PauseBT2;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject PanelTimesUP_;

    [Header("Counter")]
    public bool counting = true;
    public GameObject CountingOBJ;
    public float maxTime = 3.5f;
    float counterC = 0;

    [Header("Control mision")]
    public bool missionAccepted = false;
    public bool wonMission = false;
    public bool showTime = false;
    public GameObject missionPanel;

    public WeaponCol weaponCol;
    public GameObject ResultadosOBJ;
    private string ResultadosSTR;

    public int totalMoney;

    public int enemyCountS;

    public int ScoreT;
    public int Score { get => score; }
    public float TimeLeft { get => timeLeft; }

    [Header("Control escena")]
    public int SceneNumber;
    private Scene ATScene;

    public int ActualMoneyScore;

    public bool giveMoney= true;

    private void Awake()
    {
        ATScene = SceneManager.GetActiveScene();
        SceneNumber = ATScene.buildIndex;

        PauseBT.onClick.AddListener(PauseGame);
        PauseBT2.onClick.AddListener(PauseGame);

        score = 0;
        timeLeft = 0;
    }

    public void Start()
    {
        PanelTimesUP_.SetActive(false);
        CountingOBJ.SetActive(true);
        Time.timeScale = 1;
        counterC = maxTime;
        AddTime(timeInMission);
    }

    void Update()
    {
        #region Counting Zone

        if (missionAccepted)
        {
            missionPanel.SetActive(false);
            if (counterC > 0.0f)
            {
                counterC -= Time.deltaTime;
                
                    
                    countingTimeText.text = counterC.ToString("##0");


                if (counterC <= 0.5F)
                {
                    CountingOBJ.SetActive(false);
                    counting = false;
                }
            }
        }

        #endregion

        

        
        if (showTime)
        {
            timeText.text = timeLeft.ToString("##0.0");
            if (timeLeft > 0 && !isTimerFreezed)
            {
                if (counting == false)
                {
                    timeLeft -= Time.deltaTime;
                }
            }
            else
            {
                timeLeft = 0;
            }
        }
        
        ScoreHud.text = score.ToString();

        if (timeLeft <= 0.0f  || wonMission)
        {

            #region Missions Punctuation
            if (SceneNumber == 2)
            {
                if (enemyCountS > PlayerPrefs.GetInt("Objs_1"))
                {
                    PunctuationM1_(enemyCountS);
                }

            }
            if (SceneNumber == 3)
            {
                if (enemyCountS > PlayerPrefs.GetInt("Objs_2"))
                {
                    PunctuationM2_(enemyCountS);
                }
            }
            #endregion

            if (this.score >= PlayerPrefs.GetInt("MaxScore"))
            {
                SaveScore(this.score);
            }

            if (giveMoney)
            {
                SaveMoney(this.score);
                giveMoney = false;
            }



            PanelTimesUP_.SetActive(true);
            Time.timeScale = 0;

            
        }
        ResultadosSTR = "You have destroyed " + enemyCountS + " objects and earned " + score + " Points";
        muestraResultados.text = ResultadosSTR.ToString();

        


       
        
    }
    public void M_AcceptedV()
    {
        missionAccepted = true;
    }
    public void ResetTimer()
    {
        timeLeft = 0;
    }

    public void AddTime(float seconds)
    {
        timeLeft += seconds;
    }


    public void AddToScore(int score)
    {
        this.score += score;

    }

    public void PunctuationM1_(int Points_)
    {
        PlayerPrefs.SetInt("Objs_1", Points_);

    }
    public void PunctuationM2_(int Points_)
    {
        PlayerPrefs.SetInt("Objs_2", Points_);

    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("MaxScore", 0);
    }

    public void SaveMoney(int MoneyT)
    {
        int LastMoney = PlayerPrefs.GetInt("Money");

        PlayerPrefs.SetInt("Money", MoneyT + LastMoney);
        SaveData.Money = PlayerPrefs.GetInt("Money");
       
    }

    public void SaveScore(int scoreT)
    {
        PlayerPrefs.SetInt("MaxScore", scoreT);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("MaxScore", 0);
    }
        
    #region PauseGame VOID
    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            isPaused = true;
        }


    }
    #endregion

}
