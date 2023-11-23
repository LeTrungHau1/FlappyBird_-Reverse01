using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public ObjectPooling instBird;
    public float SpeedUp;
    public float StarRB;
    public static bool Activetimescale;



    void Start()
    {
        Activetimescale = this;
        //StarRB = (float)rb.gravityScale;
        rb = gameObject .GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Activetimescale = true;
    }


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.gravityScale = StarRB;
            if( Activetimescale==true ) 
            {
                Time.timeScale = 1;
            }          
            instBird.enabletuber = true;
            MovePlayer();
           
        }
    }
    private void MovePlayer()
    {
        rb.velocity = Vector3.up * SpeedUp;
    }

    
}
