using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    public GameObject grassPrefab;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        GrowingStart();
    }

    void Update()
    {
        if(transform.childCount == 0)
            GrowingStart();
    }

    private void GrowingStart()
    {
        Instantiate (grassPrefab, startPos + new Vector3(0f, -2f, 0f), Quaternion.identity).transform.SetParent(gameObject.transform);
        StartCoroutine(10f.Tweeng((p)=>transform.position=p, transform.position, transform.position + new Vector3(0f, 2f, 0)));
    }

}
