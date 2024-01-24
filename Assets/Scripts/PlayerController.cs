using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float oldMousePositionX;
    private float eulerY; // угол поворота по Y

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
            newPosition.x = Mathf.Clamp(newPosition.x, -1.5f, 1.5f); // за эти границы наш персонаж не может заходить
            transform.position = newPosition; // стаим нашему персонажу новую позицию(обноляем)

            float deltaX = Input.mousePosition.x - oldMousePositionX; // из исходной позиции мыши отнимаем старую позицию
            oldMousePositionX = Input.mousePosition.x; // и старую позицию приравниваем к исходной

            eulerY += deltaX;
            eulerY = Mathf.Clamp(eulerY, -60f, 60f); // за эти границы наш персонаж может поварачиваться влево и вправо
            transform.eulerAngles = new Vector3(0, eulerY, 0);
        }

        
    }
}
