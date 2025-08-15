using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies
{
    [Serializable]
    public struct ColorData
    {
        public string propName;
        public Color color;
    }
    
    public class PlanetColorController : MonoBehaviour
    {
        public List<ColorData> colors;
        
        public void UpdateColor(Renderer renderComp, MaterialPropertyBlock propBlock)
        {
            GetComponent<Renderer>().GetPropertyBlock(propBlock);
            
            foreach (var color in colors)
            {
                propBlock.SetColor(color.propName, color.color);
            }

            GetComponent<Renderer>().SetPropertyBlock(propBlock);
        }
    }
}