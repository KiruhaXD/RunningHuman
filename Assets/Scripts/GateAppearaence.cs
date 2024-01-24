using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum LabelForDeformationType 
{
    Width,
    Height
}

public class GateAppearaence : MonoBehaviour
{
    [SerializeField] private TMP_Text incrOrDecrSizePlayer;

    [SerializeField] private Image topImage;
    [SerializeField] private Image downImage;

    [SerializeField] private Color colorPositive;
    [SerializeField] private Color colorNegative;

    // »конки увеличени€ / уменьшени€ ширины
    [SerializeField] private GameObject expendLable;
    [SerializeField] private GameObject shrinkLable;

    // »конки увеличени€ / уменьшени€ высоты
    [SerializeField] private GameObject upLable;
    [SerializeField] private GameObject downLable;    

    // т.к у нас ворота по€вл€ютс€ и остаютс€ в том же положении и не двигаютс€,
    // дл€ лучшей производительности лучше не вызывать это все в методе Update,
    // т.к это вл€ет на производительность и так лучше не делать
    public void UpdateVisual(LabelForDeformationType type, int value) 
    {
        string prefix = "";

        if (value > 0) 
        {
            prefix = "+";
            SetColor(colorPositive); 
        }
            
        else if (value == 0)
            SetColor(Color.grey);

        else
            SetColor(colorNegative);

        incrOrDecrSizePlayer.text = prefix + value.ToString();

        expendLable.SetActive(false);
        shrinkLable.SetActive(false);
        upLable.SetActive(false);
        downLable.SetActive(false);

        if (type == LabelForDeformationType.Width)
        {
            if (value > 0)
            {
                expendLable.SetActive(true);
            }
            else if (value == 0)
            {
                shrinkLable.SetActive(false);
            }
            else
            {
                shrinkLable.SetActive(true);
            }
        }
        else if (type == LabelForDeformationType.Height) 
        {
            if (value > 0)
            {
                upLable.SetActive(true);
            }
            else if(value == 0)
            {
                downLable.SetActive(false);
            }
            else
            {
                downLable.SetActive(true);
            }
        }
    }

    private void SetColor(Color color) 
    {
        topImage.color = color;
        downImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }

    private void Update()
    {
        
    }
}
