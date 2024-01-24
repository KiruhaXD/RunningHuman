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
        // здесь мы ищем объект с компонентом RigidBody и объект Player на котором висит скрипт PlayerModifier 
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
