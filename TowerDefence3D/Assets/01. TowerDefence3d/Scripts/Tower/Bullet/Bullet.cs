using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Monster"))
        {
            GFunc.Log("적에게 닿음");

            // Test : 파괴 추후 풀 만들면 지우고 다른 방식 사용
            Destroy(this.gameObject);
        }
    }
}
