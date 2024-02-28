/*using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ������Ʈ Ǯ�� ����ϴ� ������Ʈ�� ����
/// </summary>
public enum PoolObjectType
{
    Target = 0,   // ����
    
}

public class Factory : Singleton<Factory>
{
    // ������Ʈ Ǯ��    
    TargetCirclePool target;

    /// <summary>
    /// ���� �ε� �Ϸ�� ������ ����Ǵ� �ʱ�ȭ �Լ�
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();

        // GetComponentInChildren : ���� �� �ڽ� ������Ʈ���� ������Ʈ ã��

        // Ǯ ������Ʈ ã��, ã���� �ʱ�ȭ�ϱ�
        target = GetComponentInChildren<TargetCirclePool>();
        if (target != null)
            target.Initialize();
        
    }

    /// <summary>
    /// Ǯ�� �ִ� ���� ������Ʈ �ϳ� ��������
    /// </summary>
    /// <param name="type">������ ������Ʈ�� ����</param>
    /// <param name="position">������Ʈ�� ��ġ�� ��ġ</param>
    /// <param name="angle">������Ʈ�� �ʱ� ����</param>
    /// <returns>Ȱ��ȭ�� ������Ʈ</returns>
    public GameObject GetObject(PoolObjectType type, Vector3? position = null, Vector3? euler = null)
    {
        GameObject result = null;
        switch (type)
        {            
            case PoolObjectType.Target:
                result = target.GetObject(position, euler).gameObject;
                break;
        }

        return result;
    }  
    
    /// <summary>
    /// ���� �ϳ� �������� �Լ�
    /// </summary>
    /// <returns></returns>
    public TargetCircle GetTargetCircle()
    {
        return target.GetObject();
    }

    /// <summary>
    /// ���� �ϳ� �����ͼ� Ư�� ��ġ�� ��ġ�ϴ� �Լ�
    /// </summary>
    /// <param name="position"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public TargetCircle GetTargetCircle(Vector3 position, float angle = 0.0f)
    {
        return target.GetObject(position, angle * Vector3.forward);
    }

}
*/