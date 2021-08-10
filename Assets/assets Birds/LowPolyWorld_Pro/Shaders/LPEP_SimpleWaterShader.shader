// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "RRF/LPEP_SimpleWaterShader"
{
	Properties
	{
		_Vector0("Vector 0", Vector) = (-0.3456,-0.1245,0,0)
		_XY_SpeedA("XY_SpeedA", Vector) = (0.2345,0.3456,0,0)
		_WaterTilingB("WaterTilingB", Range( 1 , 200)) = 55
		_WaterTilingA("WaterTilingA", Range( 1 , 200)) = 50
		_WaterNormalMap("WaterNormalMap", 2D) = "bump" {}
		_Shinyness("Shinyness", Range( 0 , 1)) = 0.95
		_TimeFactor("TimeFactor", Range( 0 , 2)) = 0.01234
		_Metalness("Metalness", Range( 0 , 1)) = 0.2
		_BaseColoremissiveA("BaseColor-emissive(A)", Color) = (0.1575476,0.3077438,0.4558824,0)
		_NormalMapPower("NormalMapPower", Range( 0 , 3)) = 1
		_Distance("Distance", Range( 0 , 2)) = 0
		_EdgePower("EdgePower", Range( 0 , 2)) = 0
		_ReampDest_XY("ReampDest_XY", Vector) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Pass
		{
			ColorMask 0
			ZTest LEqual
			ZWrite On
		}

		Tags{ "RenderType" = "Opaque"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
			float4 screenPos;
		};

		uniform sampler2D _WaterNormalMap;
		uniform float _WaterTilingA;
		uniform float _TimeFactor;
		uniform float2 _XY_SpeedA;
		uniform float _WaterTilingB;
		uniform float2 _Vector0;
		uniform float _NormalMapPower;
		uniform float4 _BaseColoremissiveA;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _Distance;
		uniform float _EdgePower;
		uniform float2 _ReampDest_XY;
		uniform float _Metalness;
		uniform float _Shinyness;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float mulTime9 = _Time.y * ( _TimeFactor / 100.0 );
			float2 panner3 = ( mulTime9 * _XY_SpeedA + i.uv_texcoord);
			float3 tex2DNode1 = UnpackNormal( tex2D( _WaterNormalMap, ( _WaterTilingA * panner3 ) ) );
			float2 panner14 = ( mulTime9 * _Vector0 + i.uv_texcoord);
			float3 tex2DNode11 = UnpackNormal( tex2D( _WaterNormalMap, ( _WaterTilingB * panner14 ) ) );
			float3 lerpResult23 = lerp( float3(0,0,1) , BlendNormals( tex2DNode1 , tex2DNode11 ) , _NormalMapPower);
			o.Normal = lerpResult23;
			float4 temp_output_21_0 = _BaseColoremissiveA;
			o.Albedo = temp_output_21_0.rgb;
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float screenDepth28 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm.xy ));
			float distanceDepth28 = abs( ( screenDepth28 - LinearEyeDepth( ase_screenPosNorm.z ) ) / ( _Distance ) );
			float clampResult33 = clamp( ( ( 1.0 - distanceDepth28 ) * _EdgePower ) , 0.0 , 1.0 );
			float clampResult41 = clamp( ( (_ReampDest_XY.x + (( ( tex2DNode1.r + tex2DNode1.g ) * ( tex2DNode11.r + tex2DNode11.g ) ) - 0.0) * (_ReampDest_XY.y - _ReampDest_XY.x) / (1.0 - 0.0)) * _NormalMapPower ) , 0.0 , 1.0 );
			o.Emission = ( clampResult33 + ( clampResult33 * clampResult41 ) + ( _BaseColoremissiveA * _BaseColoremissiveA.a ) ).rgb;
			o.Metallic = _Metalness;
			o.Smoothness = _Shinyness;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17000
7;30;1906;1013;133.9719;680.0671;1.686862;True;True
Node;AmplifyShaderEditor.RangedFloatNode;15;-1731.735,33.7181;Float;False;Property;_TimeFactor;TimeFactor;6;0;Create;True;0;0;False;0;0.01234;1.71;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;26;-1288.326,80.89294;Float;False;2;0;FLOAT;0;False;1;FLOAT;100;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;9;-1088.841,27.28608;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;4;-1121.728,-132.8681;Float;False;Property;_XY_SpeedA;XY_SpeedA;1;0;Create;True;0;0;False;0;0.2345,0.3456;-0.1245,-0.2345;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;6;-1081.049,-308.0987;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;13;-1063.044,159.4481;Float;False;Property;_Vector0;Vector 0;0;0;Create;True;0;0;False;0;-0.3456,-0.1245;0.2345,0.3456;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.PannerNode;14;-660.9823,173.6154;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;12;-736.1266,32.53129;Float;False;Property;_WaterTilingB;WaterTilingB;2;0;Create;True;0;0;False;0;55;15;1;200;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-713.0871,-300.2603;Float;False;Property;_WaterTilingA;WaterTilingA;3;0;Create;True;0;0;False;0;50;15;1;200;0;1;FLOAT;0
Node;AmplifyShaderEditor.PannerNode;3;-775.4388,-174.5897;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-398.4161,-248.2603;Float;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;10;-509.3964,-89.8515;Float;True;Property;_WaterNormalMap;WaterNormalMap;4;0;Create;True;0;0;False;0;d58fe39c4f189a84284cc939c05608ae;d58fe39c4f189a84284cc939c05608ae;True;bump;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-432.412,125.1765;Float;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;1;-226.1147,-186.1001;Float;True;Property;_Water_Normal;Water_Normal;0;0;Create;True;0;0;False;0;d58fe39c4f189a84284cc939c05608ae;d58fe39c4f189a84284cc939c05608ae;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;11;-191.0076,212.9898;Float;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;False;0;d58fe39c4f189a84284cc939c05608ae;d58fe39c4f189a84284cc939c05608ae;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;39;157.5678,159.7873;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;37;166.9252,-52.56746;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;29;1218.112,22.44577;Float;False;Property;_Distance;Distance;10;0;Create;True;0;0;False;0;0;0.34;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;38;305.9107,31.98349;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;44;318.9133,167.0784;Float;False;Property;_ReampDest_XY;ReampDest_XY;12;0;Create;True;0;0;False;0;0,0;0.9,47.48;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.DepthFade;28;1580.392,-11.69485;Float;False;True;False;True;2;1;FLOAT3;0,0,0;False;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;1258.323,430.2021;Float;False;Property;_NormalMapPower;NormalMapPower;9;0;Create;True;0;0;False;0;1;0.16;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;32;1456.125,84.03658;Float;False;Property;_EdgePower;EdgePower;11;0;Create;True;0;0;False;0;0;0.9;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;30;1872.068,-2.618213;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;40;632.4218,27.49082;Float;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;20;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;45;2042.08,227.4646;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;2113.722,68.85677;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;33;2305.885,76.85365;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;21;868.7415,-398.8652;Float;False;Property;_BaseColoremissiveA;BaseColor-emissive(A);8;0;Create;True;0;0;False;0;0.1575476,0.3077438,0.4558824,0;0,0.3590772,0.7132353,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ClampOpNode;41;2295.549,215.5171;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;2522.533,163.4171;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BlendNormalsNode;17;876.7411,257.3567;Float;True;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;25;1377.294,-259.7172;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.Vector3Node;22;965.3882,98.6355;Float;False;Constant;_Vector1;Vector 1;8;0;Create;True;0;0;False;0;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;18;866.7415,-112.8652;Float;False;Property;_Shinyness;Shinyness;5;0;Create;True;0;0;False;0;0.95;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;23;1567.011,245.2828;Float;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;19;867.7415,-211.8652;Float;False;Property;_Metalness;Metalness;7;0;Create;True;0;0;False;0;0.2;0.424;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;43;2786.848,-170.827;Float;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;3539.442,-294.604;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;RRF/LPEP_SimpleWaterShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;1;False;-1;0;False;-1;False;0;False;-1;0;False;-1;True;3;Translucent;0.5;True;True;0;False;Opaque;;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;26;0;15;0
WireConnection;9;0;26;0
WireConnection;14;0;6;0
WireConnection;14;2;13;0
WireConnection;14;1;9;0
WireConnection;3;0;6;0
WireConnection;3;2;4;0
WireConnection;3;1;9;0
WireConnection;7;0;8;0
WireConnection;7;1;3;0
WireConnection;16;0;12;0
WireConnection;16;1;14;0
WireConnection;1;0;10;0
WireConnection;1;1;7;0
WireConnection;11;0;10;0
WireConnection;11;1;16;0
WireConnection;39;0;11;1
WireConnection;39;1;11;2
WireConnection;37;0;1;1
WireConnection;37;1;1;2
WireConnection;38;0;37;0
WireConnection;38;1;39;0
WireConnection;28;0;29;0
WireConnection;30;0;28;0
WireConnection;40;0;38;0
WireConnection;40;3;44;1
WireConnection;40;4;44;2
WireConnection;45;0;40;0
WireConnection;45;1;24;0
WireConnection;31;0;30;0
WireConnection;31;1;32;0
WireConnection;33;0;31;0
WireConnection;41;0;45;0
WireConnection;42;0;33;0
WireConnection;42;1;41;0
WireConnection;17;0;1;0
WireConnection;17;1;11;0
WireConnection;25;0;21;0
WireConnection;25;1;21;4
WireConnection;23;0;22;0
WireConnection;23;1;17;0
WireConnection;23;2;24;0
WireConnection;43;0;33;0
WireConnection;43;1;42;0
WireConnection;43;2;25;0
WireConnection;0;0;21;0
WireConnection;0;1;23;0
WireConnection;0;2;43;0
WireConnection;0;3;19;0
WireConnection;0;4;18;0
ASEEND*/
//CHKSM=63ABB7CC8D2378C1AEAAE7F8A619CA3B3CCE98B6