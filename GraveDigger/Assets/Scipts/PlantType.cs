using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlantType")]
public class PlantType : ScriptableObject
{
    [SerializeField] public int index;
    [SerializeField] public string Name;
    [SerializeField] public Sprite Sprite;
}
