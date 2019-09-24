using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowDataHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreHud;

    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] TextMeshProUGUI countingTimeText;

    [SerializeField] TextMeshProUGUI muestraResultados;


    int score;
    float timeLeft;
    public bool isPaused = false;
    public bool isTimerFreezed = false;
    public int pointsADD;

    public bool counting = true;
    public GameObject CountingOBJ;
    public float maxTime = 3.5f;
    float counterC = 0;


    public Button PauseBT;
    public Button PauseBT2;
    public GameObject PausePanel;

    public GameObject PanelTimesUP_;

    public bool missionAccepted = false;
    public GameObject missionPanel;

    public WeaponCol weaponCol;
    public GameObject ResultadosOBJ;
    private string ResultadosSTR;
    
    public int enemyCountS;

    public int ScoreT;
    public int Score { get => score; }
    public float TimeLeft { get => timeLeft; }

    private void Awake()
    {
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
        AddSubstractTime(70);
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
        
        if (timeLeft > 0 && !isTimerFreezed )
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
        timeText.text = timeLeft.ToString("##0.0");
        ScoreHud.text = score.ToString();

        if (timeLeft <= 0.0f)
        {
            
            if (this.score >= PlayerPrefs.GetInt("MaxScore"))
            {
                SaveScore(this.score);
            }

            PanelTimesUP_.SetActive(true);
            //ResultadosOBJ.SetActive(true);
            //Time.timeScale = 0;
            
        }

        ResultadosSTR = "You have destroyed " + enemyCountS / 3 + " vending machines and earned " + score + " Points";

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

    public void AddSubstractTime(float seconds)
    {
        timeLeft += seconds;
    }

    public void AddToScore(int score)
    {
        this.score += score;

    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("MaxScore", 0);
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
