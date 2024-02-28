using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    List<GameObject> targetObjects = new List<GameObject>();
    Target target;
    public int score = 0;
    public Action<int> ScoreUpdated;
    public float SpawnTime = 5.0f;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            // Instantiate로 직접 생성
            for (int i = 0; i < 5; i++)
            {
                Vector3 randomPosition = new Vector3(
                    UnityEngine.Random.Range(-28.0f, 28.0f),
                    UnityEngine.Random.Range(-1.0f, 16.0f),
                    19.0f
                );

                GameObject targetObject = Instantiate(targetPrefab, randomPosition, Quaternion.Euler(0.0f, 90.0f, 0.0f));

                // 생성된 targetObject를 TargetSpawner의 자식으로 설정
                targetObject.transform.parent = transform;
                targetObjects.Add(targetObject);

                // 타겟이 생성될 때마다 타겟을 찾아서 초기화
                InitializeTarget(targetObject);
            }
            yield return new WaitForSeconds(SpawnTime);
            DestroyTargets(); //여기다 방금 생성된 target을 삭제
        }
    }

    public void Score()
    {
        score++;
        Debug.Log($"{score}");
        ScoreUpdated?.Invoke(score);
    }

    void DestroyTargets()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            Destroy(targetObject);
        }

        // 리스트 비우기
        targetObjects.Clear();
    }

    void InitializeTarget(GameObject targetObject)
    {
        // 생성된 targetObject를 TargetSpawner의 자식으로 설정
        targetObject.transform.parent = transform;

        // 타겟이 생성될 때마다 타겟을 찾아서 초기화
        target = targetObject.GetComponent<Target>();
        if (target != null)
        {
            target.ScoreCheck += Score;
        }
        else
        {
            Debug.LogError("Target 이 없는데?");
        }
    }
}
