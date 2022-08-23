using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private SlotAnimator _animator;
    [SerializeField] private List<Sprite> _spriteList;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Fruits _slotType;

    public Fruits SlotType => _slotType;
    public GameObject Parent => _parent;



    public enum Fruits
    {
        Banana,
        Cherry,
        Grape
    }

    private void OnEnable()
    {
        int value = Random.Range(0, _spriteList.Count);
        _spriteRenderer.sprite = _spriteList[value];
        _slotType = (Fruits)System.Enum.GetValues(typeof(Fruits)).GetValue(value);
        _animator.OnAnimEndedEvent += OnAnimEnded;
    }

    private void OnDisable()
    {
        _animator.OnAnimEndedEvent -= OnAnimEnded;
    }

    private void OnAnimEnded()
    {
        _parent.SetActive(false);
    }

    private void OnMouseDown()
    {
        _animator.Exit();
    }

    public void SetFruit(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
