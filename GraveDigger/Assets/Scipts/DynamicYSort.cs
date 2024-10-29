using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicYSort : MonoBehaviour
{
    private int _baseSortingOrder;
    [SerializeField] private SortableSprite[] _sortableSprite;

    // Update is called once per frame
    void Update()
    {
        _baseSortingOrder = -(int)(transform.position.y * 100);
        foreach (SortableSprite sortableSprite in _sortableSprite)
        {
            sortableSprite.SpriteRenderer.sortingOrder = _baseSortingOrder + sortableSprite.RelativeOrder;
        }
    }

    [Serializable]
    public struct SortableSprite
    {
        public SpriteRenderer SpriteRenderer;
        public int RelativeOrder;
    }
}
