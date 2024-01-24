using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360;
    [SerializeField] private GameObject coinsEffectPrefab;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    // триггеры срабатывают только тогда, когда у объекта(монеты) с
    // которым он должен столкнуться должен быть компонент RigidBody(то-есть на игроке)
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddOne();
        Destroy(gameObject);
        Instantiate(coinsEffectPrefab, transform.position, transform.rotation);
    }
}
