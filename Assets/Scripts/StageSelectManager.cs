using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] Transform selectedAllow;
    [SerializeField] Transform[] allowPoints = new Transform[3];
    //[SerializeField] 
    int index = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index < allowPoints.Length)
            {
                index = index + 1;
                Transform targetPoint = allowPoints[index - 1];
                selectedAllow.position = targetPoint.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index > 1)
            {
                index = index - 1;
                Transform targetPoint = allowPoints[index - 1];
                selectedAllow.position = targetPoint.position;
            }
        }
    }
}
