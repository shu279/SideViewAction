using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject goalObject;
    // Update is called once per frame
    void Update()
    {
        int count = GameObject.FindGameObjectsWithTag("Item").Length;
        if (count == 0)
        {
            goalObject.SetActive(true);
        }

    }
}
