using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /// <summary>移動完了までにかかる時間（秒）</summary>
    public float duration = 0.2f;
    /// <summary>移動を始めてから経過した時間（秒）</summary>
    float elapsedTime;
    Vector3 destination;
    Vector3 origin;

    public void MoveTo(Vector3 destination)
    {
        //transform.position = destination;
        elapsedTime = 0;
        // 移動が完了していない場合を考えて、目的地までワープさせる
        origin = this.destination;
        transform.position = origin;
        // 新しい目的地をセットする
        this.destination = destination;
    }

    void Start()
    {
        destination = transform.position;
        origin = destination;
    }

    void Update()
    {
        if (origin == destination)
            return;

        elapsedTime += Time.deltaTime;
        float timeRate = elapsedTime / duration;

        if (timeRate > 1)
            timeRate = 1;

        Vector3 currentPotision = Vector3.Lerp(origin, destination, timeRate);
        transform.position = currentPotision;
    }
}
