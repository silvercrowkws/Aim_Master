using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera zoomCamera;

    void Start()
    {
        // 초기 상태에서는 Main Camera를 활성화하고 Zoom Camera를 비활성화합니다.
        mainCamera.enabled = true;
        zoomCamera.enabled = false;
    }

    void Update()
    {
        // 마우스 오른쪽 버튼을 누르면
        if (Input.GetMouseButton(1))
        {
            // Main Camera를 비활성화하고 Zoom Camera를 활성화합니다.
            mainCamera.enabled = false;
            zoomCamera.enabled = true;
        }
        else
        {
            // 마우스 오른쪽 버튼을 누르지 않으면
            // Main Camera를 활성화하고 Zoom Camera를 비활성화합니다.
            mainCamera.enabled = true;
            zoomCamera.enabled = false;
        }
    }
}

