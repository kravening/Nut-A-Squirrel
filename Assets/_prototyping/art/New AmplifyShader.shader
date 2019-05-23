// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Aqua"
{
	Properties
	{
		_Color1("Color 1", Color) = (0,0,0,0)
		_opacity("opacity", Float) = 0
		_waveheight("waveheight", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Overlay+0" "IsEmissive" = "true"  }
		Cull Back
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaToMask On
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma exclude_renderers xbox360 xboxone ps4 psp2 n3ds wiiu 
		#pragma surface surf Unlit keepalpha noshadow noambient nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd vertex:vertexDataFunc 
		struct Input
		{
			float3 worldPos;
		};

		uniform float _waveheight;
		uniform float4 _Color1;
		uniform float _opacity;


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
			float mulTime3 = _Time.y * 0.2;
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float2 appendResult22 = (float2(ase_worldPos.x , ase_worldPos.z));
			float2 temp_output_30_0 = ( appendResult22 * float2( 0.05,0.05 ) );
			float simplePerlin2D1 = snoise( ( mulTime3 + temp_output_30_0 ) );
			float simplePerlin2D4 = snoise( ( ( mulTime3 * 0.85 ) + temp_output_30_0 ) );
			float simplePerlin2D7 = snoise( ( ( mulTime3 * 0.2 ) + ( temp_output_30_0 * float2( 2,2 ) ) ) );
			float temp_output_10_0 = ( simplePerlin2D1 * simplePerlin2D4 * simplePerlin2D7 );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float3 appendResult14 = (float3(0.0 , ( ( temp_output_10_0 * ase_vertex3Pos.x ) * _waveheight ) , 0.0));
			v.vertex.xyz += appendResult14;
		}

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			o.Emission = _Color1.rgb;
			o.Alpha = _opacity;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15401
7;271;1906;781;1154.399;-17.80792;1;True;False
Node;AmplifyShaderEditor.WorldPosInputsNode;21;-2967.394,616.0441;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DynamicAppendNode;22;-2667.093,722.644;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-2505.175,794.0861;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0.05,0.05;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;3;-2517.907,458.5746;Float;False;1;0;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-2135.887,475.0309;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-2100.923,320.4998;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0.85;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;34;-2100.818,793.8915;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;2,2;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;23;-1881.779,555.6262;Float;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;24;-1897.379,325.5258;Float;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;25;-1894.779,103.226;Float;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;4;-1635.688,252.3777;Float;True;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;7;-1640.154,511.9286;Float;True;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;1;-1648.812,27.36723;Float;True;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-1313.725,250.4755;Float;True;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;11;-1157.042,541.1133;Float;True;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-848.8118,432.5272;Float;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;44;-629.3987,329.8079;Float;False;Property;_waveheight;waveheight;4;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;-522.6738,523.0171;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0.2;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;16;-454.0536,-723.5043;Float;False;Property;_AQUA;AQUA;2;0;Create;True;0;0;False;0;0,0,0,0;0.4434852,0.5401258,0.6226415,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;17;-412.4541,-931.5046;Float;False;Property;_Color1;Color 1;0;0;Create;True;0;0;False;0;0,0,0,0;0.6918832,0.8532544,0.8679245,1;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;14;-254.7516,510.8746;Float;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;15;41.24563,-541.5045;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;43;509.1054,-99.18292;Float;False;Property;_opacity;opacity;3;0;Create;True;0;0;False;0;0;0.86;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;42;747.9619,-266.4503;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Aqua;False;False;False;False;True;False;True;True;True;True;True;True;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0;True;False;0;True;Transparent;;Overlay;All;True;True;True;True;True;True;True;False;False;False;False;False;False;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;1;-1;-1;-1;0;True;0;0;False;-1;-1;0;False;-1;0;0;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;22;0;21;1
WireConnection;22;1;21;3
WireConnection;30;0;22;0
WireConnection;9;0;3;0
WireConnection;6;0;3;0
WireConnection;34;0;30;0
WireConnection;23;0;9;0
WireConnection;23;1;34;0
WireConnection;24;0;6;0
WireConnection;24;1;30;0
WireConnection;25;0;3;0
WireConnection;25;1;30;0
WireConnection;4;0;24;0
WireConnection;7;0;23;0
WireConnection;1;0;25;0
WireConnection;10;0;1;0
WireConnection;10;1;4;0
WireConnection;10;2;7;0
WireConnection;12;0;10;0
WireConnection;12;1;11;1
WireConnection;33;0;12;0
WireConnection;33;1;44;0
WireConnection;14;1;33;0
WireConnection;15;1;16;0
WireConnection;15;2;10;0
WireConnection;42;2;17;0
WireConnection;42;9;43;0
WireConnection;42;11;14;0
ASEEND*/
//CHKSM=E9F7D923BA6E3D49589F505509A5E96B6A1527D7