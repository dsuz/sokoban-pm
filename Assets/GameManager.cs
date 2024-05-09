using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    int[,] map;
    GameObject instance;

    /// <summary>
    /// 与えられた数字をマップ上で移動させる
    /// </summary>
    /// <param name="number">移動させる数字</param>
    /// <param name="moveFrom">元の位置</param>
    /// <param name="moveTo">移動先の位置</param>
    /// <returns>移動可能な時 true</returns>
    //bool MoveNumber(int number, int moveFrom, int moveTo)
    //{
    //    if (moveTo < 0 || moveTo >= map.Length)
    //    {
    //        return false;
    //    }

    //    if (map[moveTo] == 2)
    //    {
    //        int offset = moveTo - moveFrom; // 箱の行先を決めるための差分
    //        bool success = MoveNumber(2, moveTo, moveTo + offset);

    //        if (!success)
    //        {
    //            return false;
    //        }
    //    }   // 行先に箱がある時

    //    map[moveTo] = number;
    //    map[moveFrom] = 0;
    //    return true;
    //}

    //int GetPlayerIndex()
    //{
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        if (map[i] == 1)
    //        {
    //            return i;
    //        }
    //    }

    //    return -1;
    //}

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
            { 0, 0, 0, 0, 1, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 }
        };
        PrintArray();

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    instance =
                        Instantiate(playerPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    break;
                }
            }
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    int playerIndex = GetPlayerIndex();
        //    MoveNumber(1, playerIndex, playerIndex + 1);
        //    PrintArray();
        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    int playerIndex = GetPlayerIndex();
        //    MoveNumber(1, playerIndex, playerIndex - 1);
        //    PrintArray();
        //}
    }
}
