using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBird : MonoBehaviour
{
    public GameObject tuberprefab;
    private float countdown;
    public float timeduration;

    public bool enabletuber;
    private List<GameObject> bulletPool = new List<GameObject>();


    void Start()
    {
        countdown = 0;
        enabletuber = false;
    }

    // Update is called once per frame
    void Update()
    {
        appear();
    }
    public void appear()
    {
        if (enabletuber == true)
        {
            countdown -= Time.deltaTime; //dếm ngược thời gian
            if (countdown < 0)
            {
                //GameObject bullet = GetPooledBullet();
                ////bullet.SetActive(true);
                //GameObject tube = Instantiate(bullet, new Vector3(4, Random.Range(-4f, 3.2f), 0), Quaternion.identity); 


                //GameObject tube = Instantiate(GetPooledBullet(), new Vector3(4, Random.Range(-4f, 3.2f), 0), Quaternion.identity);
                //tube.transform.SetParent(gameObject.transform);

                //GetPooledBullet();

                GameObject bullet = GetPooledBullet();
                StartCoroutine(DeactivateBullet(bullet));


                countdown = timeduration;
                if (timeduration > 1.5f) 
                {
                    timeduration -= 0.01f;
                }
                //StartCoroutine(DeactivateBullet(tube));
            }
        }
    }
    GameObject GetPooledBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeSelf)
            {
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(tuberprefab/*, new Vector3(4, Random.Range(-4f, 3.2f), 0), Quaternion.identity*/);  
       
        bulletPool.Add(newBullet);
        return newBullet;
    }

    IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3f); // Thời gian tồn tại của đạn (tùy chọn)     
        bullet.SetActive(false);
        
    }
}
