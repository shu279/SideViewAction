using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatToTreeManager : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        defaultPos = transform.position;
    }

    void FixedUpdate()
    {
        rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, 1.5f) * 2, defaultPos.z));
    }
}
