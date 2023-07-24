using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{

    [SerializeField]
    private int blueMonCnt;
    [SerializeField]
    private int redMonCnt;

    public Monster[] monsterList;

    private void Awake()
    {
        ResManager.Instance.Create();
        monsterList = new Monster[blueMonCnt + redMonCnt];
        InitMonster();
    }
    private void InitMonster()
    {
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
