using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDetector : MonoBehaviour
{
    [HideInInspector] public GameObject targetBrick;
    List<GameObject> detectedBricks = new List<GameObject>();
    public string myTag;
    int detectedBrickIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetBrick = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(myTag))
        {
            detectedBricks.Add(other.gameObject);
            detectedBrickIndex++;
            Debug.Log("targeted bricks count: " + detectedBrickIndex);
        }
    }

    public GameObject GetTargetBrick()
    {
        if(detectedBricks.Count != 0)
        {
            int randomIndex = Random.Range(0,detectedBrickIndex);
            targetBrick = detectedBricks[randomIndex];
        }else
            return null;
        return targetBrick;
    }
}
