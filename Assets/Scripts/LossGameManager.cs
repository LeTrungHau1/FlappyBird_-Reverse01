using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossGameManager : MonoBehaviour
{
    public GameObject Pencil;
    public GameObject PointTopPannel;
    public GameObject InstBird;
    public GameObject PointPannel;
    public GameObject LossGamePannel;
    public GameObject LossUpTopPannel;
    public GameObject LossDownTopPannel;
    public GameObject imgGroup_Click_TimeOff;

    public PlusPoint pointPlus;
    public TextMeshProUGUI txtpoint;


    [SerializeField]private float timeActiveImgGroup = 5;
    private bool boolactive ;
    private int intactive ;
    


    // Start is called before the first frame update
    void Start()
    {
        intactive = PlayerPrefs.GetInt("intactive", 1);
        boolactive = (intactive == 1 ? true : false);
        Pencil.SetActive(true);
        PointTopPannel.SetActive(true);
        PointPannel.SetActive(true);
        LossGamePannel.SetActive(false);
        LossDownTopPannel.SetActive(false);
        LossUpTopPannel.SetActive(false);
        InstBird.SetActive(true);
        if(boolactive == true)
        {
            imgGroup_Click_TimeOff.SetActive(true);
            PlayerPrefs.SetInt("intactive", 0);
            PlayerPrefs.Save();
            //print("thay doi");
        }
        else
        {
            imgGroup_Click_TimeOff.SetActive(false);
        }
       


    }

    // Update is called once per frame
    void Update()
    {
        if(LossGamePannel.activeSelf)
        {
            PlayerCtroller.Activetimescale = false;
            Pencil.SetActive(false);
            PointTopPannel.SetActive(false);
            PointPannel.SetActive(false);
            InstBird.SetActive(false);
            imgGroup_Click_TimeOff.SetActive(false);
            txtpoint.text = pointPlus.Point.ToString();

        }
        if(boolactive == true)
        {
            timeActiveImgGroup -= Time.deltaTime;
            if (timeActiveImgGroup < 0)
            {
                imgGroup_Click_TimeOff.SetActive(false);

            }
        }
       
    }
   
    void OnApplicationQuit()
    {

        PlayerPrefs.SetInt("intactive", 1);
        PlayerPrefs.Save();
        //print("out thay doi");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SceneGame");     
    }
    public void BackToMenu()
    {
      
        GameManager.Instance.RestartGame();
    }
    public void OnSetting()
    {

        UiManager.Instance.ActiveSettingPanel(true);
    }
}
