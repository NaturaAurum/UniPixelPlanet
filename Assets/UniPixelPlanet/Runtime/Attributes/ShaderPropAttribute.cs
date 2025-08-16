using System;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Attributes
{
    /// <summary>
    /// Apply to a string field to show a dropdown of shader property keys
    /// defined as public const string in <see cref="UniPixelPlanetShaderProps"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ShaderPropAttribute : PropertyAttribute
    {
        // Reserved for future use (e.g., filtering/grouping), keep minimal now.
        public ShaderPropAttribute() { }
    }
}