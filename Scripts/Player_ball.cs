using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ball : MonoBehaviour
{

    Rigidbody rigid;
    public float jumppower;
    public int itemCount;
    bool isJump;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        isJump = false;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump )
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);

        }

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
            isJump = false;
    }
}
