using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Button[] Act_BTN;
    public GameObject settingsPanel;

    public int ActualIndex;

    public Button highQ_BTN;
    public Button midQ_BTN;
    public Button lowQ_BTN;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button_ in Act_BTN)
        {
            button_.onClick.AddListener(ChangePanelState);
        }

        highQ_BTN.onClick.AddListener(HQ_v);
        midQ_BTN.onClick.AddListener(MQ_V);
        lowQ_BTN.onClick.AddListener(LQ_V);
    }

    // Update is called once per frame
    void Update()
    {
        


        
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);

    }

    void ChangePanelState()
    {
        if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else settingsPanel.SetActive(true);
    }

    public  void HQ_v()
    {
        ActualIndex = 4;
        SetQuality(ActualIndex);
        QualitySettings.SetQualityLevel(ActualIndex);
        Debug.Log(QualitySettings.currentLevel);
        
    }
    void MQ_V()
    {
        ActualIndex = 2;
        SetQuality(ActualIndex);
        QualitySettings.SetQualityLevel(ActualIndex);

        Debug.Log(QualitySettings.currentLevel);
    }

    void LQ_V()
    {
        ActualIndex = 0;
        SetQuality(ActualIndex);
        QualitySettings.SetQualityLevel(ActualIndex);

        Debug.Log(QualitySettings.currentLevel);
    }
}
