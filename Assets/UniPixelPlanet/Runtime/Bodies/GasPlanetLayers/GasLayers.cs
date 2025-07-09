using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.GasPlanetLayers
{
    public class GasLayers : CelestialBody {
  
        [SerializeField] private Color color1 = ColorUtil.FromRGB("#eec39a");
        [SerializeField] private Color color2 = ColorUtil.FromRGB("#d9a066");
        [SerializeField] private Color color3 = ColorUtil.FromRGB("#8f563b");

        [SerializeField] private Color colorDark1 = ColorUtil.FromRGB("#663931");
        [SerializeField] private Color colorDark2 = ColorUtil.FromRGB("#45283c");
        [SerializeField] private Color colorDark3 = ColorUtil.FromRGB("#222034");

        [SerializeField] private GameObject gasPlanet;
        [SerializeField] private GameObject ring;

        private Material _gasPlanetMat;
        private Material _ringMat;

        private readonly float[] _colorTimes = { 0, 0.5f, 1.0f };

        private void Start()
        {
            _gasPlanetMat = gasPlanet.GetComponent<SpriteRenderer>().material;
            _ringMat = ring.GetComponent<SpriteRenderer>().material;
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

            if (generateColors)
            {
            }

            UpdateColor();
        }

        private void Update()
        {
            UpdateTime(Time.time);
        }

        public void SetPixel(float amount)
        {
            _gasPlanetMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _ringMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount * 3f);
        }

        public void SetLight(Vector2 pos)
        {
            _gasPlanetMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos * 1.3f  );
            _ringMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos * 1.3f );
        }

        public void SetSeed(float seed)
        {
            _gasPlanetMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _ringMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _gasPlanetMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _ringMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r + 0.7f);
        }

        public void UpdateTime(float time)
        {
            _gasPlanetMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.5f);
            _ringMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time  * 0.5f * -3f);
        }

        public void UpdateColor()
        {

            var tex1 = GradientUtil.GenerateShaderTex(new Color[] { color1, color2, color3 }, _colorTimes);
            var tex2 = GradientUtil.GenerateShaderTex(new Color[] { colorDark1, colorDark2, colorDark3 }, _colorTimes);

            _gasPlanetMat.SetTexture(UniPixelPlanetShaderProps.KeyTextureKeyword1, tex1);
            _gasPlanetMat.SetTexture(UniPixelPlanetShaderProps.KeyTextureKeyword2, tex2);

            _ringMat.SetTexture(UniPixelPlanetShaderProps.KeyTextureKeyword1, tex1);
            _ringMat.SetTexture(UniPixelPlanetShaderProps.KeyTextureKeyword2, tex2);
        }

        public override void Perform()
        {
            Initialize();
        }
    }
}