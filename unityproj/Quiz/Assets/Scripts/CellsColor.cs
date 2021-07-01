using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellsColor : MonoBehaviour
{
    Image sprt;
    void OnEnable()
    {
        sprt = gameObject.GetComponent<Image>();
        Color randomColor = new Color(Random.Range(0,256), Random.Range(0, 256), Random.Range(0, 256));
        sprt.color = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256));
    }
}
