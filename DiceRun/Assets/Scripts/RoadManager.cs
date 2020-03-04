using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    private float Speed;
    private float EndPointZ;
    private float StartPointZ;
    private GameObject DiceHitterObject;

    void Start()
    {
        DiceHitterObject = GameObject.Find("DiceHitter");
        EndPointZ = (GameObject.Find("EndPointObject").transform.position.z);
        StartPointZ = this.transform.position.z;
        Speed = 1f;
    }

    void Update()
    {
        Speed += Time.deltaTime * 0.5f;

        // z좌표 조금씩 이동
        transform.Translate(0, 0, -1 * Speed * Time.deltaTime);

        // 목표 지점에 도달했다면
        if (transform.position.z <= EndPointZ)
        {
            DiceHitterObject.SetActive(false);
            // 스타트 지점으로 이동
            transform.Translate(0, 0, -1 * (EndPointZ - StartPointZ));

            //DiceHitter Number 변경
            DiceHitterObject.GetComponent<DiceHitterController>().ChangeNumber();

            DiceHitterObject.SetActive(true);
        }
    }
}
