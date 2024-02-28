using System;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // Action 델리게이트 선언
    public Action OnHitByPlayerAction;

    // 스폰 위치에 따른 액션 델리게이트 선언
    public Action goldScoreCheck;

    Rigidbody rigid;
    public float BouncePower = 10.0f;
    public float LeftBouncePower = 2.0f;

    void Start()
    {
        // OnHitByPlayerAction 이벤트에 OnHitByPlayer 메서드를 등록
        OnHitByPlayerAction += OnHitByPlayer;

        rigid = GetComponent<Rigidbody>();

        // SpawnPoisionLeft에서 생성된 경우 왼쪽으로 힘 가하기
        if (transform.position.x < 0)
        {
            rigid.AddForce(Vector3.up * BouncePower, ForceMode.Impulse);
            rigid.AddForce(Vector3.right * 3.0f, ForceMode.Impulse);
        }
        else
        {
            // 그 외의 경우는 오른쪽으로 힘 가하기
            rigid.AddForce(Vector3.up * BouncePower, ForceMode.Impulse);
            rigid.AddForce(-Vector3.right * 3.0f, ForceMode.Impulse);
        }
    }

    // Action 델리게이트를 호출하는 메서드
    public void OnHitByPlayer()
    {
        gameObject.SetActive(false);
        goldScoreCheck?.Invoke();
    }
}
