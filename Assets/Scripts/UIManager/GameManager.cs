using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
    private bool isPlaying = false;
    public bool Isplaying => isPlaying;
    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {

    }
    public void Startgame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
    }
    public void Pausegame()
    {

        //Debug.Log("0");
        if (isPlaying)
        {
            //Debug.Log("1");
            isPlaying = false;
            Time.timeScale = 0f;
        }
    }
    public void Resumegame()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            Time.timeScale = 1f;
        }
    }
    public void RestartGame()
    {
        ChangeScene("SceneMenu");
        if (UiManager.HasInstance)
        {
            UiManager.Instance.ActiveMenuPanel(true);
           
        }
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        print("exitmanager");
#endif
        Application.Quit();

    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
