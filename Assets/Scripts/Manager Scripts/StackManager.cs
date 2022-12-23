using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    ColorEnum colorEnum;
    public Transform stackHolder;
    Vector3 lastBrickPos;
    int brickIndex = 0;
    [SerializeField] float timeToMove = 1.5f;
    [HideInInspector] public List<GameObject> bricks = new();

    string myTag;
    void Awake()
    {
        myTag = Tags.blueTag;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(myTag))
        {
                
            bricks.Add(other.gameObject);

            bricks[brickIndex].transform.parent = this.stackHolder.transform;
            lastBrickPos = this.stackHolder.transform.position;

            bricks[brickIndex].GetComponent<Brick>().BrickBouncing();

            lastBrickPos.y += (bricks.Count-1) * 0.3f;
            bricks[brickIndex].GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
            
            brickIndex++;
        }
    }

    private void Stacking(Collider other)
    {
        // other.gameObject.TryGetComponent<ColorEnum>(out colorEnum) && gameObject.TryGetComponent<ColorEnum>(out colorEnum)
        // if (this.colorEnum.colorType == other.GetComponent<ColorEnum>().colorType)
        //     {
        //         bricks.Add(other.gameObject);
        //         bricks[brickIndex].transform.parent = this.stackHolder.transform;
        //         lastBrickPos = this.stackHolder.transform.position;
        //         bricks[brickIndex].GetComponent<Brick>().BrickBouncing();

        //         if (bricks.Count == 1)
        //         {
        //             bricks[brickIndex].GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
                    
        //         }
        //         else if (bricks.Count > 1)
        //         {
        //             lastBrickPos.y += (bricks.Count-1) * 0.3f;
        //             bricks[brickIndex].GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
        //             brickIndex++;
        //         }

                // lastBrickPos.y += (bricks.Count-1) * 0.3f;
                // bricks[brickIndex].GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
                // brickIndex++;

                
    }    
    



}
