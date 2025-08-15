using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetMaterialController : MonoBehaviour
    {
        public Renderer targetRenderer;
        private MaterialPropertyBlock _propertyBlock;

        private void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();
        }

        private void Get()
        {
            targetRenderer.GetPropertyBlock(_propertyBlock);
        }

        private void Set()
        {
            targetRenderer.SetPropertyBlock(_propertyBlock);
        }

        protected void UpdateFloat(string key, float value)
        {
            Get();
            _propertyBlock.SetFloat(key, value);
            Set();
        }

        protected void UpdateColor(string key, Color color)
        {
            Get();
            _propertyBlock.SetColor(key, color);
            Set();
        }

        protected void UpdateVector(string key, Vector2 vector)
        {
            Get();
            _propertyBlock.SetVector(key, vector);
            Set();
        }

        protected void UpdateColor(string key, Color[] colors, float[] times)
        {
            Get();
            _propertyBlock.SetTexture(key, GradientUtil.GenerateShaderTex(colors, times));
            Set();
        }
    }
}