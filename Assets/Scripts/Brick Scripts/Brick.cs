using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    ColorEnum colorEnum;
    // Start is called before the first frame update
    void Start()
    {
        colorEnum = GetComponent<ColorEnum>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(this.colorEnum.colorType == other.GetComponent<ColorEnum>().colorType)
        {
            Debug.Log("Colors matched Color name :" + colorEnum.colorType);
        }
    }
}
