using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float sensitivity = 2.0f; // ȸ�� ����

    void Start()
    {
        // ������ �� ��� ȸ�� ���� 0���� �ʱ�ȭ
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void Update()
    {
        // ���콺�� �������� ��������
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ���� ȸ�� (������Ʈ�� Y �� ����)
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        Vector3 currentRotation = transform.localEulerAngles;

        currentRotation.z = 0f; // Z �� ȸ���� ���
        //currentRotation.x = 0f; // X �� ȸ���� ���

        transform.localEulerAngles = currentRotation;
    }

}
