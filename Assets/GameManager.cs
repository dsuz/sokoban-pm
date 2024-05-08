using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int[] map;

    void Start()
    {
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        string debugText = "";

        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ","; 
        }

        Debug.Log(debugText);
    }

    void Update()
    {
        bool debugOut = false;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = -1;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }

            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }

            debugOut = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = -1;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }

            if (playerIndex > 0)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
            }

            debugOut = true;
        }

        if (debugOut)
        { 
            string debugText = "";

            for (int i = 0; i < map.Length; i++)
            {
                debugText += map[i].ToString() + ",";
            }

            Debug.Log(debugText);
        }
    }
}
