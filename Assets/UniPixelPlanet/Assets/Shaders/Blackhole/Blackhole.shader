Shader "Unlit/Blackhole"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Pixels("Pixels", range(10,100)) = 100.0

        _GradientTex("Texture", 2D) = "white"{}
        _Black_color("Black Color", Color) = (0,0,0,0)

        //0 - 0.5
        _Radius("radius ",float) = 0.5
        //0 - 0.5
        _Light_width("_Light_width",float) = 0.05
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" "IgnoreProjector" = "True"}
        LOD 100

        Pass
        {
            Tags { "LightMode" = "UniversalForward"}

            CULL Off
            ZWrite Off // don't write to depth buffer 
            Blend SrcAlpha OneMinusSrcAlpha // use alpha blending

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "../cginc/hlmod.cginc"

            // Compatibility macros to preserve legacy code structure (do not remove unused parts)
            #ifndef UNITY_FOG_COORDS
            #define UNITY_FOG_COORDS(idx)
            #endif
            #ifndef UNITY_TRANSFER_FOG
            #define UNITY_TRANSFER_FOG(o,v)
            #endif
            #ifndef TRANSFORM_TEX_URP
            #define TRANSFORM_TEX_URP(uv, st) ((uv) * (st).xy + (st).zw)
            #endif

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _MainTex_ST;
            float _Pixels;

            TEXTURE2D(_GradientTex);
            SAMPLER(sampler_GradientTex);
            float4 _Black_color;

            float _Radius;
            float _Light_width;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = TRANSFORM_TEX_URP(v.uv, _MainTex_ST);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float4 frag (v2f i) : COLOR
            {
                float2 uv = floor(i.uv * _Pixels) / _Pixels;

                float d_to_center = distance(uv, float2(0.5, 0.5));

                float3 col = _Black_color.rgb;

                if (d_to_center > _Radius - _Light_width) {
                    float col_val = ceil(d_to_center - (_Radius - (_Light_width * 0.5))) * (1.0 / (_Light_width * 0.5));
                    col = SAMPLE_TEXTURE2D(_GradientTex, sampler_GradientTex, float2(col_val, 0.0)).rgb;
                }

                return float4(col, step(d_to_center, _Radius));
            }
            ENDHLSL
        }
    }
}