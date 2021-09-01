using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuBehaviour : MonoBehaviour
{
    public GameObject testObj;
    public GameObject UICanvas;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        UpdateVolumeLabel();
    }

    public void UpdateVolumeLabel()
    {
        var masterVolume = UICanvas.transform.Find("MasterVolume");
        masterVolume.GetComponent<UnityEngine.UI.Text>().text = "Master Volume - " + (AudioListener.volume * 100).ToString("f2") + "%";
    }

    public void IncreaseQuality() {
        QualitySettings.IncreaseLevel();
        UpdateQualityLabel();
    }

    public void DecreaseQuality() {
        QualitySettings.DecreaseLevel();
        
        UpdateQualityLabel();
    }

    public void UpdateQualityLabel() {
        int currentQuality = QualitySettings.GetQualityLevel();
        string qualityName = QualitySettings.names[currentQuality];

        Debug.Log("Current quality is " + qualityName);

        // Setting the display output
        var qualityLevel = UICanvas.transform.Find("QualityLevelLabel");
        qualityLevel.GetComponent<UnityEngine.UI.Text>().text = "Quality Level - " + qualityName;
    }

    public void testOff()
    {
        Debug.Log("reverse setting");
        testObj.SetActive(!testObj.activeSelf);
    }
}
