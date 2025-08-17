using System;
using UniPixelPlanet.Runtime.Attributes;

namespace UniPixelPlanet.Runtime.Data
{
    [Serializable]
    public struct DataElement<T> where T : struct
    {
        [ShaderProp]
        public string propName;
        public T value;
    }
}