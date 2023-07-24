using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MapBoard : MonoBehaviour
{
    private const string TILE_MAP_OBJ_NAME = "TileMap";


    private Transform tileMap;
    public List<GameObject> tileList;
    [SerializeField]
    public int TileSizeX = 20;
    [SerializeField]
    public int TileSizeY = 20;

    //  Test : RunTime NavBake
    private NavMeshSurface surfaces;



    

    // ���ϴ� Ÿ�� ���� ����
    private Vector3 tileZeroPos = new Vector3(-9.5f, 0f, -9.5f);

    [SerializeField]
    private int obstacleCnt;

    private void Awake()
    {


        // { �Ŵ��� ��ũ��Ʈ �ʱ�ȭ 
        ResManager.Instance.Create();
        // } �Ŵ��� ��ũ��Ʈ �ʱ�ȭ        

        tileMap = this.gameObject.FindChildComponent<Transform>(TILE_MAP_OBJ_NAME);
        tileList = new List<GameObject>();

        InitMap();

        tileMap.AddComponent<NavMeshSurface>();
        surfaces = tileMap.GetComponent<NavMeshSurface>();
        surfaces.BuildNavMesh();
        //surfaces.


    }

    private void InitMap()
    {
        // { InitMap TileMap
        for (int z = 0; z < TileSizeY; z++)
        {
            for (int x = 0; x < TileSizeX; x++)
            {
                Vector3 tileSetPos = tileZeroPos + new Vector3(x, 0f, z);
                GameObject tile = Instantiate(ResManager.Instance.tilePrefabs[RDefine.TILE_PREF_GRASS], tileSetPos, Quaternion.identity, tileMap);
                tileList.Add(tile);
            }
        }
        // } InitMap TileMap

        // { Set Obstacle
        int loopCnt = obstacleCnt;
        while (loopCnt > 0)
        {
            // �������� 0�� Ÿ�ϰ� ������ ������ Ÿ�� �����ϰ� ��ֹ� ��ġ
            int randIndx = Random.Range(20, (TileSizeX * TileSizeY) - 20);
            Tile tile = tileList[randIndx].GetComponent<Tile>();
            if (tile.isObstacle == true || tile.IsPassable == false) { continue; }
            tile.isObstacle = true;
            tile.IsPassable = false;
            Instantiate(ResManager.Instance.obstaclePrefabs[RDefine.TILE_PREF_TRAP], tileList[randIndx].transform);
            loopCnt--;
        }
        // } Set Obstacle

        // { Set Start Dest         
        Instantiate(ResManager.Instance.platformPrefabs[RDefine.TILE_PREF_START_PLATFORM], tileList[0].transform);
        Instantiate(ResManager.Instance.platformPrefabs[RDefine.TILE_PREF_DEST_PLATFORM], tileList[tileList.Count - 1].transform);
        // } Set Start Dest       

    }       // InitMap()

}
