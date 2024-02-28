using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public float sensitivity = 2.0f; // ȸ�� ����

    public float minYRotation = -30f; // Y �� �ּ� ȸ�� ��
    public float maxYRotation = 30f;  // Y �� �ִ� ȸ�� ��
    public float minXRotation = 0f;   // X �� �ּ� ȸ�� ��
    public float maxXRotation = 0f;   // X �� �ִ� ȸ�� ��

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

        // ���� ȸ�� (������Ʈ�� X �� �� Z �� ����)
        transform.Rotate(Vector3.left * mouseY * sensitivity, Space.Self);

        /*// ���� ȸ���� �����ϱ� ���� ���� ������ ���� ������ ����
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, minXRotation, maxXRotation);
        currentRotation.y = Mathf.Clamp(currentRotation.y, minYRotation, maxYRotation);
        currentRotation.z = 0f; // Z �� ȸ���� ���
        transform.localEulerAngles = currentRotation;*/

        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.z = 0f; // Z �� ȸ���� ���
        currentRotation.x = 0f; // X �� ȸ���� ���
        
        transform.localEulerAngles = currentRotation;
    }
}
