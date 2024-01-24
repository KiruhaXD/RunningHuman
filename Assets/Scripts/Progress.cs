using UnityEngine;

public class Progress : MonoBehaviour
{
    public int coins;
    public int width;
    public int height;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;

            // этот метод позволяет не уничтожать объект между сценами
            DontDestroyOnLoad(gameObject);

            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
