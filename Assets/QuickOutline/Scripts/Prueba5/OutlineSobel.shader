Shader "Hidden/OutlineSobel"
{
    Properties
    {
        _Thickness ("Thickness", Range(1,5)) = 1
        _EdgeColor ("Edge Color", Color) = (0,0,0,1)
    }

    SubShader
    {
        Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Opaque" }
        ZWrite Off ZTest Always Cull Off

        Pass
        {
            Name "Outline"
            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D_X(_CameraDepthTexture);
            SAMPLER(sampler_CameraDepthTexture);

            TEXTURE2D_X(_CameraNormalsTexture);
            SAMPLER(sampler_CameraNormalsTexture);

            float _Thickness;
            float4 _EdgeColor;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            Varyings Vert(Attributes v)
            {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(v.positionOS.xyz);
                o.uv = v.uv;
                return o;
            }

            half4 Frag(Varyings i) : SV_Target
            {
                float2 texelSize = 1.0 / _ScreenParams.xy;

                float depth = SAMPLE_TEXTURE2D_X(_CameraDepthTexture, sampler_CameraDepthTexture, i.uv).r;
                float3 normal = SAMPLE_TEXTURE2D_X(_CameraNormalsTexture, sampler_CameraNormalsTexture, i.uv).rgb;

                float edge = 0;

                // Sobel kernel
                float2 offsets[8] = {
                    float2(-1,-1), float2(0,-1), float2(1,-1),
                    float2(-1, 0),                float2(1, 0),
                    float2(-1, 1), float2(0, 1), float2(1, 1)
                };

                for(int j=0;j<8;j++)
                {
                    float2 uv2 = i.uv + offsets[j] * texelSize * _Thickness;

                    float d2 = SAMPLE_TEXTURE2D_X(_CameraDepthTexture, sampler_CameraDepthTexture, uv2).r;
                    float3 n2 = SAMPLE_TEXTURE2D_X(_CameraNormalsTexture, sampler_CameraNormalsTexture, uv2).rgb;

                    if (abs(d2 - depth) > 0.001) edge = 1;
                    if (distance(n2, normal) > 0.2) edge = 1;
                }

                return edge > 0 ? _EdgeColor : half4(0,0,0,0);
            }
            ENDHLSL
        }
    }
}