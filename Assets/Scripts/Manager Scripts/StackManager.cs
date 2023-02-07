using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public Transform playerStackHolder;
    Vector3 lastBrickPos;
    int brickIndex = 0;
    [SerializeField] float timeToMove = 1.5f;
    [HideInInspector] public List<Brick> bricks = new();
    public float brickOffsetY = 0.3f;
    
    void OnTriggerEnter(Collider other)
    {
        Stacking(other);
    }

    private void Stacking(Collider other)
    {
        if(other.gameObject.TryGetComponent<Brick>(out Brick brick))
        {
            if(other.gameObject.TryGetComponent<ColorEnum>(out ColorEnum colorEnum) && gameObject.TryGetComponent<ColorEnum>(out ColorEnum PcolorEnum))
            {
                if (colorEnum.colorType == PcolorEnum.colorType )
                {
                    bricks = GameManager.instace.SetTheBrickList(PcolorEnum);
                    bricks.Add(brick);

                    other.gameObject.transform.parent = this.playerStackHolder.transform;
                    lastBrickPos = this.playerStackHolder.transform.position;

                    brick.BrickBouncing();

                    lastBrickPos.y += (bricks.Count-1) * brickOffsetY;
                    brick.MoveTo(lastBrickPos, timeToMove);

                    Debug.Log(nameof(bricks) + " list Count: " + bricks.Count);
                    brickIndex++;
                    }
                    
                }   
            } 
        }
    }


