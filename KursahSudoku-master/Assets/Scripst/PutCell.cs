using UnityEngine;

public class PutCell : MonoBehaviour
{
    //public static PutCell CurrentValue { private set; get; }
    public int Value { private set; get; }
    [SerializeField] private TextMesh _valueText;
    [SerializeField] private Color _valueZero;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMesh _countText;
    private fillingUser _filling;
    private int _count;

    public virtual void Inicialize(int value, int count)
    {
        _filling = fillingUser.Global;
        _filling.Value = value;
        _count = count;
        LogValue();
    }

    public void Decrease()
    {
        _count--;
        if(_count == 0)
        {
            gameObject.SetActive(false);
        }
        _countText.text = _count.ToString();
    }
    public void OnMouseDown()
    {
        if (_filling.GameActive)
        {
            Value = Value;
            _filling.PutValue();
        }

    }
    private void LogValue()
    {
        _countText.text = _count.ToString();
        _valueText.text = Value.ToString();
    }
}
