using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PreFinishBehaviour preFinishBehaviour;
    [SerializeField] private Animator anim;

    private void Start()
    {
        playerController.enabled = false; // отключаем движение персонажа, когда мы еще не нажали на кнопку Play
        preFinishBehaviour.enabled = false; // выключаем автоматический бег
    }

    public void StartPlay() 
    {
        playerController.enabled = true;
    }

    public void StartPreFinishBehaviour() 
    {
        playerController.enabled = false;

        // включаем автоматический бег,
        // когда столкнулись с триггером префиниша(перед финишом)
        preFinishBehaviour.enabled = true; 
    }

    public void StartFinishBehaviour()
    {
        preFinishBehaviour.enabled = false;
        anim.SetTrigger("isDancing");
    }
}
