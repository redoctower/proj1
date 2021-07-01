using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    public List<Image> img;
    public List<Cell> cells;
    public List<GameObject> backgroundCells;
    [System.Serializable]
    public class CellsImage
    {
        public List<Sprite> images;
    }

    [System.Serializable]
    public class PointList
    {
        public List<CellsImage> lvls;
    }
    public PointList ImagesList = new PointList();

    [System.Serializable]
    public class Results
    {
        public List<string> text;
    }

    [System.Serializable]
    public class ResultsList
    {
        public List<Results> lvls;
    }
    public ResultsList ResultList = new ResultsList();
}
