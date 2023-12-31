using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectPooler : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> pooledObjects;
    public GameObject parentObject;
    public EnemyStatsSO EnemyStat{get{return enemyStat;}}
    [SerializeField] private EnemyStatsSO enemyStat;
    private int poolSize;
    private float prefabSpacing = 3f;
    
    [SerializeField] private float waitingTime;


    
    void Start()
    {
        poolSize = EnemyStat.EnemyNumber;

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, parentObject.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            SetRandomPosition(obj);
        }
    }

    void Update()
    {
        StartCoroutine(Spawner());
        RemoveObject();
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(waitingTime);
        SpawnObject();
    }

    public void SpawnObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (pooledObjects[i] == null)
            {
                return;
            }
            
            if (!pooledObjects[i].activeInHierarchy)
            {
                SetRandomPosition(pooledObjects[i]);
                pooledObjects[i].SetActive(true);
                return;
            }

        }
    }

    public void RemoveObject()
    {
        for(int i = 0; i < poolSize;i++)
        {
            if(pooledObjects[i] == null)
            {
                pooledObjects.Remove(pooledObjects[i]);
                
            }
            if(pooledObjects[i] != null)
            {
                return;
            }
        }
    }

    private void SetRandomPosition(GameObject obj)
    {
        Vector3 randomPosition = GetRandomPosition();
        if (!IsValidPosition(randomPosition))
        {
            // Eğer rastgele pozisyon uygun değilse tekrar konumlandır
            randomPosition = GetRandomPosition();
        }
        obj.transform.position = randomPosition;
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-7f, 15f);
        float z = Random.Range(-7f, 15f);
        return new Vector3(x, 10.2f, z);
    }

    private bool IsValidPosition(Vector3 position)
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (obj.activeInHierarchy && Vector3.Distance(obj.transform.position, position) < prefabSpacing)
            {
                return false;
            }
        }
        return true;
    }

    public int SpawnedObjectsNumber()
    {
        return pooledObjects.Count;
    }

    public bool AreEnemiesDead()
    {
        if(SpawnedObjectsNumber() ==0)
        {
            return true;
        }
        return false;
    } 
}
