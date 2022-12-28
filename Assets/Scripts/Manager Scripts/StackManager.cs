using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    ColorEnum colorEnum;
    Brick brickScript;
    public Transform stackHolder;
    Vector3 lastBrickPos;
    int brickIndex = 0;
    [SerializeField] float timeToMove = 1.5f;
    [HideInInspector] public List<GameObject> bricks = new();

    [SerializeField] string myTag;
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
                
                if(other.gameObject.TryGetComponent<Brick>(out brickScript))
                {
                    other.gameObject.transform.parent = this.stackHolder.transform;
                    lastBrickPos = this.stackHolder.transform.position;

                    other.gameObject.GetComponent<Brick>().BrickBouncing();
                    lastBrickPos.y += (bricks.Count-1) * brickOffsetY;

                    other.gameObject.GetComponent<Brick>().MoveTo(lastBrickPos, timeToMove);
                    
                }else
                {
                    Debug.LogWarning("Brick instance is null error");
                    bricks.Remove(other.gameObject);
                    brickIndex--;
                }
                brickIndex++;
                
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
