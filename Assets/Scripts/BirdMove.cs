using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public float speedBird;
    private void Start()
    {
        //AudioManager.Instance.PlaySE("BirdRun", 0f);
    }
    void Update()
    {
        transform.position += Vector3.left * speedBird * Time.deltaTime;
       
    }
}
