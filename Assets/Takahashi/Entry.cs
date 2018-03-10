using UnityEngine;
using System.Collections;

public class Entry : MonoBehaviour {

    const int MAX_PLAYERS = 4;  //最大のプレイ人数

    int[] controllerLink;       //コントローラーとプレイヤーを紐づける
    int entryPlayers = 0;       //エントリー済み人数

    /// <summary>
    /// 最初に実行される(予定)
    /// </summary>
    void Start()
    {
        //最大人数で初期化しておく
        controllerLink = new int[MAX_PLAYERS];

        //他のあらかじめ実行しておきたい処理
    }

    /// <summary>
    /// エントリー処理
    /// </summary>
    /// <param name="joystickNum">コントローラーの番号</param>
    void _Entry(int joystickNum)
    {

        //最大人数よりも超えて登録しようとした場合は実行しない
        if (entryPlayers >= MAX_PLAYERS) return;
        //すでにエントリー済みのコントローラーだったら実行しない
        //if (controllerLink.Any(item => item == joystickNum)) return;

        //コントローラーとプレイヤー番号を紐づける
        controllerLink[entryPlayers++] = joystickNum;

        //あと必要な処理
    }

    /// <summary>
    /// ゲーム開始前の処理
    /// </summary>
    void Ready()
    {
        //なんかいろいろな処理
    }

    /// <summary>
    /// エントリーボタンが押されたとき
    /// </summary>
    /// <param name="joystickNum">コントローラーの番号</param>
    public void OnPressEntryButton(int joystickNum)
    {
        //エントリーする
        _Entry(joystickNum);
    }

    /// <summary>
    /// スタートボタンが押されたとき
    /// </summary>
    /// <param name="joystickNum">コントローラーの番号</param>
    public void OnPressStartButton(int joystickNum)
    {

        //エントリー人数が0人以下の場合は実行しない
        if (entryPlayers <= 0) return;
        //1Pの入力でなければ実行しない
        if (controllerLink[0] != joystickNum) return;

        //ゲーム開始前の処理
        Ready();
    }
}
