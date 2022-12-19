using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    ColorEnum colorEnum;
    float xIndex;
    float zIndex;
    // Start is called before the first frame update
    void Start()
    {
        colorEnum = GetComponent<ColorEnum>();
    }

    public void InitPosition(float x, float z)
    {
       xIndex = x;
       zIndex = z;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ColorEnum>(out colorEnum) && gameObject.TryGetComponent<ColorEnum>(out colorEnum))
        {
            if(this.colorEnum.colorType == other.GetComponent<ColorEnum>().colorType)
            {
                Debug.Log("Colors matched Color name :" + colorEnum.colorType);
                gameObject.SetActive(false);
            }
        }
        
    }
}
