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

    //스폰 위치 지정
    Vector3 SpawnPoisionRight = new Vector3(12.0f, -2.4f, 0);   //오른쪽 스폰 위치
    Vector3 SpawnPoisionLeft = new Vector3(-12.0f, -2.4f, 0);    //왼쪽 스폰 위치

    private void Start()
    {        
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {                      
            //Instantiate로 직접 생성
            //GameObject goldObject = Instantiate(goldPrefab, SpawnPoisionRight, Quaternion.identity);            

            for(int i = 0; i < 2; i++)
            {
                Vector3 SpawnPosition = (i==0)? SpawnPoisionRight : SpawnPoisionLeft;

                GameObject goldObject = Instantiate(goldPrefab, SpawnPosition, Quaternion.identity);
                goldObject.transform.parent = transform;
                goldObjects.Add(goldObject);
                InitializeGold(goldObject, SpawnPosition);
            }

            //생성된 goldObject를  GoldSpawner의 자식으로 설정
            //goldObject.transform.parent = transform;
            //goldObjects.Add(goldObject);

            //goldObject가 생성될 때마다 goldObject를 찾아서 초기화
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

        // 리스트 비우기
        goldObjects.Clear();
    }


    private void InitializeGold(GameObject goldObject, Vector3 spawnPosition)
    {
        // 생성된 goldObject를 GoldSpawner의 자식으로 설정
        goldObject.transform.parent = transform;

        gold = goldObject.GetComponent<Gold>();
        if (gold != null)
        {
            // goldObject가 생성될 때마다 goldObject를 찾아서 초기화
            gold.goldScoreCheck += Score;

            // SpawnPoisionLeft에서 생성된 경우
            if (spawnPosition == SpawnPoisionLeft)
            {
                gold.LeftBouncePower = 3.0f;
            }
        }
        else
        {
            Debug.LogError("Gold 가 없는데?");
        }
    }
}
