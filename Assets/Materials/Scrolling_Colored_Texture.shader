Shader "Tower_Defense/Scrolling_Colored_Texture"
{
    Properties{
        _Color ("Main Color", Color) = (1,1,1,0.5)
        _MainTex ("Texture", 2D) = "white" {}
        _ScrollPosition ("Scroll Position", Float) = 0
        _RowCount ("Row Count", Float) = 1
	}
    SubShader{
        Pass{
        
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag

        #include "UnityCG.cginc"

        fixed4 _Color;
        sampler2D _MainTex;

        struct appdata{
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
		};

        struct v2f {
            float4 pos : SV_POSITION;
            float2 uv : TEXCOORD0;
		};

        float4 _MainTex_ST;
        float _ScrollPosition;
        float _RowCount;
        
        

        v2f vert(appdata v){
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);
            v.uv.x += (_RowCount - ((_ScrollPosition * -1) % _RowCount));
            o.uv = TRANSFORM_TEX (v.uv, _MainTex);
            return o;
		}

        fixed4 frag (v2f i) : SV_Target{
            i.uv.x %= (_RowCount * _MainTex_ST.x);
            fixed4 texcol = tex2D (_MainTex, i.uv);
            return texcol * _Color;
		}
        ENDCG
		}
	}
}
