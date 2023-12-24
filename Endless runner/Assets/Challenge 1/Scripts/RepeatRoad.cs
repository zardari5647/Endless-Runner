using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{

    public Rigidbody playerRb;

    private void Start()
    {

    }

    private void Update()
    {
        if(playerRb.position.z > transform.position.z + 200){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 600);
        }
    }

}
