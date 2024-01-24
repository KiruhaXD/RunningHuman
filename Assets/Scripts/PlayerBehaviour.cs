using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PreFinishBehaviour preFinishBehaviour;
    [SerializeField] private Animator anim;

    private void Start()
    {
        playerController.enabled = false; // ��������� �������� ���������, ����� �� ��� �� ������ �� ������ Play
        preFinishBehaviour.enabled = false; // ��������� �������������� ���
    }

    public void StartPlay() 
    {
        playerController.enabled = true;
    }

    public void StartPreFinishBehaviour() 
    {
        playerController.enabled = false;

        // �������� �������������� ���,
        // ����� ����������� � ��������� ���������(����� �������)
        preFinishBehaviour.enabled = true; 
    }

    public void StartFinishBehaviour()
    {
        preFinishBehaviour.enabled = false;
        anim.SetTrigger("isDancing");
    }
}
