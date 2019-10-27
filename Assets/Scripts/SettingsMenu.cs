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

    public GameObject highQ_Selected;
    public GameObject midQ_Selected;
    public GameObject lowQ_Selected;

    // Start is called before the first frame update
    private void Awake()
    {
        //HQ_v();
    }

    void Start()
    {
        foreach (Button button_ in Act_BTN)
        {
            button_.onClick.AddListener(ChangePanelState);
        }

        highQ_BTN.onClick.AddListener(HQ_v);
        midQ_BTN.onClick.AddListener(MQ_V);
        lowQ_BTN.onClick.AddListener(LQ_V);

        switch (PlayerPrefs.GetInt("ActualQLevel"))
        {
            case 4:
                HQ_v();
                break;
            case 2:
                MQ_V();
                break;
            case 0:
                LQ_V();
                break;


            default:
                break;
        }
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
        PlayerPrefs.SetInt("ActualQLevel", ActualIndex);
        SetQuality(ActualIndex);
        QualitySettings.SetQualityLevel(ActualIndex);

        highQ_Selected.SetActive(true);
        midQ_Selected.SetActive(false);
        lowQ_Selected.SetActive(false);
        
    }
    void MQ_V()
    {
        ActualIndex = 2;
        PlayerPrefs.SetInt("ActualQLevel", ActualIndex);
        SetQuality(ActualIndex);
        QualitySettings.SetQualityLevel(ActualIndex);

        highQ_Selected.SetActive(false);
        midQ_Selected.SetActive(true);
        lowQ_Selected.SetActive(false);

    }

    void LQ_V()
    {
        ActualIndex = 0;
        PlayerPrefs.SetInt("ActualQLevel", ActualIndex);
        SetQuality(ActualIndex);
        QualitySettings.SetQualityLevel(ActualIndex);

        highQ_Selected.SetActive(false);
        midQ_Selected.SetActive(false);
        lowQ_Selected.SetActive(true);

    }
}
