using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    // Action 델리게이트 선언
    public Action OnHitByPlayerAction;
    //public int Score;

    public Action ScoreCheck;

    void Start()
    {
        // OnHitByPlayerAction 이벤트에 OnHitByPlayer 메서드를 등록
        OnHitByPlayerAction += OnHitByPlayer;        
    }

    // Action 델리게이트를 호출하는 메서드
    public void OnHitByPlayer()
    {
        // Target을 파괴 또는 다른 작업 수행
        //Destroy(gameObject);
        gameObject.SetActive(false);
        ScoreCheck?.Invoke();
        //Score++;
        //ScoreCheck?.Invoke();
        
    }   

}
