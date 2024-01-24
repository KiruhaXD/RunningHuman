using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        transform.parent = null; // делаем так чтоб родительский объект(то-есть камера) не поворачивалась вместе с игроком
    }

    // LateUpdate вызываетс€ каждый кадр после всех методов Update
    private void LateUpdate() // LateUpdate позвол€ет прекратить дергание персонажа во врем€ игры
    {
        if (target != null)
        {
            transform.position = target.position;
        }   
    }
}
