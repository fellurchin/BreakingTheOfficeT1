using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ButtonsController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MaxScoreText;

    public Button start_Button;
    public Button restart_Button;
    public Button return_Button;

    public Scene activeScene;
    


    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        if (start_Button != null) { start_Button.onClick.AddListener(StartV); }
        if (restart_Button != null) { restart_Button.onClick.AddListener(RestartScene); }
        if (return_Button != null) { return_Button.onClick.AddListener(ReturnV); }

    }

    void Update()
    {

        if (MaxScoreText != null)
        {
            MaxScoreText.text = PlayerPrefs.GetInt("MaxScore").ToString();
        }
        
        


    }
    void StartV() => SceneManager.LoadScene(1);
    public void RestartScene() => SceneManager.LoadScene(activeScene.buildIndex);
    public void ReturnV() => SceneManager.LoadScene(1);

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("MaxScore", 0);
    }
    public void ResetScore()
    {
        PlayerPrefs.SetInt("MaxScore", 0);

    }
}
