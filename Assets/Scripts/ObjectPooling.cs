using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Pooling {  get; private set; }
    public GameObject objectPrefab;
    public int poolSize = 10;
    private float countdown;
    public float timeduration;
    public float timeSetActiveGameojbect;
    public bool enabletuber;
    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        Pooling = this;
        InitializeObjectPool();
        enabletuber = false;
    }

    void InitializeObjectPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objectPrefab);
            newObj.transform.SetParent(gameObject.transform);
            newObj.SetActive(false);
            objectPool.Add(newObj);
        }
    }

    void Update()
    {
        if (enabletuber == true)
        {
            countdown -= Time.deltaTime; //dếm ngược thời gian
            if (countdown < 0)
            {

                GameObject obj = GetPooledObject();
                obj.transform.position = new Vector3(4, Random.Range(-4f, 3.2f), 0);
                obj.SetActive(true);
                countdown = timeduration;
                if (timeduration > 1.5f)
                {
                    timeduration -= 0.01f;
                }
                StartCoroutine(DeactivateBullet(obj));
            }
        }
    }

    GameObject GetPooledObject()
    {
        // Tìm đối tượng không hoạt động trong pool để tái sử dụng
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeSelf)
            {
                return obj;
            }
        }

        // Nếu không có đối tượng nào sẵn sàng, tạo một đối tượng mới và thêm vào pool
        GameObject newObj = Instantiate(objectPrefab);
        newObj.transform.SetParent(gameObject.transform);
        newObj.SetActive(false);
        objectPool.Add(newObj);
        return newObj;
    }
    IEnumerator DeactivateBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timeSetActiveGameojbect); // Thời gian tồn tại của đạn (tùy chọn)     
        bullet.SetActive(false);

    }
}
