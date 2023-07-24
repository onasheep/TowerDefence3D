using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "MonsterData", order = int.MinValue)]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public float maxHp;
    public float curHp;
    public int moveSpedd;
}
