using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{   
    public string monsterName;
    public float maxHp;
    public float curHp;
    public float moveSpeed;

    private NavMeshAgent navmeshAgent = default;
    private GameObject target = default;
    private bool isArrive = default;
    public void InitMonster(MonsterData monsterData_)
    {
        monsterName = monsterData_.monsterName;
        maxHp = monsterData_.maxHp;
        curHp = monsterData_.curHp;
        moveSpeed = monsterData_.moveSpedd;

        navmeshAgent = GetComponent<NavMeshAgent>();
        navmeshAgent.speed = moveSpeed;
        isArrive = false;
        target = GameManager.Instance.mapBoard.tileList[0];
    }




    private void Start()
    {
        StartCoroutine(MoveMonster());
    }

    private IEnumerator MoveMonster()
    {
        isArrive = (target.transform.position - this.transform.position).Equals(Vector3.zero);
        while(!isArrive)
        {
            GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
            yield return null;
        }
    }


}
