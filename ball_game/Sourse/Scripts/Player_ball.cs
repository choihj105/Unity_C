using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_ball : MonoBehaviour
{

    
    public float jumppower;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;


    Rigidbody rigid;
    AudioSource audio;


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        isJump = false;
        audio = GetComponent<AudioSource>();
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
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);

        }
        else if (other.tag == "Finish")
        {
            if (itemCount == manager.totalItemCount)
            {
                //Game Clear
                if (manager.stage == 2)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(manager.stage + 1);
            }
            else
            {
                //Restart
                SceneManager.LoadScene(manager.stage);
            }
            
        }

    }
}
