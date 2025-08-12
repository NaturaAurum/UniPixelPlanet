using UnityEngine;

namespace UniPixelPlanet.Runtime.__Bodies__.DryTerran
{
    public class DryTerran : CelestialBody {
    
        [SerializeField] private Color colorLand1 = ColorUtil.FromRGB("#ff8933");
        [SerializeField] private Color colorLand2 = ColorUtil.FromRGB("#e64539");
        [SerializeField] private Color colorLand3 = ColorUtil.FromRGB("#ad2f45");
        [SerializeField] private Color colorLand4 = ColorUtil.FromRGB("#52333f");
        [SerializeField] private Color colorLand5 = ColorUtil.FromRGB("#3d2936");

        [SerializeField] private GameObject land;

        private Material _landMat;

        private readonly float[] _colorTimes = { 0, 0.2f, 0.4f, 0.6f, 1.0f };


        private void Start()
        {
            _landMat = land.GetComponent<SpriteRenderer>().material;
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
                // maybe later 

            }

            UpdateColor();
        }

        private void Update()
        {
            UpdateTime(Time.time);
        }
        public void SetPixel(float amount)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetLight(Vector2 pos)
        {
            _landMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
        }

        public void SetSeed(float newSeed)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, newSeed);
        }

        public void SetRotate(float r)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time  );
        }

        public void UpdateColor()
        {
            _landMat.SetTexture(UniPixelPlanetShaderProps.KeyGradientTex, GradientUtil.GenerateShaderTex(new[] { colorLand1, colorLand2, colorLand3, colorLand4, colorLand5 }, _colorTimes));
        }

        public override void Perform()
        {
            Initialize();
        }


    }
}
