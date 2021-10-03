using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class okane : MonoBehaviour
{
    public GameObject OKANE;
    public GameObject particle;
    public GameObject diaBar;
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "okane_interaction")
        {
            Destroy(OKANE);
            particle.SetActive(false);
            diaBar.SetActive(true);
        }
    }
}
