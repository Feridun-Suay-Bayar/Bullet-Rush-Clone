using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private static ObjectPooling instance = null;
    public static ObjectPooling Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject("ObjectPooling").AddComponent<ObjectPooling>();   
            }
            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }

    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int poolSize;
    }
    [SerializeField] private Pool[] pools = null;

    private void Awake()
    {
        for(int j =0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();
            for(int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab);
                obj.SetActive(false); 
                pools[j].pooledObjects.Enqueue(obj);
            }
        }
    }
    public GameObject GetPooledObject(int type)
    {
        GameObject obj = pools[type].pooledObjects.Dequeue();
        obj.SetActive(true);
        pools[type].pooledObjects.Enqueue((GameObject)obj);
        return obj;
    }
}
