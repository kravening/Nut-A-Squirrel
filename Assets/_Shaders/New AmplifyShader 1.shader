// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "WindyFoiliage"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Texture("Texture", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Texture;
		uniform float4 _Texture_ST;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Texture = i.uv_texcoord * _Texture_ST.xy + _Texture_ST.zw;
			float4 tex2DNode1 = tex2D( _Texture, uv_Texture );
			o.Albedo = tex2DNode1.rgb;
			o.Alpha = 1;
			clip( tex2DNode1.a - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15401
282;451;1906;781;3201.123;332.0079;3.480464;True;False
Node;AmplifyShaderEditor.PosVertexDataNode;135;-3622.09,1139.672;Float;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;153;-712.2122,1470.781;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;152;-891.5772,1449.702;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldToObjectTransfNode;111;-3294.267,-115.3848;Float;False;1;0;FLOAT4;0,0,0,1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;308.0428,-309.1248;Float;True;Property;_Texture;Texture;1;0;Create;True;0;0;False;0;7319be812c4f88b459290c6b133b82d6;cebe8ebbc19325845980b5c25f0c86a9;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WorldPosInputsNode;2;-3595.651,-101.0397;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;64;385.1752,451.6438;Float;True;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ClampOpNode;40;124.7194,656.0695;Float;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;21;69.22468,353.305;Float;True;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;-153.5255,470.1923;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;27;-140.1872,656.5088;Float;True;2;0;FLOAT;0;False;1;FLOAT;3;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;43;-157.8954,181.0135;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;45;-535.0784,320.0413;Float;False;Property;_XSwayStrength;XSwayStrength;3;0;Create;True;0;0;False;0;1;0.8;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;5;-1420.859,304.1601;Float;True;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinTimeNode;151;-1138.505,1311.55;Float;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;117;-1411.08,538.8741;Float;True;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;118;-1615.756,650.4749;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;10;-1615.866,312.2935;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;6;-1862.639,467.3196;Float;False;1;0;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;8;-2097.181,103.8505;Float;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;136;-2114.008,642.9147;Float;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;90;-1873.891,551.945;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;137;-2304.408,665.315;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;53,45;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;48;-2387.722,226.2842;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.WireNode;89;-1730.891,559.945;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;4;-2705.841,413.0393;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;47;-2705.405,263.799;Float;False;Property;_WindSize;WindSize;5;0;Create;True;0;0;False;0;1;0.01;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;46;-1856.732,587.9498;Float;False;Property;_WindSpeed;WindSpeed;4;0;Create;True;0;0;False;0;0.1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TransformPositionNode;154;-3151.819,943.5521;Float;False;Object;World;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;44;-519.0156,417.6117;Float;False;Property;_ZSwayStrength;ZSwayStrength;2;0;Create;True;0;0;False;0;1;0.8;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;147;1548.413,-85.74082;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;WindyFoiliage;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;153;0;152;0
WireConnection;152;0;151;3
WireConnection;111;0;2;0
WireConnection;64;0;21;0
WireConnection;64;1;40;0
WireConnection;40;0;27;0
WireConnection;21;0;43;0
WireConnection;21;2;42;0
WireConnection;42;0;44;0
WireConnection;42;1;117;0
WireConnection;27;0;135;2
WireConnection;43;0;5;0
WireConnection;43;1;45;0
WireConnection;5;0;10;0
WireConnection;117;0;118;0
WireConnection;118;0;136;2
WireConnection;118;1;6;0
WireConnection;10;0;8;2
WireConnection;10;1;6;0
WireConnection;6;0;90;0
WireConnection;8;1;48;0
WireConnection;136;1;137;0
WireConnection;90;0;89;0
WireConnection;137;0;48;0
WireConnection;48;0;4;0
WireConnection;48;1;47;0
WireConnection;89;0;46;0
WireConnection;4;0;154;1
WireConnection;4;1;154;3
WireConnection;154;0;135;0
WireConnection;147;0;1;0
WireConnection;147;10;1;4
ASEEND*/
//CHKSM=F91563FC2F1B3291CC6E4C5EE5DF9B82F9097D7E