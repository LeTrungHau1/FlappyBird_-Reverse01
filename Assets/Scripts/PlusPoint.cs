using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlusPoint : MonoBehaviour
{
    public float HighestPoint;
    public float Point = 0f;
    public TextMeshProUGUI txthighestpoint;
    public TextMeshProUGUI txtpoint;
    private void Start()
    {
       
       //ResetHeghstPoint();
        HighestPoint = PlayerPrefs.GetFloat("highestpoint", 0f);
    }
    private void Update()
    {
        HighestPoint = PlayerPrefs.GetFloat("highestpoint", 0f);
        txthighestpoint.text = HighestPoint.ToString();
        txtpoint.text = Point.ToString();
    }
    private void FixedUpdate()
    {   
        if (Point > HighestPoint)
        {
            HighestPoint = Point;
            PlayerPrefs.SetFloat("highestpoint", HighestPoint);
            PlayerPrefs.Save();
        }
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bird"))
        {
            Point += 99 + (int)((Point<1000 ? Point: 999 )* ( 2 - ObjectPooling.Pooling.timeduration));
        }
    }
    public void ResetHeghstPoint()
    {
        PlayerPrefs.SetFloat("highestpoint", 0);
        PlayerPrefs.Save();
        Time.timeScale = 0;
    }
}
