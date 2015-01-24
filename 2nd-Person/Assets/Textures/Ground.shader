Shader "Custom/Ground" {
	Properties {
		_Tex ("Tileset", 2D) = "white" {} 
		_TexScale ("Texture Scale", Float) = 1 
	}
	
	SubShader {
		Tags { "Queue" = "Transparent" } 
		Pass {
			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha
	
			CGPROGRAM 
			
 			#pragma vertex vert 
			#pragma fragment frag
			
			uniform sampler2D _Tex;
			uniform float _TexScale;
				
			struct vin {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};
			struct v2f {
				float4 pos : SV_POSITION;
				float2 tex : TEXCOORD0;
			};

			v2f vert(vin v) {
				v2f vf;
				vf.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				vf.tex = vf.pos * _TexScale;
				return vf;
			}
			float4 frag(v2f vf) : COLOR {
				return tex2D(_Tex, vf.tex.xy);
			}
	 
			ENDCG
		}
	}
}