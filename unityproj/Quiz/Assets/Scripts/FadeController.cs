using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField]
    protected float fadeduration;
    [SerializeField]
    protected bool onStart;
    // Start is called before the first frame update
    void Start()
    {
        if (onStart)
        {
            FadeOut(fadeduration);
        }
    }
    public void FadeIn(float duration)
    {
        Fade(0, 1, duration);
    }
    public void FadeOut(float duration)
    {
        Fade(1, 0, duration);
    }

    // Update is called once per frame
    public void Fade(float startOpacity, float endOpacity, float duration)
    {
        var graphics = gameObject.GetComponents<Graphic>();
        foreach(var graphic in graphics)
        {
            var startColor = graphic.color;
            startColor.a = startOpacity;
            graphic.color = startColor;

            var endColor = graphic.color;
            endColor.a = endOpacity;
            graphic.DOColor(endColor, duration);
        }
    }
}
