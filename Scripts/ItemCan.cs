using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Player_ball player = other.GetComponent<Player_ball>();
            player.itemCount++;
            gameObject.SetActive(false);

        }    
    }
}
