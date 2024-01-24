using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject effectForFinish;

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour playerBehaviour = other.attachedRigidbody.GetComponent<PlayerBehaviour>();

        if (playerBehaviour != null)
        {
            playerBehaviour.StartFinishBehaviour();
            FindObjectOfType<GameManager>().ShowFinishWindow();
            Instantiate(effectForFinish, transform.position, transform.rotation);
        }
    }

    
}
