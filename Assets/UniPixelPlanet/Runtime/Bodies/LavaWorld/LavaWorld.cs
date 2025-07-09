using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.LavaWorld
{
    public class LavaWorld : CelestialBody {
    
        [SerializeField] private Color colorLand1 = ColorUtil.FromRGB("#8f4d57");
        [SerializeField] private Color colorLand2 = ColorUtil.FromRGB("#52333f");
        [SerializeField] private Color colorLand3 = ColorUtil.FromRGB("#3d2936");

        [SerializeField] private Color colorCrater1 = ColorUtil.FromRGB("#52333f");
        [SerializeField] private Color colorCrater2 = ColorUtil.FromRGB("#3d2936");

        [SerializeField] private Color colorRiver1 = ColorUtil.FromRGB("#ff8933");
        [SerializeField] private Color colorRiver2 = ColorUtil.FromRGB("#e64539");
        [SerializeField] private Color colorRiver3 = ColorUtil.FromRGB("#ad2f45");

        [SerializeField] private GameObject planetUnder;
        [SerializeField] private GameObject craters;
        [SerializeField] private GameObject lavaRivers;
        private Material _planetMat;
        private Material _cratersMat;
        private Material _riverMat;


        private void Start()
        {
            _planetMat = planetUnder.GetComponent<SpriteRenderer>().material;
            _cratersMat = craters.GetComponent<SpriteRenderer>().material;
            _riverMat = lavaRivers.GetComponent<SpriteRenderer>().material;
            Initialize();
        }

        public override void Initialize()
        {
            SetPixel(pixel);

            var seedInt = seed.GetHashCode();
            var rng = new System.Random(seedInt);

            var val = rng.NextDouble();
            val = val < 0.1f ? val + 1 : val * 10;
            calcSeed = (float)val;

            SetSeed((float)val);
            SetRiverCutOff(((float)rng.NextDouble() * 0.25f) + 0.4f);

            if (generateColors)
            {

            }

            UpdateColor();
        }

        private void Update()
        {
            UpdateTime(Time.time);
        }

        public void SetRiverCutOff(float amount)
        {
            _riverMat.SetFloat(UniPixelPlanetShaderProps.KeyColorRiverCutoff, amount);
        }

        public void SetPixel(float amount)
        {
            _planetMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _cratersMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _riverMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetLight(Vector2 pos)
        {
            _planetMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _cratersMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _riverMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
        }

        public void SetSeed(float seed)
        {
            _planetMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _cratersMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _riverMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _planetMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _cratersMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _riverMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
            _planetMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.5f);
            _cratersMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time  * 0.5f);
            _riverMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time  * 0.5f);
        }

        public void UpdateColor()
        {
            _planetMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorLand1);
            _planetMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorLand2);
            _planetMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, colorLand3);

            _cratersMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorCrater1);
            _cratersMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorCrater2);

            _riverMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorRiver1);
            _riverMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorRiver2);
            _riverMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, colorRiver3);
        }

        public override void Perform()
        {
            Initialize();
        }
    }
}
