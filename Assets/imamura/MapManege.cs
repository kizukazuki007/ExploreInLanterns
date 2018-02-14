using UnityEngine;
using System.Collections;

public class MapManege : MonoBehaviour {
    public GameObject []Monster;//unityでアタッチして
    public int[] MonsterCount;//どのモンスター[]を何引き出すか
    public GameObject presentBox;//プレゼント
    public int presentBoxCount;//宝箱を何個出すか

    public GameObject []player;//プレーヤ―
    public GameObject stairs;//強制１個
                                        //iventのゲームオブジェクトをすべて一つの変数にまとめてしまえば一発でできる？←要検討
    public GameObject wall;
    public GameObject ground;

    GameObject[,] mapChipG;
    GameObject[,] ivent;
    int mapNomber;
    //一時的に書いておく
    public int playerCount;     //タイトルで設定した数字をここにいれる
    int[,,] mapChipI;
    void Start()//最初作るとき
    {
        AllCreate();
    }
    public void StairsUP()//階段を上がった時。               他の人が呼び出すのはここだけ
    {
        AllDestroy();
        AllCreate();
    }
    public void MonsterDedCreate()
    {
        int x = Random.Range(0, mapChipI.GetLength(0));
        int y = Random.Range(0, mapChipI.GetLength(1));

    }


    void AllCreate()     //最初と階段を上った時に呼び出す。
    {
        mapNomber = Random.Range(0, 3);
        MapCreate();
        PlayrCreate();
        StairsCreate();
        MonsterCreate();
        PresentCreate();
    }
    void AllDestroy()
    {
        for (int i = 0; i < mapChipI.GetLength(0); i++)
        {
            for (int j = 0; j < mapChipI.GetLength(1); j++)
            {
                if (mapChipG[i, j] != null)
                {
                    Destroy(mapChipG[i, j]);
                    mapChipG[i, j]= null;
                }
            }
        }
        for (int i = 0; i < ivent.GetLength(0); i++)
        {
            for (int j = 0; i < ivent.GetLength(0); j++)
            {
                Destroy(ivent[i, j]);
                ivent[i, j] = null;
            }

        }
    }//階段を上った時と終わるときに呼び出す。

    void MapCreate()
    {

        for (int i = 0; i < mapChipI.GetLength(0); i++)
        {
            for (int j = 0; j < mapChipI.GetLength(1); j++)
            {
                if (mapChipI[mapNomber, i, j] == 1)
                {
                    ground.transform.position = new Vector2(i, j);
                    mapChipG[i, j] = Instantiate(ground);
                }
                else if (mapChipI[mapNomber, i, j - 1] == 1)
                {
                    ground.transform.position = new Vector2(i, j);
                    mapChipG[i, j] = Instantiate(wall);
                }
            }
        }
    }
    void StairsCreate()
    {
        do
        {
            int x = Random.Range(0, mapChipI.GetLength(0));
            int y = Random.Range(0, mapChipI.GetLength(1));
            if (mapChipI[mapNomber, x, y] == 1)
            {
                stairs.transform.position = new Vector2(x, y);
                ivent[x, y] = Instantiate(stairs);
        //        mapChipI[mapNomber, x, y] = 0;
                break;
            }
        } while (true);
    }
    void MonsterCreate()
    {
        for (int i = 0; i < Monster.Length; i++)
        {
            for (int j = 0; i < MonsterCount[i]; j++)
            {
                do
                {
                    int x = Random.Range(0, mapChipI.GetLength(0));
                    int y = Random.Range(0, mapChipI.GetLength(1));
                    if (mapChipI[mapNomber, x, y] == 1)
                    {
                        Monster[i].transform.position = new Vector2(x, y);
                        ivent[x, y] = Instantiate(Monster[i]);
   //                     mapChipI[mapNomber, x, y] = 0;
                        break;
                    }
                } while (true);
            }
        }
    }
    void PresentCreate()
    {
        for (int i = 0; i < MonsterCount[i]; i++)
        {
            do
            {
                int x = Random.Range(0, mapChipI.GetLength(0));
                int y = Random.Range(0, mapChipI.GetLength(1));
                if (mapChipI[mapNomber, x, y] == 1)
                {
                    presentBox.transform.position = new Vector2(x, y);
                    ivent[x, y] = Instantiate(presentBox);
                    break;
                }
            } while (true);
        }
    }
    void PlayrCreate()
    {
        int x;
        int y;
        do
        {
            x = Random.Range(0, mapChipI.GetLength(0));
            y = Random.Range(0, mapChipI.GetLength(1));
            if (mapChipI[mapNomber, x, y] == 1 && mapChipI[mapNomber, x - 1, y] == 1 && mapChipI[mapNomber, x, y - 1] == 1)
            {
                player[0].transform.position = new Vector2(x, y);//１Pの位置
                ivent[x, y] = Instantiate(player[0]);
                break;
            }
        } while (true);
        if (playerCount >= 2)
        {
            player[1].transform.position = new Vector2(x-1, y);
            ivent[x - 1, y] = Instantiate(player[2]);
            if (playerCount >= 3)
            {
                player[2].transform.position = new Vector2(x, y - 1);
                ivent[x, y - 1] = Instantiate(player[2]);
                if (playerCount >= 4)
                {
                    player[3].transform.position = new Vector2(x - 1, y - 1);
                    ivent[x - 1, y - 1] = Instantiate(player[3]);
                }
            }
        }
        //1Pの近くに２P３P４P
    }
}
