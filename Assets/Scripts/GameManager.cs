using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Slot> _slots;
    private bool _isFirstLaunch = true;

    private void Update()
    {
        if(_isFirstLaunch)
        {
            FirstStart(1f);
            _isFirstLaunch = false;
        }

        foreach(Slot slot in _slots)
        {
            if(!slot.Parent.activeSelf)
            {
                slot.Parent.SetActive(true);
            }
        }
    }

    async private void FirstStart(float seconds)
    {
        foreach(Slot slot in _slots)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(seconds));
            slot.Parent.SetActive(true);
        }
    }
}
