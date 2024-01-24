using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private LabelForDeformationType type;

    [SerializeField] private GateAppearaence gateAppearaence;

    private void OnValidate() 
    {
        gateAppearaence.UpdateVisual(type, value);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ����� �� ���� ������ � ����������� RigidBody � ������ Player �� ������� ����� ������ PlayerModifier 
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if (playerModifier != null) 
        {
            if (type == LabelForDeformationType.Width)
            {
                playerModifier.AddWidth(value);
            }

            else if (type == LabelForDeformationType.Height) 
            {
                playerModifier.AddHeight(value);
            }

            Destroy(gameObject);
        }

    }
}
