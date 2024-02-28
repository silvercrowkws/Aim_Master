using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GoldSpawner : MonoBehaviour
{
    public GameObject goldPrefab;
    List<GameObject> goldObjects = new List<GameObject>();
    public int goldscore = 0;
    public Action<int> GoldScoreUpdated;
    public float SpawnTime = 7.0f;
    Gold gold;

    //���� ��ġ ����
    Vector3 SpawnPoisionRight = new Vector3(12.0f, -2.4f, 0);   //������ ���� ��ġ
    Vector3 SpawnPoisionLeft = new Vector3(-12.0f, -2.4f, 0);    //���� ���� ��ġ

    private void Start()
    {        
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {                      
            //Instantiate�� ���� ����
            //GameObject goldObject = Instantiate(goldPrefab, SpawnPoisionRight, Quaternion.identity);            

            for(int i = 0; i < 2; i++)
            {
                Vector3 SpawnPosition = (i==0)? SpawnPoisionRight : SpawnPoisionLeft;

                GameObject goldObject = Instantiate(goldPrefab, SpawnPosition, Quaternion.identity);
                goldObject.transform.parent = transform;
                goldObjects.Add(goldObject);
                InitializeGold(goldObject, SpawnPosition);
            }

            //������ goldObject��  GoldSpawner�� �ڽ����� ����
            //goldObject.transform.parent = transform;
            //goldObjects.Add(goldObject);

            //goldObject�� ������ ������ goldObject�� ã�Ƽ� �ʱ�ȭ
            //InitializeGold(goldObject);

            yield return new WaitForSeconds(SpawnTime);
            DestroyGold();
        }
        
    }

    public void Score()
    {
        goldscore = goldscore + 5;
        Debug.Log($"{goldscore}");
        GoldScoreUpdated?.Invoke(goldscore);
    }

    private void DestroyGold()
    {
        foreach (GameObject goldObject in goldObjects)
        {
            Destroy(goldObject);
        }

        // ����Ʈ ����
        goldObjects.Clear();
    }


    private void InitializeGold(GameObject goldObject, Vector3 spawnPosition)
    {
        // ������ goldObject�� GoldSpawner�� �ڽ����� ����
        goldObject.transform.parent = transform;

        gold = goldObject.GetComponent<Gold>();
        if (gold != null)
        {
            // goldObject�� ������ ������ goldObject�� ã�Ƽ� �ʱ�ȭ
            gold.goldScoreCheck += Score;

            // SpawnPoisionLeft���� ������ ���
            if (spawnPosition == SpawnPoisionLeft)
            {
                gold.LeftBouncePower = 3.0f;
            }
        }
        else
        {
            Debug.LogError("Gold �� ���µ�?");
        }
    }
}
