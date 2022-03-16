using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Score : MonoBehaviour
{
    public static Score scoreTxt;
    public Text textBox;
    public Image coinBar;
    private int money = 0;

    void Awake()
    {
        scoreTxt = this;
    }

    void Update()
    {
        textBox.text = money.ToString("000000");
    }

    public void AddMoney()
    {
        money += 15;
        Sequence s = DOTween.Sequence();
        s.Append(coinBar.rectTransform.DOShakeAnchorPos(0.05f, 5, 10, 50, true));
    }
}
