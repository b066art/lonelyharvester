using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform player;
    public Transform saleZone;

    void Update()
    {
        transform.position = player.position;
        transform.LookAt(saleZone);
    }
}
