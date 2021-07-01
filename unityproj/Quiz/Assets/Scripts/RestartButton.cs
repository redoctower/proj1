using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class RestartButton : MonoBehaviour, IPointerClickHandler
{
    public GameProcess gp;
    public FadeController fadecontr;
    public void OnPointerClick(PointerEventData eventData)
    {
        Invoke(nameof(NextRound), 1f);
        transform.DOBlendableLocalRotateBy(new Vector3(0, 0, -360), 1f, RotateMode.FastBeyond360);
    }
    public void NextRound()
    {
        gp.round = 0;
        gp.GetResult();
        this.gameObject.SetActive(false);
        fadecontr.FadeOut(1f);
    }
}
