using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    ColorEnum colorEnum;
    public GameObject stackHolder;
    Vector3 offset;
    Transform currentPos;

    [SerializeField] float timeToMove = 1.5f;
    List<GameObject> bricks = new();
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0,0.03f,0);
        currentPos = stackHolder.transform;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ColorEnum>(out colorEnum) && gameObject.TryGetComponent<ColorEnum>(out colorEnum))
        {
            if(this.colorEnum.colorType == other.GetComponent<ColorEnum>().colorType)
            {
                Debug.Log("Colors matched Color name :" + colorEnum.colorType);
                bricks.Add(other.gameObject);
                // StackBrick(other.gameObject);
                    
                if (bricks.Count == 1)
                {
                    currentPos.position = stackHolder.transform.position;
                    other.GetComponent<Brick>().BrickMove(currentPos, timeToMove);
                   
                    currentPos.position += offset;
                }
                else if (bricks.Count > 1)
                {
                    Transform followTransform = currentPos;
                    other.GetComponent<Brick>().BrickMove(followTransform, timeToMove);
                    followTransform.position += offset;
                }
                
    

            }
        }
    }

    // private void StackBrick(GameObject other)
    // {
    //     if (bricks.Count >= 1)
    //     {
    //         other.GetComponent<Brick>().BrickMove(stackHolder.transform, timeToMove);
    //         currentPos = stackHolder.transform;
    //         currentPos.position += offset;
    //     }
    //     else if (bricks.Count > 1)
    //     {
            
    //         Transform followTransform = currentPos;
    //         other.GetComponent<Brick>().BrickMove(followTransform, timeToMove);
    //         followTransform.position += offset;
    //     }
    //     other.gameObject.transform.parent = stackHolder.transform;
    //     other.transform.localRotation = Quaternion.identity;
    //     other.transform.localPosition = Vector3.zero;
    // }

}
