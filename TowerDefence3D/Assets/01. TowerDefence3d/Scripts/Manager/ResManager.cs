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
    public Dictionary<string, GameObject> turretPrefabs = default;
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

        turretPrefabs = new Dictionary<string, GameObject>();
        turretPrefabs.AddObjs(Resources.LoadAll<GameObject>(TURRET_PREF_PATH));

        bulletPrefabs = new Dictionary<string, GameObject>();
        bulletPrefabs.AddObjs(Resources.LoadAll<GameObject>(BULLET_PREF_PATH));
        // } InitMap Prefabs

        // TODO : ���� ���� ������� �����ü����� ���� ���ε� �صξ����� ���� �����ϸ� �����Ұ�
        scriptableObjs = new Dictionary<string, MonsterData>();
        scriptableObjs.AddObjs(Resources.LoadAll<MonsterData>(SCRIPTABLE_OBJ_PATH));
        
        // TODO : ���׸� �����ؼ� ��� �� ��..
        //waveDatas = new Dictionary<string, WaveData>();
        //waveDatas.AddObjs(Resources.LoadAll<WaveData>(WaveData_SCRIPTOBJ_PAHT));
    }
   
}
