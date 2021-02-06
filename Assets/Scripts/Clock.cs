using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] RectTransform needleCenter;
    // Start is called before the first frame update
    void Start()
    {
        SetTime(270, 360);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTime(float currentTime,float initTime)
    {
        float rotation;
        rotation = (initTime - currentTime) / initTime * (-360);
        needleCenter.eulerAngles = new Vector3(0, 0, rotation);
    }
}
