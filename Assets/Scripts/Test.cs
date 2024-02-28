using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public float sensitivity = 2.0f; // 회전 감도

    public float minYRotation = -30f; // Y 축 최소 회전 값
    public float maxYRotation = 30f;  // Y 축 최대 회전 값
    public float minXRotation = 0f;   // X 축 최소 회전 값
    public float maxXRotation = 0f;   // X 축 최대 회전 값

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

        // 수직 회전 (오브젝트의 X 축 및 Z 축 기준)
        transform.Rotate(Vector3.left * mouseY * sensitivity, Space.Self);

        /*// 수직 회전을 제한하기 위해 현재 각도를 제한 범위로 조절
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, minXRotation, maxXRotation);
        currentRotation.y = Mathf.Clamp(currentRotation.y, minYRotation, maxYRotation);
        currentRotation.z = 0f; // Z 축 회전을 잠금
        transform.localEulerAngles = currentRotation;*/

        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.z = 0f; // Z 축 회전을 잠금
        currentRotation.x = 0f; // X 축 회전을 잠금
        
        transform.localEulerAngles = currentRotation;
    }
}
