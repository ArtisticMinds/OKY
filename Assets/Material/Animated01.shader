// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "WILEz/PoolWater" {
	Properties{
		_TintColor("Tint Color", Color) = (1,1,1,1)
		_MainTex("Color (RGB)", 2D) = "black" {}
		_ColorStrength("Color Strength", Float) = 1
		_ColorTile("ColorMap Tile", Range(0.01,100)) = 15
		_DiffuseRotationSpeed("Color Speed",Range(0,200)) = 1.0
		_BumpMap("Normalmap", 2D) = "bump" {}
		_WaveTile("BumpMap Tile", Range(0.01,100)) = 15
		_RotationSpeed("Bump Speed", Range(0,200)) = 5.0
		
		
		
		_BumpAmt("Distortion",  Range(0,200)) = 1.0
		_InvFade("Soft Factor", Range(0.1,20)) = 9.0
		_RefractionAngle("Refcraftion Angle", Range(-5,5)) = 1.5
	
		
	}

		Category{

		Tags{ "Queue" = "Transparent"  "IgnoreProjector" = "True"  "RenderType" = "Opaque" }
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Back
		Lighting Off
		ZWrite Off
		Fog{ Mode Off }

		SubShader{
		GrabPass{
		Name "BASE"
		Tags{ "LightMode" = "Always" }
	}
		Pass{
		Name "BASE"
		Tags{ "LightMode" = "Always" }

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#pragma multi_compile_particles
#include "UnityCG.cginc"

		struct appdata_t {
		float4 vertex : POSITION;
		float2 texcoord: TEXCOORD0;
		fixed4 color : COLOR;
	};

	struct v2f {
		float4 vertex : POSITION;
		float4 uvgrab : TEXCOORD0;
		float2 uvbump : TEXCOORD1;
		float2 uvmain : TEXCOORD2;
		fixed4 color : COLOR;
#ifdef SOFTPARTICLES_ON
		float4 projPos : TEXCOORD3;
#endif
	};

	sampler2D _MainTex;
	sampler2D _BumpMap;

	float _BumpAmt;
	float _RefractionAngle;
	float _WaveTile;
	float _ColorTile;
	float _ColorStrength;
	sampler2D _GrabTexture;
	float4 _GrabTexture_TexelSize;
	fixed4 _TintColor;


	float4 _BumpMap_ST;
	float4 _MainTex_ST;
	float _RotationSpeed;
	float _DiffuseRotationSpeed;

	v2f vert(appdata_t v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
#ifdef SOFTPARTICLES_ON
		o.projPos = ComputeScreenPos(o.vertex);
		COMPUTE_EYEDEPTH(o.projPos.z);
#endif
		o.color = v.color;
#if UNITY_UV_STARTS_AT_TOP
		float scale = -1.0;
#else
		float scale = 1.0;
#endif
		float ref = 1+_RefractionAngle/500;
		o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.50*ref;
		o.uvgrab.zw = o.vertex.zw;


		
	
		float cosX = cos(_RotationSpeed * _Time)/15;
		float sinY = sin(_RotationSpeed * _Time)/20;
		float d_cosX = cos(_DiffuseRotationSpeed * _Time) / 55;
		float d_sinY = sin(_DiffuseRotationSpeed * _Time) / 60;

		float tile = 0.01 + _WaveTile / 500;
		float2x2 rotationMatrix = float2x2(cosX, tile, tile, sinY);
		float2x2 d_rotationMatrix = float2x2(d_cosX, tile, tile, d_sinY);

		float2 diffuseCoord = mul(v.texcoord.xy*_ColorTile, d_rotationMatrix);
		v.texcoord.xy = mul(v.texcoord.xy, rotationMatrix );
		

		o.uvbump = TRANSFORM_TEX(v.texcoord, _BumpMap);
		o.uvmain = TRANSFORM_TEX(diffuseCoord, _MainTex);


		return o;
	}











	sampler2D _CameraDepthTexture;
	float _InvFade;

	half4 frag(v2f i) : COLOR
	{
#ifdef SOFTPARTICLES_ON
		if (_InvFade > 0.0001) {
			float sceneZ = LinearEyeDepth(UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos))));
			float partZ = i.projPos.z;
			float fade = saturate(_InvFade * (sceneZ - partZ));
			i.color.a *= fade;
		}
#endif

	half2 bump = UnpackNormal(tex2D(_BumpMap, i.uvbump)).rg;
	float2 offset = bump * _BumpAmt * _GrabTexture_TexelSize.xy*50;
	i.uvgrab.xy = offset * i.uvgrab.z + i.uvgrab.xy;

	half4 col = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(i.uvgrab));
	fixed4 tex = tex2D(_MainTex, i.uvmain) * i.color;
	fixed4 emission = col * i.color + tex * _ColorStrength * _TintColor;
	emission.a = _TintColor.a * i.color.a;
	return emission;
	}
		ENDCG
	}
	}

		FallBack "Effects/Distortion/Free/CullOff"

	}

}

