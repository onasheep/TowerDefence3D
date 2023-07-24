using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterPool;
    [SerializeField]
    private List<GameObject> spawnMonsterList;
    private int blueMonCnt = 2;
    private int redMonCnt = 5;

    private void Awake()
    {
        monsterPool = GFunc.GetRootObj(RDefine.MONSTER_POOL);
        ////LEGACY: GameMager를 통해서 WaveData를 받아서 작업하려는데 null 이 나옴 일단 WaveDat 사용 보류
    //    GFunc.LogWarning(string.Format("wavdDataList is null ? = {0}, waveIdx is ? = {1}", GameManager.Instance.
    //        waveDataList[0] == null, GameManager.Instance.waveIdx));
    //    curWaveData = GameManager.Instance.
    //        waveDataList[GameManager.Instance.waveIdx];


    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < blueMonCnt; i++)
        {
            spawnMonsterList.Add
                (monsterPool.FindChildObj("BlueMon(Clone)"));
            spawnMonsterList[i].gameObject.SetActive(true);
            spawnMonsterList[i].transform.SetParent(this.transform);
            spawnMonsterList[i].transform.position =
                this.transform.position;
            spawnMonsterList[i].tag = "Monster";
        }

        for (int i = blueMonCnt; i < blueMonCnt + redMonCnt; i++)
        {
            spawnMonsterList.Add
                (monsterPool.FindChildObj("RedMon(Clone)"));
            spawnMonsterList[i].gameObject.SetActive(true);
            spawnMonsterList[i].transform.SetParent(this.transform);
            spawnMonsterList[i].transform.position =
                this.transform.position;
            spawnMonsterList[i].tag = "Monster";
        }


    }

    // Update is called once per frame
    void Update()
    {
     


    }
}
