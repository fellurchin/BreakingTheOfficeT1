using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ButtonsController : MonoBehaviour
{

    LevelLoader levelLoader;

    [Header("Texto del dinero que posee")]
    [SerializeField] TextMeshProUGUI actualMoney;

    [Header("Botones necesarios")]
    public Button start_Button;
    public Button restart_Button;
    public Button return_Button;

    Scene activeScene;

    private void Awake()
    {
        levelLoader = GetComponent<LevelLoader>();
    }
    void Start()
    {

        activeScene = SceneManager.GetActiveScene();
        if (start_Button != null) { start_Button.onClick.AddListener(StartV); }
        if (restart_Button != null) { restart_Button.onClick.AddListener(RestartScene); }
        if (return_Button != null) { return_Button.onClick.AddListener(ReturnV); }
    }

    void Update()
    {
        if (actualMoney != null) //Si existe dinero
        {
            if (PlayerPrefs.GetInt("Money") != 0)
            {
                actualMoney.text = ("$" + PlayerPrefs.GetInt("Money").ToString());
            }
        }
    }

    public void StartV()
    {
        //levelLoader.LoadLevel(1);
        SceneManager.LoadScene(1);
    }

    public void RestartScene() => SceneManager.LoadScene(activeScene.buildIndex);
    public void ReturnV() => SceneManager.LoadScene(1);
}
