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
    //public LayerMask birdLayer;
    //public float boxX;
    //public float boxY;
    //private bool hasCollidedWithBird=false;
    
   
    private void Start()
    {
       //ResetHeghstPoint();
        HighestPoint = PlayerPrefs.GetFloat("highestpoint", 0f);
    }
    private void Update()
    {
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
            Point++;
        }
    }
    public void ResetHeghstPoint()
    {
        PlayerPrefs.SetFloat("highestpoint", 0);
        PlayerPrefs.Save();
    }
    //public void checkvacham()
    //{

    //    Collider2D[] birdCollider = Physics2D.OverlapBoxAll(transform.position, new Vector2(boxX, boxY), birdLayer);
    //    foreach (Collider2D collider in birdCollider)
    //    {
    //        if (collider.CompareTag("Bird")&& !hasCollidedWithBird)
    //        {
    //            // Có va chạm với đối tượng có tag là "Bird"
    //            Point++;
    //            Debug.Log("va chạm bird: " + Point);
    //            hasCollidedWithBird= true;
    //        }
    //    }
    //    hasCollidedWithBird = false;
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.position, new Vector2(boxX, boxY));
    //}
}
