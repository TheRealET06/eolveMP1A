Shader "Tutorial/19_InvertedHull/Unlit"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (1, 0, 0, 1)
        _OutlineThickness ("Outline Thickness", Range(0, .1)) = 0.03

        _Color ("Tint", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
        }

        // =========================================
        // FIRST PASS: NORMAL OBJECT
        // =========================================
        Pass
        {
            Cull Back

            CGPROGRAM

            #include "UnityCG.cginc"

            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float4 _MainTex_ST;

            fixed4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.position = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col *= _Color;
                return col;
            }

            ENDCG
        }

        // =========================================
        // SECOND PASS: OUTLINE
        // =========================================
        Pass
        {
            Cull Off

            CGPROGRAM

            #include "UnityCG.cginc"

            #pragma vertex vert
            #pragma fragment frag

            fixed4 _OutlineColor;
            float _OutlineThickness;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
            };

            v2f vert(appdata v)
{
    v2f o;

    float3 normal = v.normal;
    float len = length(normal);
    normal = (len > 0.0001) ? normal / len : float3(0, 1, 0);

    // TEMP TEST: hardcoded large offset, ignoring the property entirely
    float3 position = v.vertex.xyz + normal * 0.3;

    o.position = UnityObjectToClipPos(float4(position, 1.0));

    return o;
}

            fixed4 frag(v2f i) : SV_TARGET
{
    return _OutlineColor;
}

            ENDCG
        }
    }


}