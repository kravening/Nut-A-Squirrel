// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "WindyFoiliage"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.42
		_Texture("Texture", 2D) = "white" {}
		_ZSwayStrength("ZSwayStrength", Float) = 1
		_XSwayStrength("XSwayStrength", Float) = 1
		_WindSpeed("WindSpeed", Float) = 0.1
		_WindSize("WindSize", Float) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float3 worldPos;
			float2 uv_texcoord;
		};

		uniform float _WindSize;
		uniform float _WindSpeed;
		uniform float _XSwayStrength;
		uniform float _ZSwayStrength;
		uniform sampler2D _Texture;
		uniform float4 _Texture_ST;
		uniform float _Cutoff = 0.42;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float4 transform111 = mul(unity_WorldToObject,float4( ase_worldPos , 0.0 ));
			float2 appendResult4 = (float2(transform111.x , transform111.z));
			float2 temp_output_48_0 = ( appendResult4 * _WindSize );
			float2 uv_TexCoord8 = v.texcoord.xy + temp_output_48_0;
			float mulTime6 = _Time.y * _WindSpeed;
			float2 temp_cast_3 = (( uv_TexCoord8.y + mulTime6 )).xx;
			float simplePerlin2D5 = snoise( temp_cast_3 );
			float temp_output_153_0 = ( ( _SinTime.z - 0.5 ) * 2.0 );
			float2 uv_TexCoord136 = v.texcoord.xy + ( temp_output_48_0 + float2( 53,45 ) );
			float2 temp_cast_4 = (( uv_TexCoord136.y + mulTime6 )).xx;
			float simplePerlin2D117 = snoise( temp_cast_4 );
			float3 appendResult21 = (float3(( simplePerlin2D5 * _XSwayStrength * temp_output_153_0 ) , 0.0 , ( _ZSwayStrength * simplePerlin2D117 * temp_output_153_0 )));
			float3 ase_vertex3Pos = v.vertex.xyz;
			float clampResult40 = clamp( pow( ( ase_vertex3Pos.y - 0.0 ) , 3.0 ) , 0.0 , 1.0 );
			v.vertex.xyz += ( float3( appendResult4 ,  0.0 ) - ( float3( appendResult4 ,  0.0 ) + ( appendResult21 * clampResult40 ) ) );
		}

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
1;1;1918;1057;2417.812;63.6188;1.6;True;False
Node;AmplifyShaderEditor.WorldPosInputsNode;2;-3595.651,-101.0397;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldToObjectTransfNode;111;-3294.267,-115.3848;Float;False;1;0;FLOAT4;0,0,0,1;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;46;-1856.732,587.9498;Float;False;Property;_WindSpeed;WindSpeed;4;0;Create;True;0;0;False;0;0.1;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;47;-2705.405,263.799;Float;False;Property;_WindSize;WindSize;5;0;Create;True;0;0;False;0;1;0.025;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;4;-2705.841,413.0393;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.WireNode;89;-1730.891,559.945;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;48;-2387.722,226.2842;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;137;-2304.408,665.315;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;53,45;False;1;FLOAT2;0
Node;AmplifyShaderEditor.WireNode;90;-1873.891,551.945;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;8;-2097.181,103.8505;Float;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;136;-2114.008,642.9147;Float;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;6;-1862.639,467.3196;Float;False;1;0;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinTimeNode;151;-1025.812,1073.982;Float;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;10;-1615.866,312.2935;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;135;-528.6954,1141.571;Float;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;118;-1615.756,650.4749;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;152;-878.6121,1345.981;Float;False;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;37;-344.8516,656.6269;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;44;-351.7109,395.3042;Float;False;Property;_ZSwayStrength;ZSwayStrength;2;0;Create;True;0;0;False;0;1;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;117;-1411.08,538.8741;Float;True;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;45;-354.1412,321.2806;Float;False;Property;_XSwayStrength;XSwayStrength;3;0;Create;True;0;0;False;0;1;0.3;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;5;-1420.859,304.1601;Float;True;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;153;-712.2122,1470.781;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;27;-140.1872,656.5088;Float;True;2;0;FLOAT;0;False;1;FLOAT;3;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;43;-157.8954,181.0135;Float;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;-153.5255,470.1923;Float;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;21;69.22468,353.305;Float;True;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ClampOpNode;40;124.7194,656.0695;Float;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;127;-2378.639,-47.58991;Float;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;64;385.1752,451.6438;Float;True;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WireNode;129;-2346.567,-102.1113;Float;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.WireNode;128;129.3497,115.9745;Float;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;34;794.2566,350.9624;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WireNode;130;132.5562,45.41739;Float;False;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;78;1004.01,252.9039;Float;False;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;1;308.0428,-309.1248;Float;True;Property;_Texture;Texture;1;0;Create;True;0;0;False;0;None;b5f36ee49070e404891ae6d1f59ea9e9;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SinOpNode;150;-1033.871,827.3758;Float;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;147;1548.413,-85.74082;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;WindyFoiliage;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.42;True;True;0;True;Transparent;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;111;0;2;0
WireConnection;4;0;111;1
WireConnection;4;1;111;3
WireConnection;89;0;46;0
WireConnection;48;0;4;0
WireConnection;48;1;47;0
WireConnection;137;0;48;0
WireConnection;90;0;89;0
WireConnection;8;1;48;0
WireConnection;136;1;137;0
WireConnection;6;0;90;0
WireConnection;10;0;8;2
WireConnection;10;1;6;0
WireConnection;118;0;136;2
WireConnection;118;1;6;0
WireConnection;152;0;151;3
WireConnection;37;0;135;2
WireConnection;117;0;118;0
WireConnection;5;0;10;0
WireConnection;153;0;152;0
WireConnection;27;0;37;0
WireConnection;43;0;5;0
WireConnection;43;1;45;0
WireConnection;43;2;153;0
WireConnection;42;0;44;0
WireConnection;42;1;117;0
WireConnection;42;2;153;0
WireConnection;21;0;43;0
WireConnection;21;2;42;0
WireConnection;40;0;27;0
WireConnection;127;0;4;0
WireConnection;64;0;21;0
WireConnection;64;1;40;0
WireConnection;129;0;4;0
WireConnection;128;0;127;0
WireConnection;34;0;128;0
WireConnection;34;1;64;0
WireConnection;130;0;129;0
WireConnection;78;0;130;0
WireConnection;78;1;34;0
WireConnection;150;0;6;0
WireConnection;147;0;1;0
WireConnection;147;10;1;4
WireConnection;147;11;78;0
ASEEND*/
//CHKSM=BC726D65A6BA7364D61944F31C1BF13D97C4B7BB