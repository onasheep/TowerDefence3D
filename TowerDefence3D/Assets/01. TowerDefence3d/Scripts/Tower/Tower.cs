using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private const string TOWER_CANON = "TowerCanon";
    private const string TOWER_BERRAL = "Berral";


    private GameObject monsterPool = default;
    private List<GameObject> monsterList = default;

    private Transform towerCanon = default;
    private Transform towerBerral = default;
    
    private float detectionRange = 5f;
    private float setTime = default;
    [SerializeField]
    private float bTime = 0.3f;
    
    private void Awake()
    {
        ResManager.Instance.Create();
        towerCanon = gameObject.FindChildComponent<Transform>(TOWER_CANON);
        towerBerral = gameObject.FindChildComponent<Transform>(TOWER_BERRAL);
    }
    // Start is called before the first frame update
    void Start()
    {
        monsterPool = GFunc.GetRootObj(RDefine.MONSTER_POOL);
        monsterList = monsterPool.GetChildrenObjs();
    }

    // Update is called once per frame
    void Update()
    {
        setTime += Time.deltaTime;
        DetectingEnemy();
    }

    ////! 적을 위치값으로 찾아내는 함수
    private void DetectingEnemy()
    {
        float detectionRangeSquared = detectionRange * detectionRange;
        float mindistance = float.MaxValue;
        int closeIndex = 0;

        // { 가장 가까운 적의 인덱스를 찾아냄
        if (monsterList.Count != 0)
        {
            for (int i = 0; i < monsterList.Count; i++)
            {
                if (mindistance >
                    (monsterList[i].transform.position - transform.position).sqrMagnitude)
                {
                    mindistance = 
                        (monsterList[i].transform.position - transform.position).sqrMagnitude;
                    closeIndex = i;
                }
            }
        // } 가장 가까운 적의 인덱스를 찾아냄

            // { 가장 가까운 적에게 탄환을 발사함 
            if (mindistance <= detectionRangeSquared)
            {
                // TODO : 탄환 만들어서 탄환 발사 여기서 실행 

                Vector3 dir = 
                    (monsterList[closeIndex].transform.position - transform.position).normalized;

                towerCanon.forward = dir;
                // TEST : 임시 탄환 발사 타임 조절 

                Fire(dir);



                Debug.Log(" Enter");
            }
            // } 가장 가까운 적에게 탄환을 발사함 
        }
    }

    private void Fire(Vector3 dir)
    {

        if (setTime > bTime)
        {
            setTime = 0f;
            GameObject bullet =
                Instantiate(ResManager.Instance.bulletPrefabs[RDefine.BASIC_BULLET],
                towerBerral.position, towerBerral.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(dir * 1000f * Time.deltaTime, ForceMode.VelocityChange);

            // TEST : 탄환 맞는 거 확인 후 삭제 , 추후 탄환 풀을 만들면 방식 변경 할 것

            Destroy(bullet, 15f);

        }
    }
    

    // LEGACY : 위의 좌표로 찾는 것이 불가능 할떄 트리거로 할 것
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag.Equals("Monster"))
    //    {
    //        Debug.Log("이거 들어옴");
    //    }
    //}
}
