using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    // Action ��������Ʈ ����
    public Action OnHitByPlayerAction;
    //public int Score;

    public Action ScoreCheck;

    void Start()
    {
        // OnHitByPlayerAction �̺�Ʈ�� OnHitByPlayer �޼��带 ���
        OnHitByPlayerAction += OnHitByPlayer;        
    }

    // Action ��������Ʈ�� ȣ���ϴ� �޼���
    public void OnHitByPlayer()
    {
        // Target�� �ı� �Ǵ� �ٸ� �۾� ����
        //Destroy(gameObject);
        gameObject.SetActive(false);
        ScoreCheck?.Invoke();
        //Score++;
        //ScoreCheck?.Invoke();
        
    }   

}
