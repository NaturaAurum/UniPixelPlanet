namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetFloatController : PlanetMaterialListController<float>
    {
        protected override PropertySetter Setter => PropertyBlock.SetFloat;
    }
}