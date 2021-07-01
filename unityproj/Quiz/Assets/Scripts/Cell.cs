using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class Cell : MonoBehaviour, IPointerClickHandler
{
    [Header("ID объекта в ячейке")]
    public int objID;
    public Image img;
    public GameProcess gp;
    public GameObject partical;

    private void Start()
    {
        img = this.GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(objID == gp.winID)
        {
            Invoke(nameof(NextRound), 1f);
            transform.DOShakeRotation(1f, 50, 4, 1f, true);
            partical.SetActive(true);
        }
        else
        {
            transform.DOShakePosition(1f, 15, 4, 1f, true);
        }
    }
    public void NextRound()
    {
        partical.SetActive(false);
        gp.GetResult();
    }

}
