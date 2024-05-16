﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map;
    GameObject[,] field;
    GameObject instance;

    /// <summary>
    /// 与えられた数字をマップ上で移動させる
    /// </summary>
    /// <param name="number">移動させる数字</param>
    /// <param name="moveFrom">元の位置</param>
    /// <param name="moveTo">移動先の位置</param>
    /// <returns>移動可能な時 true</returns>
    bool MoveNumber(Vector2Int movefrom, Vector2Int moveto)
    {
        if (moveto.y < 0 || moveto.y >= field.GetLength(0))
            return false;

        if (moveto.x < 0 || moveto.x >= field.GetLength(1))
            return false;

        //if (map[moveto] == 2)
        //{
        //    int offset = moveto - movefrom; // 箱の行先を決めるための差分
        //    bool success = movenumber(2, moveto, moveto + offset);

        //    if (!success)
        //    {
        //        return false;
        //    }
        //}   // 行先に箱がある時

        field[movefrom.y, movefrom.x].transform.position =
            new Vector3(moveto.x, -1 * moveto.y, 0);    // シーン上のオブジェクトを動かす
        // field のデータを動かす
        field[moveto.y, moveto.x] = field[movefrom.y, movefrom.x];
        field[movefrom.y, movefrom.x] = null;
        return true;
    }

    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                GameObject obj = field[y, x];

                if (obj != null && obj.tag == "Player")
                {
                    return new Vector2Int(x, y);
                }   // プレイヤーを見つけた
            }
        }

        return new Vector2Int(-1, -1);  // 見つからなかった
    }

    void PrintArray()
    {
        string debugText = "";

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }

            debugText += "\n";
        }

        Debug.Log(debugText);
    }

    void Start()
    {
        map = new int[,]
        {
            { 1, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 }
        };

        PrintArray();

        field = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
        ];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    instance =
                        Instantiate(playerPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                    break;
                }   // プレイヤーを見つけた
                else if (map[y, x] == 2)
                {
                    instance =
                        Instantiate(boxPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                }   // 箱を見つけた
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion + Vector2Int.right);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion + Vector2Int.left);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion - Vector2Int.up);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion - Vector2Int.down);
            PrintArray();

        }
    }
}
