using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuBehaviour : MonoBehaviour
{
    public GameObject testObj;
    public GameObject UICanvas;
    public GameObject masterVolume;
    public GameObject brightness;
    public GameObject qualityLevelLabel;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
        SetVolume();
        UpdateQualityLabel();
    }

    /* --- Volume Settings ---  */
    public void SetVolume()
    {
        slider = masterVolume.GetComponent<UnityEngine.UI.Slider>();
        AudioListener.volume = slider.value;
        Debug.Log("volume = " + slider.value);
        UpdateVolumeLabel();
    }

    public void UpdateVolumeLabel()
    {
        Debug.Log("Updating Volume " + AudioListener.volume*100);
        var masterVolumeLabel = masterVolume.transform.Find("MasterVolumeLabel");
        masterVolumeLabel.GetComponent<UnityEngine.UI.Text>().text = "Master Volume - " + (AudioListener.volume * 100).ToString("f2") + "%";
    }

    /* --- Quality Settings ---  */
    public void IncreaseQuality() 
    {
        QualitySettings.IncreaseLevel();
        UpdateQualityLabel();
    }

    public void DecreaseQuality() 
    {
        QualitySettings.DecreaseLevel();        
        UpdateQualityLabel();
    }

    public void UpdateQualityLabel() 
    {
        int currentQuality = QualitySettings.GetQualityLevel();
        string qualityName = QualitySettings.names[currentQuality];

        // Updating the label
        qualityLevelLabel.GetComponent<UnityEngine.UI.Text>().text = "Quality Level - " + qualityName;
    }

    /* --- Brightness Settings ---  */
    // Maybe use screen overlay?
    public void SetBrightness() 
    { 

    }

    public void UpdateBrightness() { 
    
    }

    public void testOff()
    {
        //Debug.Log("reverse setting");
        testObj.SetActive(!testObj.activeSelf);
    }
}
