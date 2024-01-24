using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360;
    [SerializeField] private GameObject coinsEffectPrefab;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    // �������� ����������� ������ �����, ����� � �������(������) �
    // ������� �� ������ ����������� ������ ���� ��������� RigidBody(��-���� �� ������)
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddOne();
        Destroy(gameObject);
        Instantiate(coinsEffectPrefab, transform.position, transform.rotation);
    }
}
