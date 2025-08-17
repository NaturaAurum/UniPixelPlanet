using UnityEngine;

namespace UniPixelPlanet.Runtime.Data
{
    [CreateAssetMenu(fileName = nameof(PlanetVectorData), menuName = "Data/Planet/VectorData")]
    public class PlanetVectorData : PlanetListData<Vector4>
    {
        
    }
}