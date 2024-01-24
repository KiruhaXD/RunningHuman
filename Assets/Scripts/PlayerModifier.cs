using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;

    float widthMultiplier = 0.0005f;
    float heightMultiplier = 0.01f;

    [SerializeField] private Renderer rendererMaterial;

    [SerializeField] private Transform topBaseHumanSpine2;
    [SerializeField] private Transform downBaseHumanSpine3;

    [SerializeField] private Transform capsuleCollider;

    [Header("Shop")]
    [SerializeField] private Shop shop;

    [Header("Sounds")]
    [SerializeField] private AudioSource pumpSound;

    private void Start()
    {
        SetWidth(Progress.Instance.width);
        SetHeight(Progress.Instance.height);
    }

    private void Update()
    {
        // 0.17f это сантиметры между двумя костями, верхней спиной и нижней,
        // мы ее прибаляем для того чтоб наш персонаж не становился карликом
        float offsetY = height * heightMultiplier + 0.17f; 
        topBaseHumanSpine2.position = downBaseHumanSpine3.position + new Vector3(0, offsetY, 0);

        // 1.84f - это рост нашего персонажа
        capsuleCollider.localScale = new Vector3(1, 1.84f + height * heightMultiplier, 1);
    }

    public void AddWidth(int value) 
    {
        width += value;
        UpdateWidth();

        if (value > 0) 
        {
            pumpSound.Play();
        }
    }
    public void AddHeight(int value) 
    {
        height += value;
        if (value > 0)
        {
            pumpSound.Play();
        }
    }

    public void SetWidth(int value) 
    {
        width = value;
        UpdateWidth();
    }
    public void SetHeight(int value) 
    {
        height = value;
    }

    public void HitBarrier() 
    {
        if (height > 0)
        {
            height -= 50;
        }

        else if (width > 0)
        {
            width -= 50;
            UpdateWidth();
        }

        else 
        {
            Die();
        }
    }

    public void UpdateWidth() 
    {
        rendererMaterial.material.SetFloat("_PushValue", width * widthMultiplier); // имена у шейдеров начинаются с черточки 
    }

    public void Die() 
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().LoseWindow();
    }
}
