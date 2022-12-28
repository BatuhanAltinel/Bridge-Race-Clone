using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    ColorEnum colorEnum;
    Brick brickScript;
    public Transform playerStackHolder;
    public Transform stairStackHolder;
    Vector3 lastBrickPos;
    int brickIndex = 0;
    bool isParentStair = false;
    public bool test = true;
    public string myTag;
    [SerializeField] float timeToMove = 1.5f;
    [HideInInspector] public List<GameObject> bricks = new();
    [HideInInspector] public Stack<GameObject> BrickStacks = new();
    public float brickOffsetY = 0.3f;
    public float brickOffsetZ;
    
    void OnTriggerEnter(Collider other)
    {
        Stacking(other);
    }

    private void Stacking(Collider other)
    {
        if(other.gameObject.TryGetComponent<ColorEnum>(out colorEnum) && gameObject.TryGetComponent<ColorEnum>(out colorEnum))
        {
            if (this.colorEnum.colorType == other.GetComponent<ColorEnum>().colorType)
            {
                bricks.Add(other.gameObject);
                BrickStacks.Push(other.gameObject);
                if(!isParentStair)
                    other.gameObject.transform.parent = this.playerStackHolder.transform;
                if(other.gameObject.TryGetComponent<Brick>(out brickScript))
                {
                    lastBrickPos = this.playerStackHolder.transform.position;
                    // lastBrickPos = BrickStacks.Peek().transform.position;
                    other.gameObject.GetComponent<Brick>().BrickBouncing();
                    lastBrickPos.y += (bricks.Count-1) * brickOffsetY;
                    // lastBrickPos.y += brickOffsetY;

                    other.gameObject.GetComponent<Brick>().MoveTo(lastBrickPos, timeToMove);
                    // brickOffsetY += 0.3f;
                }else
                {
                    Debug.LogWarning("Brick instance is null error");
                    bricks.Remove(other.gameObject);
                    brickIndex--;
                }
                brickIndex++;
                
            }   
        } 
        if(other.gameObject.CompareTag("Stair"))
        {
            Debug.Log("brick count" + BrickStacks.Count);
            isParentStair = true;
            BrickStacks.Pop().transform.parent = null;
            BrickStacks.Pop().transform.parent = this.stairStackHolder.transform;
            lastBrickPos = this.stairStackHolder.transform.position;
            BrickStacks.Pop().GetComponent<Brick>().BrickBouncing();
            lastBrickPos.y += brickOffsetY;
            BrickStacks.Pop().GetComponent<Brick>().MoveTo(lastBrickPos, timeToMove);
        } 

        if(other.gameObject.CompareTag("Test"))
        {
            if(test)
            {
                GameObject brick = BrickStacks.Peek();
                brick.transform.parent = null;
                Vector3 grpos =brick.GetComponent<Brick>().spawnedPosition;
                brick.GetComponent<Brick>().MoveTo(grpos,timeToMove);
                brick.GetComponent<Brick>().BrickBouncing();
                BrickStacks.Pop();
                test = false;
            }
            

        }  
    }





// bricks.Add(other.gameObject);
                // bricks[brickIndex].transform.parent = this.stackHolder.transform;
                // lastBrickPos = this.stackHolder.transform.position;
                // bricks[brickIndex].GetComponent<Brick>().BrickBouncing();

                // if (bricks.Count == 1)
                // {
                //     bricks[brickIndex].GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
                        
                // }
                // else if (bricks.Count > 1)
                // {
                //     lastBrickPos.y += (bricks.Count-1) * 0.3f;
                //     bricks[brickIndex].GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
                //     brickIndex++;
                // }

                // lastBrickPos.y += (bricks.Count-1) * 0.3f;
                // bricks[brickIndex].GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
                // brickIndex++;

}
