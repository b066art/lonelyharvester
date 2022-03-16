using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int columnLength, rowLength;
    public float xSpace, zSpace;
    public GameObject gardenBedPrefab;
    public GameObject cutsPrefab;

    void Start()
    {
        for (int i = 0; i < columnLength * rowLength; i++) {
            Instantiate(cutsPrefab, new Vector3(3.2f, 2.75f, 4.55f) + new Vector3(xSpace * (i % columnLength), 0, zSpace * (i / columnLength)), Quaternion.identity);
            Instantiate(gardenBedPrefab, new Vector3(0.93f, -12.2f, 15.4f) + new Vector3(xSpace * (i % columnLength), 0, zSpace * (i / columnLength)), Quaternion.identity); }
    }
}
