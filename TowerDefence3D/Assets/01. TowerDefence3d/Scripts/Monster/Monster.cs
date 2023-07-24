using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{   
    public string monsterName;
    public float maxHp;
    public float curHp;
    public int moveSpedd;

    public void InitMonster(MonsterData monsterData_)
    {
        monsterName = monsterData_.monsterName;
        maxHp = monsterData_.maxHp;
        curHp = monsterData_.curHp;
        moveSpedd = monsterData_.moveSpedd;
    }




}
