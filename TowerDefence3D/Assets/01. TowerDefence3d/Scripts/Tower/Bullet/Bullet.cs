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
            GFunc.Log("������ ����");

            // Test : �ı� ���� Ǯ ����� ����� �ٸ� ��� ���
            Destroy(this.gameObject);
        }
    }
}
