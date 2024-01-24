using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject bricksEffectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if(playerModifier != null) 
        {
            playerModifier.HitBarrier();
            Destroy(gameObject);
            Instantiate(bricksEffectPrefab, transform.position, transform.rotation);
        }
    }
}
