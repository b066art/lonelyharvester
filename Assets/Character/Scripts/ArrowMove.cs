using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    void Update()
    {
        transform.localPosition = Vector3.forward * 1.5f + new Vector3(0, 1, 0);
    }
}
