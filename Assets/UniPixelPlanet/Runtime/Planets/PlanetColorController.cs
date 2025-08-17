using System;
using System.Collections.Generic;
using UniPixelPlanet.Runtime.Attributes;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    [Serializable]
    public struct ColorData
    {
        [ShaderProp]
        public string propName;
        public Color color;
    }
    
    public class PlanetColorController : PlanetMaterialController
    {
        public IReadOnlyList<ColorData> Colors => colors;
        [SerializeField]
        private List<ColorData> colors;
        
        public override void Perform()
        {
            Get();
            
            foreach (var color in colors)
            {
                PropertyBlock.SetColor(color.propName, color.color);
            }

            Set();
        }
    }
}