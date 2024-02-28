using System;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // Action ��������Ʈ ����
    public Action OnHitByPlayerAction;

    // ���� ��ġ�� ���� �׼� ��������Ʈ ����
    public Action goldScoreCheck;

    Rigidbody rigid;
    public float BouncePower = 10.0f;
    public float LeftBouncePower = 2.0f;

    void Start()
    {
        // OnHitByPlayerAction �̺�Ʈ�� OnHitByPlayer �޼��带 ���
        OnHitByPlayerAction += OnHitByPlayer;

        rigid = GetComponent<Rigidbody>();

        // SpawnPoisionLeft���� ������ ��� �������� �� ���ϱ�
        if (transform.position.x < 0)
        {
            rigid.AddForce(Vector3.up * BouncePower, ForceMode.Impulse);
            rigid.AddForce(Vector3.right * 3.0f, ForceMode.Impulse);
        }
        else
        {
            // �� ���� ���� ���������� �� ���ϱ�
            rigid.AddForce(Vector3.up * BouncePower, ForceMode.Impulse);
            rigid.AddForce(-Vector3.right * 3.0f, ForceMode.Impulse);
        }
    }

    // Action ��������Ʈ�� ȣ���ϴ� �޼���
    public void OnHitByPlayer()
    {
        gameObject.SetActive(false);
        goldScoreCheck?.Invoke();
    }
}
