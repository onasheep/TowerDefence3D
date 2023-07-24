using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResManager : GSingleton<ResManager>
{

    private const string TILE_PREF_PATH = "Prefabs/Tile";
    private const string OBSTACLE_PREF_PATH = "Prefabs/Obstacle";
    private const string PLATFORM_PREF_PATH = "Prefabs/Platform";
    private const string MONSTER_PREF_PATH = "Prefabs/Monster";
    private const string TURRET_PREF_PATH = "Prefabs/Turret";
    private const string BULLET_PREF_PATH = "Prefabs/Bullet";

    private const string SCRIPTABLE_OBJ_PATH = "ScriptableObj";
    //private const string WaveData_SCRIPTOBJ_PAHT = "ScriptableObj/WaveData";


    public Dictionary<string, GameObject> tilePrefabs = default;
    public Dictionary<string, GameObject> obstaclePrefabs = default;
    public Dictionary<string, GameObject> platformPrefabs = default;
    public Dictionary<string, GameObject> monsterPrefabs = default;
    public Dictionary<string, GameObject> turretTowerPrefabs = default;
    public Dictionary<string, GameObject> bulletPrefabs = default;

    public Dictionary<string, MonsterData> scriptableObjs = default;
    //public Dictionary<string, WaveData> waveDatas = default;

    protected override void Init()
    {
        base.Init();

        // { InitMap Prefabs
        tilePrefabs = new Dictionary<string, GameObject>();
        tilePrefabs.AddObjs(Resources.LoadAll<GameObject>(TILE_PREF_PATH));

        obstaclePrefabs = new Dictionary<string, GameObject>();
        obstaclePrefabs.AddObjs(Resources.LoadAll<GameObject>(OBSTACLE_PREF_PATH));

        platformPrefabs = new Dictionary<string, GameObject>();
        platformPrefabs.AddObjs(Resources.LoadAll<GameObject>(PLATFORM_PREF_PATH));

        monsterPrefabs = new Dictionary<string, GameObject>();
        monsterPrefabs.AddObjs(Resources.LoadAll<GameObject>(MONSTER_PREF_PATH));      

        turretTowerPrefabs = new Dictionary<string, GameObject>();
        turretTowerPrefabs.AddObjs(Resources.LoadAll<GameObject>(TURRET_PREF_PATH));

        bulletPrefabs = new Dictionary<string, GameObject>();
        bulletPrefabs.AddObjs(Resources.LoadAll<GameObject>(BULLET_PREF_PATH));
        // } InitMap Prefabs

        // TODO : 위와 같은 방법으로 가져올수없음 직접 바인딩 해두었지만 수정 가능하면 수정할것
        scriptableObjs = new Dictionary<string, MonsterData>();
        scriptableObjs.AddObjs(Resources.LoadAll<MonsterData>(SCRIPTABLE_OBJ_PATH));
        
        // TODO : 제네릭 공부해서 사용 할 것..
        //waveDatas = new Dictionary<string, WaveData>();
        //waveDatas.AddObjs(Resources.LoadAll<WaveData>(WaveData_SCRIPTOBJ_PAHT));
    }
   
}
