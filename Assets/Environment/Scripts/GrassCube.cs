using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrassCube : MonoBehaviour
{
    public Transform grassCube;
    public PathType pathType;
    public PathMode pathMode;
    float randX, randZ;
    Vector3 startPos, midPos, endPos;
    Vector3[] path;

    void Start()
    {
        startPos = grassCube.position;
        randX = Random.Range(-0.5f, 0.5f);
        randZ = Random.Range(-0.5f, 0.5f);
        midPos = startPos + new Vector3(randX / 2, 0.5f, randZ / 2);
        endPos = startPos + new Vector3(randX, -1.2f, randZ);
        path = new[] {startPos, midPos, endPos};
        grassCube.DOPath (path, 1f, pathType, pathMode, 10);
        StartCoroutine(LandingTimer());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && CollectGrass.cGrass.CheckLimit()) {
            GetComponent<Collider>().enabled = false;
            path = new[] {transform.position, other.transform.position + new Vector3(0, 1.25f, 0)};
            grassCube.DOPath (path, 0.3f, pathType, pathMode, 10);
            grassCube.DOScale (new Vector3(0.05f, 0.1f, 0.2f), 0.3f);
            CollectGrass.cGrass.AddCube();
            StartCoroutine(WaitAndDestroy()); }
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    private IEnumerator LandingTimer()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Collider>().enabled = true;
    }
}
