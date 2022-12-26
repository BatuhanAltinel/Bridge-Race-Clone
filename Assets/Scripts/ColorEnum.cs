using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEnum : MonoBehaviour
{
    public enum ColorType : int
    {
        Blue = 0,
        Red = 1,
        Green =2
    }

    public ColorType colorType = ColorType.Blue;


}
