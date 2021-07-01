using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Generator : MonoBehaviour
{
    [SerializeField]
    protected Database db;
    [SerializeField]
    protected GameProcess gp;
    public List<int> exclusion;
    [SerializeField]
    private void Start()
    {

    }
    public void GenerateLvl(int objlist, int lvl)
    {
        List<string> text = new List<string>();
        List<Sprite> sprtlist = new List<Sprite>();
        for (int i = 0; i <= db.ImagesList.lvls[objlist].images.Count - 1; i++)
        {
            sprtlist.Add(db.ImagesList.lvls[objlist].images[i]);
        }
        int cyclecount = 0;
        if(lvl == 0)
        {
            cyclecount = 2;
            exclusion.Clear();
        }
        if (lvl == 1)
        {
            cyclecount = 5;
        }
        if (lvl == 2)
        {
            cyclecount = 8;
        }
        for (int i = 0; i <= cyclecount; i++)
        {
            Sprite sprite = sprtlist[Random.Range(0, sprtlist.Count)];
            db.img[i].sprite = sprite;
            db.cells[i].objID = db.ImagesList.lvls[objlist].images.IndexOf(sprite);
            db.cells[i].transform.DOShakeRotation(0.5f, 50, 4, 1f, true);
            if (text.Count != 0)
            {
                for (int a = 0; a < text.Count; a++)
                {
                    if (text[a] == db.ResultList.lvls[objlist].text[db.ImagesList.lvls[objlist].images.IndexOf(sprite)])
                    {
                        i--;
                        break;
                    }
                }
            }
            text.Add(db.ResultList.lvls[objlist].text[db.ImagesList.lvls[objlist].images.IndexOf(sprite)]);
            int k = exclusion.IndexOf(db.cells[i].objID);
            if(k != -1)
            {
                i--;
                text.Remove(db.ResultList.lvls[objlist].text[db.ImagesList.lvls[objlist].images.IndexOf(sprite)]);
            }
            Debug.Log(k);
        }
        int rand = Random.Range(0, text.Count);
        gp.winText = text[rand];
        gp.winID = db.ResultList.lvls[objlist].text.IndexOf(gp.winText);
        exclusion.Add(db.ResultList.lvls[objlist].text.IndexOf(gp.winText));
    }
}
