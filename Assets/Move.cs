using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /// <summary>�ړ������܂łɂ����鎞�ԁi�b�j</summary>
    public float duration = 0.2f;
    /// <summary>�ړ����n�߂Ă���o�߂������ԁi�b�j</summary>
    float elapsedTime;
    Vector3 destination;
    Vector3 origin;

    public void MoveTo(Vector3 destination)
    {
        //transform.position = destination;
        elapsedTime = 0;
        // �ړ����������Ă��Ȃ��ꍇ���l���āA�ړI�n�܂Ń��[�v������
        origin = this.destination;
        transform.position = origin;
        // �V�����ړI�n���Z�b�g����
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
