using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetColorController : PlanetMaterialListController<Color>
    {
        protected override PropertySetter Setter => PropertyBlock.SetColor;
    }
}