using System;
using System.Collections.Generic;
using UniPixelPlanet.Runtime.Attributes;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Data
{
    [Serializable]
    public struct GradientGroup
    {
        [ShaderProp]
        public string propName;
        public GradientColor[] colors;
    }
    
    [CreateAssetMenu(fileName = nameof(PlanetGradientColorData), menuName = "Data/Planet/GradientColor")]
    public class PlanetGradientColorData : ScriptableObject
    {
        public IReadOnlyList<GradientGroup> Gradients => gradients;
        [SerializeField]
        private List<GradientGroup> gradients;
    }
}