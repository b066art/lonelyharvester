using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class CollectGrass : MonoBehaviour
{
    public static CollectGrass cGrass;
    public int cLength, rLength;
    public float xSpc, ySpc;
    public GameObject grassCubePrefab;
    public GameObject arrow;
    public Transform salePoint;
    public Transform bagPoint;
    public PathType pathType;
    public PathMode pathMode;
    public static int cubeAmount = 0;
    GameObject gCube;
    Vector3 setPos;

    void Awake()
    {
		cGrass = this;
	}

    public void AddCube() 
    {
        setPos = bagPoint.localPosition;
        gCube = Instantiate(grassCubePrefab, bagPoint);
        gCube.transform.localPosition = setPos + new Vector3(-0.64f, -0.2f, 0f) + new Vector3(xSpc * (cubeAmount % cLength), ySpc * (cubeAmount / cLength), Random.Range(-0.02f, 0.02f));
        cubeAmount++;
        GrassBar.gBar.AddGrass();
    }

    public void SellCubes() 
    {
        float time = 0.05f;
        GameObject[] array = GameObject.FindGameObjectsWithTag("GrassCubeMini");
        foreach(GameObject thisObject in array.Reverse()) {
            StartCoroutine(MoveCube(thisObject, time));
            time += 0.05f; }
    }

    public bool CheckLimit()
    {
        if (cubeAmount > 0)
            arrow.SetActive(true);
        if (cubeAmount < 40) {
            ScreenText.screenTxt.isFull = false;
            ScreenText.screenTxt.isActive = false;
            return true; }
        else {
            ScreenText.screenTxt.isFull = true;
            ScreenText.screenTxt.Full();
            return false; }
    }

    private IEnumerator MoveCube(GameObject thisObject, float time)
    {
        yield return new WaitForSeconds(time);

        Vector3[] path = new[] {thisObject.transform.position, new Vector3(0, 1.5f, 0) +
        Vector3.Lerp(thisObject.transform.position,salePoint.position, 1f / Vector3.Distance(thisObject.transform.position,salePoint.position))
        + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f)),
        salePoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f))};
        
        thisObject.transform.DOPath (path, 1f, pathType, pathMode, 10);
        thisObject.transform.DOScale (new Vector3(0.08f, 0.16f, 0.32f), 1f);
        cubeAmount--;
        GrassBar.gBar.RemoveGrass();
        StartCoroutine(WaitAndDestroy(thisObject));
    }

    private IEnumerator WaitAndDestroy(GameObject thisObject)
    {
        yield return new WaitForSeconds(1f);
        Destroy(thisObject);
        GrassBar.gBar.Sell();
    }
}
