using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public void Onstargamebutton()
    {

        if (UiManager.HasInstance)
        {

            UiManager.Instance.ActiveMenuPanel(false);
            SceneManager.LoadScene("SceneGame");
            //GameManager.Instance.Startgame();
           
        }

    }
    public void onSettingButtonClick()
    {
        if (UiManager.HasInstance)
        {
            UiManager.Instance.ActiveSettingPanel(true);
            UiManager.Instance.ActiveMenuPanel(false );

        }
    }
    public void OnClickExitButton()
    {
        print("exit ngoai");
        GameManager.Instance.EndGame();
        if (GameManager.HasInstance)
        {
            GameManager.Instance.EndGame();
            print("exit");
        }
    }
   
}
