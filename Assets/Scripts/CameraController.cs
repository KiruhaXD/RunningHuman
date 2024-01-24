using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        transform.parent = null; // ������ ��� ���� ������������ ������(��-���� ������) �� �������������� ������ � �������
    }

    // LateUpdate ���������� ������ ���� ����� ���� ������� Update
    private void LateUpdate() // LateUpdate ��������� ���������� �������� ��������� �� ����� ����
    {
        if (target != null)
        {
            transform.position = target.position;
        }   
    }
}
