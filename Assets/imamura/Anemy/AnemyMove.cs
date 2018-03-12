using UnityEngine;
using System.Collections;

public class AnemyMove : MonoBehaviour
{
    int distance = 10;
    bool attack = false;

    float speed = 1;
    MapManege MManege;

    Vector3 targetVector;
    Vector3 target;
    bool anemyInRoom = true;
    int houkou = 0;
    int movePatern;

    soundContolloer SE;
    void Awake()
    {
        SE = GameObject.Find("soundContolloer").GetComponent<soundContolloer>();
        movePatern = Random.Range(0, 3);//0なら部屋内完全ランダム１なら完全追従２ならランダム→部屋内追従
    }
    void Start()
    {
        SE.GetComponent<soundContolloer>();
        MManege = GameObject.Find("MAPCreate").GetComponent<MapManege>();
        target = transform.position;
    }
    void Update()
    {
        if (movePatern == 0)
        {
            if (Vector3.Distance(transform.position, target) < 0.5f)
            {
                target = RandameMove();
            }
        }
        else
        {
            if (PlayerInRoom())
            {
                target = MManege.camera.transform.position;                 //1pからではなくカメラからとるのは、そいつが死んでもカメラは動くから。簡単
                target.z = 0;
            }
            else
            {
                if (Vector3.Distance(transform.position, target) < 0.5f)
                {
                    if (movePatern == 1)
                    {
                        if (anemyInRoom)
                        {
                            target = NoPlayer();
                            anemyInRoom = false;
                        }
                        else
                        {
                            target = aisle();
                            anemyInRoom = true;
                        }
                    }
                    else
                    {
                        target = RandameMove();
                    }
                }
            }
        }


        targetVector = target - transform.position;

        transform.position += targetVector.normalized * speed * Time.deltaTime;//実際の移動
    }
    bool PlayerInRoom()//部屋プレーヤーがいるか
    {
        if ((MaxX()+0.5f > MManege.camera.transform.position.x && MinX() - 0.5f < MManege.camera.transform.position.x) && (MaxY() + 0.5f > MManege.camera.transform.position.y && MinY() - 0.5f < MManege.camera.transform.position.y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    Vector3 RandameMove()
    {
        Vector3 randa = new Vector3(Random.Range(MinX(), MaxX()), Random.Range(MinY(), MaxY()));
        return randa;
    }
    Vector3 NoPlayer()//プレーヤーが部屋にいないときに向かう場所。
    {
        Vector3[] direction = new Vector3[4];//順に上下左右の辺での穴の開いてる場所(無い場合有)
        bool[] directionOn = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            direction[i] = new Vector3(999, 999, 0);
            directionOn[i] = true;
        }

        int maxX = MaxX();
        int minX = MinX();
        int maxY = MaxY();
        int minY = MinY();
        int kyori = 0;
        int[] houkouHairetu = { 0, 1, 2, 3 };
        do
        {
            if (MManege.mapChipI[MManege.mapNomber, maxX - kyori, maxY] == 1)
            {
                if (MManege.mapChipI[MManege.mapNomber, maxX - kyori, maxY + 1] == 1)//上が歩ける場合。
                {
                    direction[0] = new Vector3(maxX - kyori, maxY);
                    break;
                }
            }
            else
            {
                directionOn[0] = false;
                break;
            }
            kyori++;
        } while (true);
        kyori = 0;
        do
        {
            if (MManege.mapChipI[MManege.mapNomber, maxX - kyori, minY] == 1)
            {
                if (MManege.mapChipI[MManege.mapNomber, maxX - kyori, minY - 1] == 1)//下が歩ける場合。
                {
                    direction[1] = new Vector3(maxX - kyori, minY);
                    break;
                }
            }
            else
            {
                directionOn[1] = false;
                break;
            }
            kyori++;
        } while (true);
        kyori = 0;
        do
        {
            if (MManege.mapChipI[MManege.mapNomber, minX, maxY - kyori] == 1)
            {
                if (MManege.mapChipI[MManege.mapNomber, minX - 1, maxY - kyori] == 1)//左が歩ける場合。
                {
                    direction[2] = new Vector3(minX, maxY - kyori);
                    break;
                }
            }
            else
            {
                directionOn[2] = false;
                break;
            }
            kyori++;
        } while (true);
        kyori = 0;
        do
        {
            if (MManege.mapChipI[MManege.mapNomber, maxX, maxY - kyori] == 1)
            {
                if (MManege.mapChipI[MManege.mapNomber, maxX + 1, maxY - kyori] == 1)//右が歩ける場合。
                {
                    direction[3] = new Vector3(maxX, maxY - kyori);
                    break;
                }
            }
            else
            {
                directionOn[3] = false;
                break;
            }
            kyori++;
        } while (true);
        //方向を比較して近いほう＆＆さっき通った道とは違うところ

        Vector3 tekitou = Vector3.zero;
        bool tekitouBool = false;
        int houkouTekitou = 0;
        for (int i = 0; i < direction.Length; i++)
        {
            for (int j = i + 1; j < direction.Length; j++)
            {
                if (Vector3.Distance(direction[i], MManege.camera.transform.position) > Vector3.Distance(direction[j], MManege.camera.transform.position))
                {
                    tekitou = direction[i];
                    direction[i] = direction[j];
                    direction[j] = tekitou;
                    tekitouBool = directionOn[i];
                    directionOn[i] = directionOn[j];
                    directionOn[j] = tekitouBool;
                    houkouTekitou = houkouHairetu[i];
                    houkouHairetu[i] = houkouHairetu[j];
                    houkouHairetu[j] = houkouTekitou;

                }
            }
        }
        for (int i = 0; i < directionOn.Length; i++)
        {
            if (directionOn[i])
            {
                houkou = houkouHairetu[i];
                return direction[i];
            }
        }
        return direction[0];
    }
    Vector3 aisle()
    {

        int x = (int)System.Math.Round(transform.position.x);
        int y = (int)System.Math.Round(transform.position.y);
        
        switch (houkou)
        {
            case 0:
                do
                {
                    y++;
                    if (MManege.mapChipI[MManege.mapNomber, x + 1, y] == 1 && MManege.mapChipI[MManege.mapNomber, x - 1, y] == 1)
                    {
                        return new Vector3(x, y);
                    }
                } while (true);
            case 1:
                do
                {
                    y--;
                    if (MManege.mapChipI[MManege.mapNomber, x + 1, y] == 1 && MManege.mapChipI[MManege.mapNomber, x - 1, y] == 1)
                    {
                        return new Vector3(x, y);
                    }
                } while (true);
            case 2:
                do
                {
                    x--;
                    if (MManege.mapChipI[MManege.mapNomber, x, y + 1] == 1 && MManege.mapChipI[MManege.mapNomber, x, y - 1] == 1)
                    {
                        return new Vector3(x, y);
                    }
                } while (true);
            case 3:
                do
                {
                    x++;
                    if (MManege.mapChipI[MManege.mapNomber, x, y + 1] == 1 && MManege.mapChipI[MManege.mapNomber, x, y - 1] == 1)
                    {
                        return new Vector3(x, y);
                    }
                } while (true);
        }
        return transform.position;
    }
    int MaxX()//今いる部屋の最右
    {
        int Xpos = (int)System.Math.Round(transform.position.x);
        int y = (int)System.Math.Round(transform.position.y);
        do
        {
            if (MManege.mapChipI[MManege.mapNomber, Xpos, y] == 1)
            {
                if (MManege.mapChipI[MManege.mapNomber, Xpos, y + 1] == 0 && MManege.mapChipI[MManege.mapNomber, Xpos, y - 1] == 0)
                {
                    break;
                }
            }
            else
            {
                break;
            }
            Xpos++;
        } while (true);
        Xpos--;
        return Xpos;
    }
    int MaxY()
    {
        int x = (int)System.Math.Round(transform.position.x);
        int Ypos = (int)System.Math.Round(transform.position.y);
        do
        {
            if (MManege.mapChipI[MManege.mapNomber, x, Ypos] == 1)
            {
                if (MManege.mapChipI[MManege.mapNomber, x + 1, Ypos] == 0 && MManege.mapChipI[MManege.mapNomber, x - 1, Ypos] == 0)
                {
                    break;
                }
            }
            else
            {
                break;
            }
            Ypos++;
        } while (true);
        Ypos--;
        return Ypos;
    }
    int MinX()
    {
        int Xpos = (int)System.Math.Round(transform.position.x);
        int y = (int)System.Math.Round(transform.position.y);
        do
        {
            if (MManege.mapChipI[MManege.mapNomber, Xpos, y] == 1)
            {
                if (MManege.mapChipI[MManege.mapNomber, Xpos, y + 1] == 0 && MManege.mapChipI[MManege.mapNomber, Xpos, y - 1] == 0)
                {
                    break;
                }
            }
            else
            {
                break;
            }
            Xpos--;
        } while (true);
        Xpos++;
        return Xpos;
    }
    int MinY()
    {
        int x = (int)System.Math.Round(transform.position.x);
        int Ypos = (int)System.Math.Round(transform.position.y);
        do
        {
            if (MManege.mapChipI[MManege.mapNomber, x, Ypos] == 1)
            {
                if (MManege.mapChipI[MManege.mapNomber, x + 1, Ypos] == 0 && MManege.mapChipI[MManege.mapNomber, x - 1, Ypos] == 0)
                {
                    break;
                }
            }
            else
            {
                break;
            }
            Ypos--;
        } while (true);
        Ypos++;
        return Ypos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack1" || other.gameObject.tag == "Attack2")
        {
            if (other.gameObject.tag == "Attack1")
            {
                SE.select_SE(6);
            }
            else
            {
                SE.select_SE(7);
            }
            this.speed = 0.5f;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2")
        {
        Debug.Log("bbb");
            if (Vector3.Distance(transform.position, target) > Vector3.Distance(other.transform.position, target))
            {
                this.speed = -0.1f;
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        speed = 1f;
       // Invoke("SpeedReset", 2);
    }
    void SpeedReset()
    {
        speed = 1;
    }
    //上は衝突したときの判定
    //下はトリガーでぶつかった時に使う
    //void OnTriggerExit2D(Collider2D other)
}