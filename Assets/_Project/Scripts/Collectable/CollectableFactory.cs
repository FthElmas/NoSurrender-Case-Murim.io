using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NoSurrender.Collectable
{

    public class CollectableFactory : MonoBehaviour
    {
    [SerializeField] private GameObject prefab;
    public int objectCount;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    
    private List<GameObject> objects = new List<GameObject>();

    private void Start()
    {
        Transform parentTransform = transform;
        for (int i = 0; i < objectCount; i++)
        {
            CreateObject(parentTransform);
        }
    }

    private void Update()
    {
        CheckObjects();
    }

    private void CheckObjects()
    {
        for (int i = objects.Count - 1; i >= 0; i--)
        {
            if (objects[i] == null)
            {
                objects.RemoveAt(i);
                Transform parentTransform = transform;
                CreateObject(parentTransform);
            }
        }
    }

    private void CreateObject(Transform parentTransform)
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 10.25f, Random.Range(minZ, maxZ));
        GameObject newObject = Instantiate(prefab, randomPosition, Quaternion.identity, parentTransform);
        objects.Add(newObject);
    } 
    }

}
