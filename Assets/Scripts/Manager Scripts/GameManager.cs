using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    public List<Brick> blueBricks = new();
    public List<Brick> greenBricks = new();
    public List<Brick> redBricks = new();
    void  Awake()
    {
        if(instace == null)
            instace = this;
        else
            Destroy(gameObject);
    }

    public List<Brick> SetTheBrickList(ColorEnum col)
    {
        if(col.colorType == ColorEnum.ColorType.Blue)
            return blueBricks;
        else if(col.colorType == ColorEnum.ColorType.Red)
            return redBricks;
        else
            return greenBricks;
    }
}
