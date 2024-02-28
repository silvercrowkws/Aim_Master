using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//where T : RecycleObject  // T Ÿ���� RecycleObject�̰ų� RecycleObject�� ��ӹ��� Ŭ������ �����ϴ�.
public class ObjectPool<T> : MonoBehaviour where T : RecycleObject
{
    /// <summary>
    /// Ǯ���� ������ ������Ʈ�� ������
    /// </summary>
    public GameObject originalPrefab;

    /// <summary>
    /// Ǯ�� ũ��. ó���� �����ϴ� ������Ʈ�� ����. ��� ������ 2^n�� ��� ���� ����.
    /// </summary>
    public int poolSize = 64;

    /// <summary>
    /// TŸ������ ������ ������Ʈ�� �迭. ������ ��� ������Ʈ�� �ִ� �迭.
    /// </summary>
    T[] pool;

    /// <summary>
    /// ���� ��밡����(��Ȱ��ȭ�Ǿ��ִ�) ������Ʈ���� �����ϴ� ť
    /// </summary>
    Queue<T> readyQueue;

    public void Initialize()
    {
        if (pool == null)  // Ǯ�� ���� ��������� ���� ���
        {
            pool = new T[poolSize];                 // �迭�� ũ�⸸ŭ new
            readyQueue = new Queue<T>(poolSize);    // ����ť�� ����� capacity�� poolSize�� ����

            GenerateObjects(0, poolSize, pool);
        }
        else
        {
            // Ǯ�� �̹� ������� �ִ� ���(ex:���� �߰��� �ε� or ���� �ٽ� ����)
            foreach (T obj in pool)    // foreach : Ư�� �÷��� �ȿ� �ִ� ��� ��Ҹ� �ѹ��� ó���ؾ� �� ���� ���� �� ���
            {
                obj.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Ǯ���� ������� �ʴ� ������Ʈ�� �ϳ� ���� �� ���� �ϴ� �Լ�
    /// </summary>
    /// <param name="position">��ġ�� ��ġ(������ǥ)</param>
    /// <param name="eulerAngle">��ġ�� ���� ����</param>
    /// <returns>Ǯ���� ���� ������Ʈ(Ȱ��ȭ��)</returns>
    public T GetObject(Vector3? position = null, Vector3? eulerAngle = null)
    {
        if (readyQueue.Count > 0)          // ����ť�� ������Ʈ�� �����ִ��� Ȯ��
        {
            T comp = readyQueue.Dequeue();  // ���������� �ϳ� ������
            comp.gameObject.SetActive(true);// Ȱ��ȭ ��Ű��
            comp.transform.position = position.GetValueOrDefault(); // ������ ��ġ�� �̵�
            comp.transform.Rotate(eulerAngle.GetValueOrDefault());  // ������ ������ ȸ��
            OnGetObject(comp);              // ������Ʈ�� �߰� ó��
            return comp;                    // ����
        }
        else
        {
            // ����ť�� ����ִ� == �����ִ� ������Ʈ�� ����
            ExpandPool();           // Ǯ�� �ι�� Ȯ���Ѵ�.
            return GetObject(position, eulerAngle);     // ���� �ϳ� ������.
        }
    }

    /// <summary>
    /// �� ������Ʈ ���� Ư���� ó���ؾ� �� ���� ���� ��� �����ϴ� �Լ�
    /// </summary>
    protected virtual void OnGetObject(T component)
    {

    }

    /// <summary>
    /// Ǯ�� �ι�� Ȯ���Ű�� �Լ�
    /// </summary>
    void ExpandPool()
    {
        // �ִ��� �Ͼ�� �ȵǴ� ���̴ϱ� ��� ǥ��
        Debug.LogWarning($"{gameObject.name} Ǯ ������ ����. {poolSize} -> {poolSize * 2}");

        int newSize = poolSize * 2;         // ���ο� Ǯ�� ũ�� ����
        T[] newPool = new T[newSize];       // ���ο� Ǯ ����
        for (int i = 0; i < poolSize; i++)     // ���� Ǯ�� �ִ� ������ �� Ǯ�� ����
        {
            newPool[i] = pool[i];
        }

        GenerateObjects(poolSize, newSize, newPool);    // �� Ǯ�� ���� �κп� ������Ʈ �����ؼ� �߰�

        pool = newPool;         // �� Ǯ ������ ����
        poolSize = newSize;     // �� Ǯ�� Ǯ�� ����
    }


    /// <summary>
    /// Ǯ���� ����� ������Ʈ�� �����ϴ� �Լ�
    /// </summary>
    /// <param name="start">���� ���� ������ �ε���</param>
    /// <param name="end">���� ������ ������ �ε���+1</param>
    /// <param name="results">������ ������Ʈ�� �� �迭</param>
    void GenerateObjects(int start, int end, T[] results)
    {
        for (int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(originalPrefab, transform);    // ������ �����ؼ�
            obj.name = $"{originalPrefab.name}_{i}";    // �̸��ٲٰ�

            T comp = obj.GetComponent<T>();
            comp.onDisable += () => readyQueue.Enqueue(comp);   // ��Ȱ�� ������Ʈ�� ��Ȱ��ȭ �Ǹ� ����ť�� �ǵ�����
            //readyQueue.Enqueue(comp);       // ����ť�� �߰��ϰ�(���� ��������Ʈ ����� �� ������ �Ʒ����� ��Ȱ��ȭ�ϸ� �ڵ����� ó��)

            results[i] = comp;      // �迭�� �����ϰ�
            obj.SetActive(false);   // ��Ȱ��ȭ ��Ų��.
        }
    }
}
