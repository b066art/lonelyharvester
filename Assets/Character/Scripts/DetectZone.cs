using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZone : MonoBehaviour
{
    public GameObject arrow;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "SaleZone") {
            CollectGrass.cGrass.SellCubes();
            arrow.SetActive(false); }
    }
}
