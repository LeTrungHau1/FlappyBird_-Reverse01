using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider seSlider;

    private float bgmValue;
    private float seValue;

    private void Update()
    {
        AudioManager.Instance.ChangeBGMVolume(bgmValue);
        AudioManager.Instance.ChangeSEVolume(seValue);
    }
    private void OnEnable()
    {
        if (AudioManager.HasInstance)
        {
            bgmValue = AudioManager.Instance.AttachBGMSource.volume;
            seValue = AudioManager.Instance.AttachSESource.volume;
            bgmSlider.value = bgmValue;
            seSlider.value = seValue;
        }
    }
    public void OnSliderChangeBGMValue(float value)
    {
        bgmValue = value;
    }
    public void OnSliderChangeSEValue(float value)
    {
        seValue = value;
    }
    public void OnBackMenu()
    {
        if (UiManager.HasInstance)
        {
            UiManager.Instance.ActiveSettingPanel(false);
            UiManager.Instance.ActiveMenuPanel(true);
        }
    }
   
}
