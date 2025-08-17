using System;
using System.Collections.Generic;
using UniPixelPlanet.Runtime.Attributes;
using UniPixelPlanet.Runtime.Data;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetMaterialListController<T> : PlanetMaterialController where T : struct
    {
        [SerializeField]
        private PlanetListData<T> listData;

        protected delegate void PropertySetter(string name, T value);

        protected virtual PropertySetter Setter => null;

        public override void Perform()
        {
            Get();
            
            foreach (var element in listData.Data)
            {
                Setter(element.propName, element.value);
            }
            
            Set();
        }
    }
}