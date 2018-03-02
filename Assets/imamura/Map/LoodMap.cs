using UnityEngine;
using System.Collections;

public class LoodMap : MonoBehaviour
{
    private TextAsset csvFile; // CSVファイル
    private string [,,] csvDatas; // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数

    //void Start()
    //{
    //    csvFile = Resources.Load("Assets/imamura/CSV/MAPdate") as TextAsset; /* Resouces/CSV下のCSV読み込み */
    //    StringReader reader = new StringReader(csvFile.text);

    //    while (reader.Peek() > -1)
    //    {
    //        string line = reader.ReadLine();

    //        height++; // 行数加算
    //    }
    //}
}