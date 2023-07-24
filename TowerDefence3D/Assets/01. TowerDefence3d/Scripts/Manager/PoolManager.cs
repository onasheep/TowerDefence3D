using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : GSingleton<PoolManager>
{
    private GameObject monsterPool;
    public Monster[] monsterList;


    private int blueMonCnt = 10;
    private int redMonCnt = 10;




    protected override void Init()
    {
        base.Init();
        ResManager.Instance.Create();
        monsterPool = GFunc.GetRootObj("MonsterPool");


    }

    private void InitMonster()
    {
        monsterList = new Monster[blueMonCnt + redMonCnt];



        for (int i = 0; i < blueMonCnt; i++)
        {
            Monster blueMon = (
                Instantiate(ResManager.Instance.monsterPrefabs[RDefine.BLUEMON_PREF], this.transform)
                ).GetComponent<Monster>();
            blueMon.InitMonster(ResManager.Instance.scriptableObjs[RDefine.BLUEMON_SCRIPTOBJ]);
            blueMon.gameObject.SetActive(false);
            monsterList[i] = (blueMon.GetComponent<Monster>());
        }

        for (int i = 0; i < redMonCnt; i++)
        {
            Monster redMon = (
                Instantiate(ResManager.Instance.monsterPrefabs[RDefine.REDMON_PREF], this.transform)
                ).GetComponent<Monster>();
            redMon.InitMonster(ResManager.Instance.scriptableObjs[RDefine.REDMON_SCRIPTOBJ]);
            redMon.gameObject.SetActive(false);
            monsterList[blueMonCnt + i] = (redMon.GetComponent<Monster>());
        }
    }
}
