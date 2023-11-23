using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckVaCham : MonoBehaviour
{
    //public GameObject PannelLossGame;
    public LossGameManager lossGameManager;
    public PlusPoint pluspoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
            //Time.timeScale = 0f;
            //SceneManager.LoadScene("SceneGame");
            lossGameManager.LossGamePannel.SetActive(true);
            if(pluspoint.Point >= PlayerPrefs.GetFloat("highestpoint"))
            {
                lossGameManager.LossUpTopPannel.SetActive(true);
                lossGameManager.LossDownTopPannel.SetActive(false);
                print("tren top");
            }
            else
            {
                lossGameManager.LossUpTopPannel.SetActive(false);
                lossGameManager.LossDownTopPannel.SetActive(true);
                print("duoi top");
            }
        }
    }
}
