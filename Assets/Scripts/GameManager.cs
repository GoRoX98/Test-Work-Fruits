using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Slot> _slots;
    [SerializeField] private bool _sandboxGame = false;
    private bool _isFirstLaunch = true;

    public bool SandboxGame => _sandboxGame;

    private void Update()
    {
        if(_isFirstLaunch)
        {
            FirstStart(1f);
            _isFirstLaunch = false;
        }

        foreach(Slot slot in _slots)
        {
            if(!slot.Parent.activeSelf && _sandboxGame)
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

    public Slot.Fruits TakeFruit()
    {
        List<Slot.Fruits> fruitList = new List<Slot.Fruits>();
        foreach(Slot slot in _slots)
        {
            if(slot.IsEmpty && !slot.PlayerSlot)
            {
                fruitList.Add(slot.SlotType);
            }
        }

        if(fruitList.Count == 0)
        {
            return Slot.Fruits.Banana;
        }

        return fruitList[(int)Random.Range(0, fruitList.Count)];
    }
}
