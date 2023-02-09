using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairColorDetector : MonoBehaviour
{
    public ColorEnum colEnum;
    Vector3 stairTriggerStartPos;
    public GameObject stairTrigger;
    void Start()
    {
        stairTriggerStartPos = stairTrigger.transform.position;
        colEnum = stairTrigger.gameObject.GetComponent<ColorEnum>();
        colEnum.colorType = ColorEnum.ColorType.Empty;   
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ColorEnum>(out ColorEnum colorEnum))
        {
            if(colEnum.colorType == ColorEnum.ColorType.Empty)
                colEnum.colorType = colorEnum.colorType;
            
            bool isMacthed = colEnum.colorType == colorEnum.colorType ? true : false;

            if(!isMacthed)
            {
                stairTrigger.transform.position = stairTriggerStartPos;    
            }
        }
    }

    public bool IsColorMacthed(ColorEnum colorEnum)
    {
        return colEnum.colorType == colorEnum.colorType ? true : false;
    }
}
