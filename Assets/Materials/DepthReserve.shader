Shader "Custom/DepthReserveURP"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,0.5)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        // Depth Pass: Blockiert Objekte dahinter
        Pass
        {
            Name "DepthPass"
            Tags { "LightMode" = "DepthOnly" }

            ZWrite On        // Schreibt in den Depth Buffer
            ColorMask 0      // Rendert keine Farben (nur Tiefe)

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment fragDepth
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = TransformObjectToHClip(v.vertex);
                return o;
            }

            void fragDepth(v2f i) { }
            ENDHLSL
        }

        // Farbe + Transparenz Pass
        Pass
        {
            Name "ColorPass"
            Tags { "LightMode" = "UniversalForward" }

            Blend SrcAlpha OneMinusSrcAlpha // Alpha-Blending für Transparenz
            ZWrite On  // Lässt Depth-Writing aktiv, um Blockierung zu sichern

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = TransformObjectToHClip(v.vertex);
                return o;
            }

            float4 _Color;

            float4 frag (v2f i) : SV_Target
            {
                return _Color; // Rendert das Objekt transparent
            }
            ENDHLSL
        }
    }
}