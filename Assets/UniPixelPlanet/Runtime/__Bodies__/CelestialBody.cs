using UnityEngine;

namespace UniPixelPlanet.Runtime.__Bodies__
{
    public abstract class CelestialBody : MonoBehaviour
    {
        [SerializeField] public int pixel = 100;
        [SerializeField] public string seed = "Seed";
        [SerializeField] public float calcSeed;
        [SerializeField] public bool generateColors;

        public abstract void Initialize();
        public abstract void Perform();
    }
}