/*using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 오브젝트 풀을 사용하는 오브젝트의 종류
/// </summary>
public enum PoolObjectType
{
    Target = 0,   // 과녁
    
}

public class Factory : Singleton<Factory>
{
    // 오브젝트 풀들    
    TargetCirclePool target;

    /// <summary>
    /// 씬이 로딩 완료될 때마다 실행되는 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();

        // GetComponentInChildren : 나와 내 자식 오브젝트에서 컴포넌트 찾음

        // 풀 컴포넌트 찾고, 찾으면 초기화하기
        target = GetComponentInChildren<TargetCirclePool>();
        if (target != null)
            target.Initialize();
        
    }

    /// <summary>
    /// 풀에 있는 게임 오브젝트 하나 가져오기
    /// </summary>
    /// <param name="type">가져올 오브젝트의 종류</param>
    /// <param name="position">오브젝트가 배치될 위치</param>
    /// <param name="angle">오브젝트의 초기 각도</param>
    /// <returns>활성화된 오브젝트</returns>
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
    /// 과녁 하나 가져오는 함수
    /// </summary>
    /// <returns></returns>
    public TargetCircle GetTargetCircle()
    {
        return target.GetObject();
    }

    /// <summary>
    /// 과녁 하나 가져와서 특정 위치에 배치하는 함수
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