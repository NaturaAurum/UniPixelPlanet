using System;
using System.Collections.Generic;
using UniPixelPlanet.Runtime.Attributes;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    [Serializable]
    public struct Elements<T> where T : struct
    {
        [ShaderProp]
        public string propName;

        public T value;
    }
    
    public class PlanetMaterialListController<T> : PlanetMaterialController where T : struct
    {
        public IReadOnlyList<Elements<T>> List => list;
        
        [SerializeField]
        private List<Elements<T>> list;

        protected delegate void PropertySetter(string name, T value);

        protected virtual PropertySetter Setter => null;

        public override void Perform()
        {
            Get();
            
            foreach (var element in list)
            {
                Setter(element.propName, element.value);
            }
            
            Set();
        }
    }
}