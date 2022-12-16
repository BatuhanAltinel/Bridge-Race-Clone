using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject[] objectToPool;
    public int amountToPool;


    private Vector3 offset;
    //private bool doesPlayerExist;
    private int targetObjCount;

    private int[] possiblePos;
    int head = 14;


    void Awake() 
    {
        possiblePos = new int[10];

        for (int i = 0; i < objectToPool.Length; i++)
        {
            for (int j = 0; j < amountToPool; j++) 
            {
                GameObject obj = (GameObject)Instantiate(objectToPool[i]);
                obj.SetActive(false); 
                pooledObjects.Add(obj);
            }   
        }

        for (int i = 0; i < 10 ; i++)
        {
            possiblePos[i] = head;
            head -= 3;
        }
    }

    void Start()
    {
        GetObject();
    }

    void Update()
    {
        //if (!doesPlayerExist)
          //  return;
    }

    private int count = 0;
    private int randomObj;
    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            randomObj = Random.Range(0, pooledObjects.Count);
            if (!pooledObjects[i].activeInHierarchy) 
            {
                try
                {
                    count++;
                    return pooledObjects[randomObj];
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("Can't find a Object prefab " + ex.ToString());
                    return null;
                }
            }
        }
        
        return null;
    }

    private void GetObject()
    {
        targetObjCount = 10;

        for (int j = 0; j < targetObjCount; j++)
        {
            for (int i = 0; i < targetObjCount; i++)
            {
                GameObject obj = GetPooledObject();
                
                int x = possiblePos[j];
                int z = possiblePos[i];

                offset = new Vector3(x, 0.5f, z);
                // offset = new Vector3(j,1,i);

                if(obj != null)
                {
                    obj.transform.position = offset;
                    obj.SetActive(true);
                    Debug.Log("obj: " + j+","+i+" offset: "+ obj.transform.position.x+", " + obj.transform.position.z);
                }
            }
        }
        Debug.Log(count);
    }
}
