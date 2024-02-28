using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera zoomCamera;

    void Start()
    {
        // �ʱ� ���¿����� Main Camera�� Ȱ��ȭ�ϰ� Zoom Camera�� ��Ȱ��ȭ�մϴ�.
        mainCamera.enabled = true;
        zoomCamera.enabled = false;
    }

    void Update()
    {
        // ���콺 ������ ��ư�� ������
        if (Input.GetMouseButton(1))
        {
            // Main Camera�� ��Ȱ��ȭ�ϰ� Zoom Camera�� Ȱ��ȭ�մϴ�.
            mainCamera.enabled = false;
            zoomCamera.enabled = true;
        }
        else
        {
            // ���콺 ������ ��ư�� ������ ������
            // Main Camera�� Ȱ��ȭ�ϰ� Zoom Camera�� ��Ȱ��ȭ�մϴ�.
            mainCamera.enabled = true;
            zoomCamera.enabled = false;
        }
    }
}

