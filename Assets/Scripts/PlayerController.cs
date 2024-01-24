using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float oldMousePositionX;
    private float eulerY; // ���� �������� �� Y

    [SerializeField] Animator anim;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            oldMousePositionX = Input.mousePosition.x;
            anim.SetBool("isRunning", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetMouseButton(0)) 
        {
            Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * speed;
            newPosition.x = Mathf.Clamp(newPosition.x, -1.5f, 1.5f); // �� ��� ������� ��� �������� �� ����� ��������
            transform.position = newPosition; // ����� ������ ��������� ����� �������(��������)

            float deltaX = Input.mousePosition.x - oldMousePositionX; // �� �������� ������� ���� �������� ������ �������
            oldMousePositionX = Input.mousePosition.x; // � ������ ������� ������������ � ��������

            eulerY += deltaX;
            eulerY = Mathf.Clamp(eulerY, -60f, 60f); // �� ��� ������� ��� �������� ����� �������������� ����� � ������
            transform.eulerAngles = new Vector3(0, eulerY, 0);
        }

        
    }
}
