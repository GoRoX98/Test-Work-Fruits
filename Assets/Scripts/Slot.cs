using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameManager _gameManger;
    [SerializeField] private GameObject _parent;
    [SerializeField] private SlotAnimator _animator;
    [SerializeField] private List<Sprite> _spriteList;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private bool _playerSlot = false;
    [SerializeField] private List<AudioClip> _audios;
    [SerializeField] private AudioSource _audioSource;
    private Fruits _slotType;
    private bool _isEmpty = true;

    public Fruits SlotType => _slotType;
    public GameObject Parent => _parent;
    public bool IsEmpty => _isEmpty;
    public bool PlayerSlot => _playerSlot;

    public enum Fruits
    {
        Banana,
        Cherry,
        Grape
    }

    private void OnEnable()
    {
        if(!_playerSlot)
        {
            int value = Random.Range(0, _spriteList.Count);
            _spriteRenderer.sprite = _spriteList[value];
            _slotType = (Fruits)System.Enum.GetValues(typeof(Fruits)).GetValue(value);
            _isEmpty = true;
            _audioSource.clip = _audios[0];
            _audioSource.Play();
        }
        else
        {
            TakeFruit();
            _audioSource.clip = _audios[0];
            _audioSource.Play();
        }
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

    public void SetFruit(Sprite sprite)
    {
        _audioSource.clip = _audios[1];
        _audioSource.Play();
        _spriteRenderer.sprite = sprite;
        _isEmpty = false;
        if (_gameManger.SandboxGame && !_playerSlot)
            _animator.Exit();
    }

    public void TakeFruit()
    {
        _slotType = _gameManger.TakeFruit();
        _spriteRenderer.sprite = _spriteList[(int)_slotType];
    }
}
