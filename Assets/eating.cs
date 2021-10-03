using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eating : MonoBehaviour
{

    public GameObject sushi;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.z);
        if (transform.position.z > -4.2) 
        {
            afterEat.sushiCount++;
            Destroy(sushi);
        }
    }
}
