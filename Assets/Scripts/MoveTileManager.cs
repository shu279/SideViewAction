using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTileManager : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector3(0, 0, 1);
    }
    void FixedUpdate()
    {
        rigid.MovePosition(new Vector3(defaultPos.x + Mathf.PingPong(Time.time, 1.7f) * 2, defaultPos.y , defaultPos.z));
    }
}
