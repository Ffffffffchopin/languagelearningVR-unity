using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft : MonoBehaviour
{
    private float aircraftTime;
    Vector3 pos = new Vector3(4128, 940f, 2576f);

    void Update()
    {
        if (aircraftTime < 8f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, pos, Time.deltaTime / 3);
            aircraftTime += Time.deltaTime;
        }

        if (aircraftTime > 8f)
        {
            aircraftTime = 0f;
            this.transform.position = new Vector3(-2033f, -535f, 1157);
        }
    }
}
