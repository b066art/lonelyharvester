using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_Plant_Wheat : MonoBehaviour
{
    public GameObject cubePrefab;
    Vector3 startPos;
    bool isClosed = false;

    void Start()
    {
        startPos = transform.position;
        GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        if(transform.position == startPos + new Vector3(0f, 2f, 0))
            GetComponent<Collider>().enabled = true;        
    }

    void OnDestroy() 
    {
        if (!isClosed)
            Instantiate(cubePrefab, startPos + new Vector3(0f, 3f, 0), Quaternion.identity);
    }

    void OnApplicationQuit()
    {
        isClosed = true;
    }
}
