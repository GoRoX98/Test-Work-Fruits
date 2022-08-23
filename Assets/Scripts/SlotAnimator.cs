using System;
using UnityEngine;

public class SlotAnimator : MonoBehaviour
{
    [SerializeField] Animator _animator;
    public event Action OnAnimEndedEvent; 

    public void Exit()
    {
        _animator.SetTrigger("exit");
    }

    private void Handle_AnimEnded()
    {
        OnAnimEndedEvent?.Invoke();
    }
}
