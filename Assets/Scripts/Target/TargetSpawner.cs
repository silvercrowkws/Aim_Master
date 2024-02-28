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
            // Instantiate�� ���� ����
            for (int i = 0; i < 5; i++)
            {
                Vector3 randomPosition = new Vector3(
                    UnityEngine.Random.Range(-28.0f, 28.0f),
                    UnityEngine.Random.Range(-1.0f, 16.0f),
                    19.0f
                );

                GameObject targetObject = Instantiate(targetPrefab, randomPosition, Quaternion.Euler(0.0f, 90.0f, 0.0f));

                // ������ targetObject�� TargetSpawner�� �ڽ����� ����
                targetObject.transform.parent = transform;
                targetObjects.Add(targetObject);

                // Ÿ���� ������ ������ Ÿ���� ã�Ƽ� �ʱ�ȭ
                InitializeTarget(targetObject);
            }
            yield return new WaitForSeconds(SpawnTime);
            DestroyTargets(); //����� ��� ������ target�� ����
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

        // ����Ʈ ����
        targetObjects.Clear();
    }

    void InitializeTarget(GameObject targetObject)
    {
        // ������ targetObject�� TargetSpawner�� �ڽ����� ����
        targetObject.transform.parent = transform;

        // Ÿ���� ������ ������ Ÿ���� ã�Ƽ� �ʱ�ȭ
        target = targetObject.GetComponent<Target>();
        if (target != null)
        {
            target.ScoreCheck += Score;
        }
        else
        {
            Debug.LogError("Target �� ���µ�?");
        }
    }
}
