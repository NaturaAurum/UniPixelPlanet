using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetVectorController : PlanetMaterialListController<Vector4>
    {
        protected override PropertySetter Setter => PropertyBlock.SetVector;
    }
}