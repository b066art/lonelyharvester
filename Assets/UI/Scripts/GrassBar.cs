using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GrassBar : MonoBehaviour
{
    public static GrassBar gBar;
    public RectTransform startPos;
    public RectTransform endPos;
    public Image coinPrefab;
    public PathType pathType;
    public PathMode pathMode;
    private Image grassBar;
    private float grassAmount = 0;
    private float grassMax = 40;

    void Awake()
    {
        gBar = this;
    }

    void Start()
    {
        grassBar = GetComponent<Image>();
    }

    void Update()
    {
        grassBar.fillAmount = grassAmount / grassMax;
    }

    public void AddGrass()
    {
        grassAmount++;
    }

    public void RemoveGrass()
    {
        grassAmount--;
    }

    public void Sell()
    {
        Sequence s = DOTween.Sequence();
        Image dollar = Instantiate(coinPrefab, startPos);

        Vector3[] path = new[] {new Vector3(startPos.position.x, startPos.position.y, 0), new Vector3(startPos.position.x, startPos.position.y, 0)
        + new Vector3(Random.Range(-20f, 20f), 200, 0), new Vector3(endPos.position.x, endPos.position.y, 0)};
        
        dollar.rectTransform.DOPath(path, 1f, pathType, pathMode, 10);
        s.Append(dollar.rectTransform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.5f));
        s.Append(dollar.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f));
        StartCoroutine(WaitAndDestroy(dollar));
    }

    private IEnumerator WaitAndDestroy(Image thisObject)
    {
        yield return new WaitForSeconds(1f);
        Destroy(thisObject);
        Score.scoreTxt.AddMoney();
    }
}
