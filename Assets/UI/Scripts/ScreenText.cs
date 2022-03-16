using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenText : MonoBehaviour
{
    public static ScreenText screenTxt;
    public RectTransform screenTxtBox;
    public Text sTextBox;
    public bool isFull = false;
    public bool isActive = false;


    void Awake()
    {
        screenTxt = this;
    }

    public void Full()
    {
        if(isFull && !isActive) {
            isActive = true;
            Sequence s = DOTween.Sequence();
            s.Append(screenTxtBox.DOScale(new Vector3(1f, 1f, 1f), 0.75f));
            s.Append(screenTxtBox.DOScale(new Vector3(0, 0, 0), 0.75f)); }
    }

}
