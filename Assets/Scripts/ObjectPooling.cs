using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{

    private Queue bricksQueue = new();
    public GameObject[] Bricks;
    public int amountOfObject;
    private GameObject brickInstantiate;

    List<Vector3> possiblePositions = new();
    int maxX = 13;
    int maxZ = 14;
    float yAxis;
    float yBrickOffset = 0.2f;

    public int xBorder = 10;
    public int zBorder = 15;

    void Start()
    {
        yAxis = transform.position.y;
        FirstBricksSpawn();
        PossiblePositions();
        SetBricksPositions();
    }

    
    void FirstBricksSpawn()
    {
        for (int i = 0; i < Bricks.Length; i++)
        {
            for (int j = 0; j < amountOfObject; j++)
            {
                brickInstantiate = Instantiate(Bricks[i],transform.position,Quaternion.identity);
                bricksQueue.Enqueue(brickInstantiate);
                brickInstantiate.transform.parent = transform;
                brickInstantiate.SetActive(false);
            }
        }
    }

    GameObject GetBrickFromPool()
    {
        foreach (GameObject brick in bricksQueue)
        {
            if(!brick.activeInHierarchy)
            {
                return brick;
            }
        }
        return null;
    }

    void PossiblePositions()
    {
        for (int i = 0; i < zBorder; i++)
        {
            for (int j = 0; j < xBorder; j++)
            {
                Vector3 newPos = new Vector3(maxX,yAxis+yBrickOffset,maxZ);
                possiblePositions.Add(newPos);
                maxX -= 3;
            }
            maxZ -=2;
            maxX = 13;
        }
        
    }

    Vector3 GetRandomPosition()
    {
        int randomPos = Random.Range(0,possiblePositions.Count);
        Vector3 newPos = possiblePositions[randomPos];
        possiblePositions.Remove(possiblePositions[randomPos]);
        return newPos;
    }

    void SetBricksPositions()
    {
         for (int i = 0; i < Bricks.Length; i++)
        {
            for (int j = 0; j < amountOfObject; j++)
            {
                GameObject brick = GetBrickFromPool();
                brick.SetActive(true);
                brick.transform.position = GetRandomPosition();
                brick.GetComponent<Brick>().GroundPosition(brick.transform.position);
                bricksQueue.Dequeue();
            }
        }
    }

}
