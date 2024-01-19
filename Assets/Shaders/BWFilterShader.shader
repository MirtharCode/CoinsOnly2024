Shader "Custom/LightBlackAndWhiteShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" { }
    }

    SubShader
    {
        Tags {"Queue" = "Overlay" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            float grayscale = dot(c.rgb, float3(0.6, 0.3, 0.1)); // Ajusta los valores aquí
            o.Albedo = float3(grayscale, grayscale, grayscale);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
