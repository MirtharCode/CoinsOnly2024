Shader "Custom/SpriteDepth" 
{
    Properties 
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        _Cutoff("Alpha Cutoff", Range(0,1)) = 0.001
    }
    
    SubShader 
    {
        Tags 
        { 
            "Queue"="Transparent" 
            "RenderType"="Transparent" 
            "IgnoreProjector"="True" 
            "PreviewType"="Plane" 
            "CanUseSpriteAtlas"="True" 
        }
        
        // Configuración importante para sprites
        ZWrite On
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        Lighting Off
        Fog { Mode Off }
        
        Pass 
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata_t 
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };
            
            struct v2f 
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };
            
            sampler2D _MainTex;
            fixed4 _Color;
            fixed _Cutoff;
            
            v2f vert(appdata_t IN) 
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;
                return OUT;
            }
            
            fixed4 frag(v2f IN) : SV_Target 
            {
                fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
                
                // Mejor manejo del alpha
                if (c.a < _Cutoff)
                    discard;
                
                // Asegurar que el color esté pre-multiplicado
                c.rgb *= c.a;
                
                return c;
            }
            ENDCG
        }
    }
}