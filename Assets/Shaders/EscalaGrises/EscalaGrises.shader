Shader "Custom/BlackWhiteTint"
{
    Properties
    {
        _TintColor ("Tint Color", Color) = (1,1,1,1)
        _Intensify ("Intensify", Float) = 2.3
        _EffectAmount ("Effect Amount", Range(0,1)) = 1
        _MainTex ("Grab Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        GrabPass { "_GrabTexture" }

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 grabPos : TEXCOORD0;
            };

            sampler2D _GrabTexture;
            float4 _TintColor;
            float _Intensify;
            float _EffectAmount;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.pos);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 screenCol = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(i.grabPos));
                float3 original = screenCol.rgb;

                // Convert to grayscale
                float gray = dot(original, float3(0.299, 0.587, 0.114));
                float3 tinted = gray * _TintColor.rgb * _Intensify;

                // Fade between original and effect
                float3 finalColor = lerp(original, tinted, _EffectAmount);

                return float4(finalColor, 1);
            }
            ENDCG
        }
    }
}