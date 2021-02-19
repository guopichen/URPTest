// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/MyFirstShader"
{
    Properties
    {
        _Tint ("Tint", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM

            #pragma vertex MyVerttexProgram
            #pragma fragment MyFragmentProgram

            #include "UnityCG.cginc"

            float4 _Tint;
            sampler2D _MainTex;

            struct VertexData
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };


            Interpolators MyVerttexProgram (VertexData v)
            {
                Interpolators i;
                i.uv = v.uv;
                i.position = UnityObjectToClipPos(v.position);
                return i;
            }

            float4 MyFragmentProgram (Interpolators i) : SV_TARGET
            {
                return tex2D(_MainTex, i.uv);
            }

            ENDCG
        }
    }
}
