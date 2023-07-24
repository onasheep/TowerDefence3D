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

    ////! ���� ��ġ������ ã�Ƴ��� �Լ�
    private void DetectingEnemy()
    {
        float detectionRangeSquared = detectionRange * detectionRange;
        float mindistance = float.MaxValue;
        int closeIndex = 0;

        // { ���� ����� ���� �ε����� ã�Ƴ�
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
        // } ���� ����� ���� �ε����� ã�Ƴ�

            // { ���� ����� ������ źȯ�� �߻��� 
            if (mindistance <= detectionRangeSquared)
            {
                // TODO : źȯ ���� źȯ �߻� ���⼭ ���� 

                Vector3 dir = 
                    (monsterList[closeIndex].transform.position - transform.position).normalized;

                towerCanon.forward = dir;
                // TEST : �ӽ� źȯ �߻� Ÿ�� ���� 

                Fire(dir);



                Debug.Log(" Enter");
            }
            // } ���� ����� ������ źȯ�� �߻��� 
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

            // TEST : źȯ �´� �� Ȯ�� �� ���� , ���� źȯ Ǯ�� ����� ��� ���� �� ��

            Destroy(bullet, 15f);

        }
    }
    

    // LEGACY : ���� ��ǥ�� ã�� ���� �Ұ��� �ҋ� Ʈ���ŷ� �� ��
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag.Equals("Monster"))
    //    {
    //        Debug.Log("�̰� ����");
    //    }
    //}
}
