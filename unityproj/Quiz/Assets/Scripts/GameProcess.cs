using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour
{
    Database db;
    Generator gr;
    public int round;
    public string winText;
    public Text result_text;
    public int winID;
    public Image restart;
    public FadeController fadecont;

    private void Start()
    {
        db = gameObject.GetComponent<Database>();
        gr = gameObject.GetComponent<Generator>();
        GetResult();
    }
    void EditCellsCount()
    {
        for (int i = 0; i <= db.img.Count - 1; i++)
        {
            db.img[i].gameObject.SetActive(false);
            db.backgroundCells[i].gameObject.SetActive(false);
        }
        for (int i = 0; i <= db.img.Count - 1; i++)
        {
            if(round == 0)
            {
                db.img[i].gameObject.SetActive(true);
                db.backgroundCells[i].gameObject.SetActive(true);
                if (i == 2)
                {
                    break;
                }
            }
            if(round == 1)
            {
                db.img[i].gameObject.SetActive(true);
                db.backgroundCells[i].gameObject.SetActive(true);
                if (i == 5)
                {
                    break;
                }
            }
            if (round == 2)
            {
                db.img[i].gameObject.SetActive(true);
                db.backgroundCells[i].gameObject.SetActive(true);
                if (i == 8)
                {
                    break;
                }
            }
        }
    }
    public void GetResult()
    {
        if(round <= 2)
        {
            EditCellsCount();
            int rand = Random.Range(0, db.ImagesList.lvls.Count);
            gr.GenerateLvl(rand, round);
            result_text.text = "Найдите: " + winText;
            round++;
        }
        else
        {
            fadecont.FadeIn(1f);
            gr.exclusion.Clear();
            restart.gameObject.SetActive(true);
        }
    }
}
