using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveFruit : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Transform _transform;
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private Slot _slot;
    [SerializeField] bool _debug;

    private Collider2D _col;

    private void OnMouseDrag()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        _transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    private void OnMouseUp()
    {
        CheckTrigger(_col);

        transform.localPosition = new Vector3(0, 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _col = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        _col = collision;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _col = collision;
    }

    private void CheckTrigger(Collider2D col)
    {
        if (col == null)
            return;

        Slot colSlot = col.GetComponent<Slot>();
        print($"my fruit {_slot.SlotType}");
        print($"fruit {colSlot.SlotType}");

        if (colSlot.SlotType == _slot.SlotType)
        {
            colSlot.SetFruit(_render.sprite);
            _slot.TakeFruit();
        }
    }
}
