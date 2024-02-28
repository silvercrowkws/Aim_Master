using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float sensitivity = 2.0f; // 회전 감도

    void Start()
    {
        // 시작할 때 모든 회전 값을 0으로 초기화
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void Update()
    {
        // 마우스의 움직임을 가져오기
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 수평 회전 (오브젝트의 Y 축 기준)
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        Vector3 currentRotation = transform.localEulerAngles;

        currentRotation.z = 0f; // Z 축 회전을 잠금
        //currentRotation.x = 0f; // X 축 회전을 잠금

        transform.localEulerAngles = currentRotation;
    }

}
