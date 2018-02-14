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
    int mapNomber=-1;

   public Camera Camera;//モンスターの出現位置を制限するためにアタッチしてほしい
    public int monsterDistanceX; public int monsterDistanceY;

    //一時的に書いておく
    public int playerCount;     //タイトルで設定した数字をここにいれる
    int[,,] mapChipI;
    void Start()//最初作るとき
    {
        AllCreate();
    }
    public void StairsUP()//階段を上がった時。               他の人が呼び出すところ
    {
        AllDestroy();
        AllCreate();
    }
    public void MonsterDedCreate()//モンスターが死んだとき　　　他の人が呼び出す奴２
    {
        do
        {
            int x = Random.Range(0, mapChipI.GetLength(1));                                     //修正
            int y = Random.Range(0, mapChipI.GetLength(2));
            if (aisle(x, y) && (Camera.transform.position.x + monsterDistanceX < x || Camera.transform.position.x - monsterDistanceX > x|| Camera.transform.position.y + monsterDistanceY < y || Camera.transform.position.y - monsterDistanceY > y))
            {
                int i = Random.Range(0, Monster.Length);
                Monster[i].transform.position = new Vector2(x, y);
                ivent[x, y] = Instantiate(Monster[i]);
            }
        } while (true);
    }

    void AllCreate()     //最初と階段を上った時に呼び出す。
    {
        do
        {
            int randam = Random.Range(0, 3);
            if (randam != mapNomber)
            {
                mapNomber = randam;
                break;
            }
        } while (true);
        MapCreate();
        PlayrCreate();
        StairsCreate();
        MonsterCreate();
        PresentCreate();
    }
    void AllDestroy()
    {
        for (int i = 0; i < mapChipI.GetLength(1); i++)
        {
            for (int j = 0; j < mapChipI.GetLength(2); j++)
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

        for (int i = 0; i < mapChipI.GetLength(1); i++)
        {
            for (int j = 0; j < mapChipI.GetLength(2); j++)
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
            int x = Random.Range(0, mapChipI.GetLength(1));
            int y = Random.Range(0, mapChipI.GetLength(2));
            if (aisle(x, y))
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
                    int x = Random.Range(0, mapChipI.GetLength(1));
                    int y = Random.Range(0, mapChipI.GetLength(2));
                    if (aisle(x, y))
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
                int x = Random.Range(0, mapChipI.GetLength(1));
                int y = Random.Range(0, mapChipI.GetLength(2));
                if (aisle(x,y))
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
            x = Random.Range(0, mapChipI.GetLength(1));
            y = Random.Range(0, mapChipI.GetLength(2));
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
    bool aisle(int x,int y)
    {
        if (mapChipI[mapNomber, x, y] == 1&&(mapChipI[mapNomber, x+1, y] == 0||mapChipI[mapNomber, x-1, y] == 0)&& (mapChipI[mapNomber, x, y+1] == 0||mapChipI[mapNomber, x, y-1] == 0)&&ivent[x,y]==null)
            return true;
            return false;
    }
}
