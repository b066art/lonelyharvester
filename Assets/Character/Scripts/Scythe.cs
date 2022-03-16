using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Grass") {
            Vector3 toTarget = (other.transform.position - transform.position).normalized;
            if(Vector3.Dot(toTarget, transform.up) < 0)
                Destroy(other.gameObject);
        }
    }
}
