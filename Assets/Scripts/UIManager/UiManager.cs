using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : BaseManager<UiManager>
{
    [SerializeField]
    private MenuPanel menupanel;
    public MenuPanel Menupanel => menupanel;
    [SerializeField]
    private SettingPanel settingPanel;
    public SettingPanel SettingPanel => settingPanel;

    void Start()
    {

        ActiveMenuPanel(true);
        ActiveSettingPanel(false);
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.HasInstance && GameManager.Instance.Isplaying)
            {
                GameManager.Instance.Pausegame();
                //ActivePausePanel(true);
            }
        }
    }


    public void ActiveMenuPanel(bool active)
    {
        menupanel.gameObject.SetActive(active);
    }
   
    public void ActiveSettingPanel(bool active)
    {
        settingPanel.gameObject.SetActive(active);
    }
}
