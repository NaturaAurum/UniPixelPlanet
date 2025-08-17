using System.Collections.Generic;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Data
{
    public class PlanetListData<T> : ScriptableObject where T : struct
    {
        public IReadOnlyList<DataElement<T>> Data => data;
        [SerializeField]
        private List<DataElement<T>> data;

        public void OverwriteData(IEnumerable<DataElement<T>> target)
        {
            data ??= new List<DataElement<T>>();
            
            if (data is {Count: > 0})
            {
                data.Clear();
            }

            data.AddRange(target);
        }
    }
}