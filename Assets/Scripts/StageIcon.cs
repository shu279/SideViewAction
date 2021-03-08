using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageIcon : MonoBehaviour
{
    private bool iSelected;
    public bool selected
    {
        get { return iSelected; }
        set
        {
            if (value == true && iSelected == false)
            {
                GetComponent<Animator>().Play("Stage-icon Selected Animation");
            }
            iSelected = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
