Shader "Custom/Vine" {
	Properties {
		_Tex ("Tileset", 2D) = "white" {} 

		_Vines ("Vines", Float) = 8

		_Height ("Segment Height", Float) = 0
		_Length ("Vine Length", Float) = 8
	}
	
	SubShader {
		Tags { "Queue" = "Background" } 
		Pass {
			Cull Back
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
				float3 tex : TEXCOORD0;
			};

			v2f vert(vin v) {
				v2f vf;
				vf.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				vf.tex = v.vertex * _TexScale;
				return vf;
			}
			float4 frag(v2f vf) : COLOR {
				return tex2D(_Tex, vf.tex.xz);
			}
	 
			ENDCG
		}
	}
}