using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.Rendering.PostProcessing;

public class ChangePostProcessing : MonoBehaviour
{
    [SerializeField] private FloatHolder _crystalMaxHealth, _crystalCurrentHealth;
    private Grain _grain;
    private ColorGrading _colourGrading;
}
