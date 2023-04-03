Shader "Custom/MinimapGridShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _GridSize ("Grid Size", Range(1, 100)) = 10
        _GridColor ("Grid Color", Color) = (0, 0, 0, 1)
    }

    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _GridSize;
            fixed4 _GridColor;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                float2 gridUV = i.uv * _GridSize;
                if (abs(frac(gridUV.x) - 0.5) < 0.01 || abs(frac(gridUV.y) - 0.5) < 0.01)
                    col.rgb = lerp(col.rgb, _GridColor.rgb, _GridColor.a);
                return col;
            }
            ENDCG
        }
    }
}