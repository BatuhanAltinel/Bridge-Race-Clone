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
    public List<GameObject> bricks = new();

    void Start()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ColorEnum>(out colorEnum) && gameObject.TryGetComponent<ColorEnum>(out colorEnum))
        {
            Stacking(other);

            // SPEED CAUSES THE ERROR
            // HAVE TO FIX IT !!!!!!
            
        }
    }

    private void Stacking(Collider other)
    {
        if (this.colorEnum.colorType == other.GetComponent<ColorEnum>().colorType)
        {
            bricks.Add(other.gameObject);
            other.gameObject.transform.parent = this.stackHolder.transform;
            other.GetComponent<Brick>().BrickBouncing();
            if (bricks.Count == 1)
            {
                lastBrickPos = this.stackHolder.transform.position;
                other.GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
                
            }
            else if (bricks.Count > 1)
            {
                lastBrickPos = this.stackHolder.transform.position;
                lastBrickPos.y += (bricks.Count-1) * 0.3f;
                other.GetComponent<Brick>().BrickMove(stackHolder,lastBrickPos, timeToMove,lastBrickPos.y);
                brickIndex++;
            }
            
            
            
        }
    }



}
