// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:7,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33518,y:32622,varname:node_4795,prsc:2|emission-300-OUT,alpha-448-OUT,clip-626-OUT;n:type:ShaderForge.SFN_Tex2d,id:4359,x:30250,y:32124,ptovrint:False,ptlb:TilingTexture,ptin:_TilingTexture,varname:node_5370,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1653-OUT;n:type:ShaderForge.SFN_Panner,id:6508,x:29810,y:32131,varname:node_6508,prsc:2,spu:0,spv:0.01|UVIN-4435-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4435,x:29544,y:32136,varname:node_4435,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:8839,x:29797,y:32403,varname:node_8839,prsc:2,spu:0,spv:0.005|UVIN-2057-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:9947,x:30250,y:32317,ptovrint:False,ptlb:TilingTexture2,ptin:_TilingTexture2,varname:node_8713,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3767-OUT;n:type:ShaderForge.SFN_TexCoord,id:2057,x:29530,y:32404,varname:node_2057,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:128,x:30534,y:32245,varname:node_128,prsc:2|A-4359-R,B-9947-G;n:type:ShaderForge.SFN_Desaturate,id:7489,x:30863,y:32292,varname:node_7489,prsc:2|COL-128-OUT,DES-3538-OUT;n:type:ShaderForge.SFN_Vector1,id:3538,x:30604,y:32414,varname:node_3538,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:4623,x:31084,y:32420,varname:node_4623,prsc:2|A-7489-OUT,B-6055-OUT;n:type:ShaderForge.SFN_Color,id:4092,x:31616,y:33169,ptovrint:False,ptlb:IntersectionColor,ptin:_IntersectionColor,varname:node_3915,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Blend,id:5330,x:31893,y:33062,varname:node_5330,prsc:2,blmd:10,clmp:True|SRC-227-OUT,DST-4092-RGB;n:type:ShaderForge.SFN_OneMinus,id:227,x:31616,y:32983,varname:node_227,prsc:2|IN-193-OUT;n:type:ShaderForge.SFN_DepthBlend,id:193,x:31280,y:32986,varname:node_193,prsc:2|DIST-9263-OUT;n:type:ShaderForge.SFN_Slider,id:9263,x:30912,y:32999,ptovrint:False,ptlb:IntesectionDistance,ptin:_IntesectionDistance,varname:node_1566,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Slider,id:7040,x:30702,y:33794,ptovrint:False,ptlb:IntersectionPower,ptin:_IntersectionPower,varname:node_2149,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:2315,x:32159,y:32777,varname:node_2315,prsc:2|A-2710-OUT,B-5330-OUT;n:type:ShaderForge.SFN_Multiply,id:1653,x:30027,y:32131,varname:node_1653,prsc:2|A-6508-UVOUT,B-3392-OUT;n:type:ShaderForge.SFN_Vector1,id:3392,x:29825,y:32299,varname:node_3392,prsc:2,v1:24;n:type:ShaderForge.SFN_Multiply,id:3767,x:30021,y:32403,varname:node_3767,prsc:2|A-8839-UVOUT,B-3392-OUT;n:type:ShaderForge.SFN_Blend,id:4237,x:31515,y:32497,varname:node_4237,prsc:2,blmd:10,clmp:True|SRC-2801-OUT,DST-8221-RGB;n:type:ShaderForge.SFN_Color,id:8221,x:31082,y:32742,ptovrint:False,ptlb:MainColor,ptin:_MainColor,varname:node_8221,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5597427,c2:0.7445487,c3:0.875,c4:1;n:type:ShaderForge.SFN_Vector3,id:6055,x:30863,y:32474,varname:node_6055,prsc:2,v1:0.4411765,v2:0.4411765,v3:0.4411765;n:type:ShaderForge.SFN_Tex2d,id:883,x:30524,y:33439,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_883,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7b25c74ff29393347b46a238d9982ee6,ntxv:0,isnm:False|UVIN-6235-UVOUT;n:type:ShaderForge.SFN_Add,id:4556,x:32030,y:33493,varname:node_4556,prsc:2|A-6264-OUT,B-7040-OUT;n:type:ShaderForge.SFN_Multiply,id:9908,x:30877,y:33526,varname:node_9908,prsc:2|A-883-R,B-883-B;n:type:ShaderForge.SFN_Multiply,id:1769,x:31166,y:33447,varname:node_1769,prsc:2|A-883-G,B-9908-OUT;n:type:ShaderForge.SFN_OneMinus,id:3666,x:31335,y:33463,varname:node_3666,prsc:2|IN-1769-OUT;n:type:ShaderForge.SFN_Power,id:4058,x:31559,y:33507,varname:node_4058,prsc:2|VAL-3666-OUT,EXP-3733-OUT;n:type:ShaderForge.SFN_Vector1,id:3733,x:31335,y:33611,varname:node_3733,prsc:2,v1:8;n:type:ShaderForge.SFN_Subtract,id:6264,x:31761,y:33621,varname:node_6264,prsc:2|A-4058-OUT,B-6214-OUT;n:type:ShaderForge.SFN_OneMinus,id:6214,x:31434,y:33792,varname:node_6214,prsc:2|IN-2143-OUT;n:type:ShaderForge.SFN_Multiply,id:2143,x:31211,y:33826,varname:node_2143,prsc:2|A-7040-OUT,B-8735-OUT;n:type:ShaderForge.SFN_Vector1,id:8735,x:31000,y:33901,varname:node_8735,prsc:2,v1:2;n:type:ShaderForge.SFN_ConstantClamp,id:626,x:32380,y:33282,varname:node_626,prsc:2,min:0.2,max:0.8|IN-2522-OUT;n:type:ShaderForge.SFN_Multiply,id:4126,x:32752,y:33043,varname:node_4126,prsc:2|A-2315-OUT,B-626-OUT;n:type:ShaderForge.SFN_Panner,id:6235,x:30273,y:33428,varname:node_6235,prsc:2,spu:0,spv:-0.2|UVIN-6401-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6401,x:30050,y:33428,varname:node_6401,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:2633,x:30192,y:32823,ptovrint:False,ptlb:TilingTexture3,ptin:_TilingTexture3,varname:_TilingTexture3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bb71e3d31af281e469d427f810cd3308,ntxv:0,isnm:False|UVIN-8877-OUT;n:type:ShaderForge.SFN_Tex2d,id:1229,x:30192,y:32630,ptovrint:False,ptlb:TilingTexture_copy,ptin:_TilingTexture_copy,varname:_TilingTexture_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bb71e3d31af281e469d427f810cd3308,ntxv:0,isnm:False|UVIN-2448-OUT;n:type:ShaderForge.SFN_Panner,id:1391,x:29797,y:32634,varname:node_1391,prsc:2,spu:-0.02,spv:0.03|UVIN-6034-UVOUT;n:type:ShaderForge.SFN_Panner,id:324,x:29797,y:32833,varname:node_324,prsc:2,spu:0.01,spv:-0.04|UVIN-1647-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6034,x:29495,y:32625,varname:node_6034,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:1647,x:29495,y:32828,varname:node_1647,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:9140,x:30419,y:32763,varname:node_9140,prsc:2|A-1229-R,B-2633-B;n:type:ShaderForge.SFN_Multiply,id:2448,x:30000,y:32644,varname:node_2448,prsc:2|A-1391-UVOUT,B-2783-OUT;n:type:ShaderForge.SFN_Multiply,id:8877,x:30000,y:32833,varname:node_8877,prsc:2|A-324-UVOUT,B-2783-OUT;n:type:ShaderForge.SFN_Vector1,id:2783,x:29639,y:32781,varname:node_2783,prsc:2,v1:6;n:type:ShaderForge.SFN_Multiply,id:2710,x:31728,y:32654,varname:node_2710,prsc:2|A-4237-OUT,B-5018-OUT;n:type:ShaderForge.SFN_Power,id:2801,x:31326,y:32457,varname:node_2801,prsc:2|VAL-4623-OUT,EXP-6506-OUT;n:type:ShaderForge.SFN_Slider,id:2900,x:30754,y:32646,ptovrint:False,ptlb:FlimmerPower,ptin:_FlimmerPower,varname:node_2900,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:0.5;n:type:ShaderForge.SFN_OneMinus,id:6506,x:31111,y:32558,varname:node_6506,prsc:2|IN-2900-OUT;n:type:ShaderForge.SFN_Power,id:5018,x:31481,y:32710,varname:node_5018,prsc:2|VAL-9140-OUT,EXP-6506-OUT;n:type:ShaderForge.SFN_Multiply,id:2522,x:32206,y:33282,varname:node_2522,prsc:2|A-4556-OUT,B-5018-OUT;n:type:ShaderForge.SFN_Slider,id:9510,x:32597,y:33383,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_9510,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_OneMinus,id:448,x:33007,y:33253,varname:node_448,prsc:2|IN-9510-OUT;n:type:ShaderForge.SFN_Color,id:933,x:32322,y:32079,ptovrint:False,ptlb:DamageColor,ptin:_DamageColor,varname:node_6308,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2527,x:32751,y:32206,varname:node_2527,prsc:2|A-933-RGB,B-4221-OUT;n:type:ShaderForge.SFN_Slider,id:4221,x:31929,y:32246,ptovrint:False,ptlb:DamageAmmount,ptin:_DamageAmmount,varname:node_261,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Desaturate,id:2236,x:32680,y:32478,varname:node_2236,prsc:2|COL-4126-OUT,DES-4221-OUT;n:type:ShaderForge.SFN_Blend,id:300,x:33023,y:32348,varname:node_300,prsc:2,blmd:6,clmp:True|SRC-2236-OUT,DST-2527-OUT;proporder:4359-9947-4092-9263-8221-7040-883-2633-1229-2900-9510-933-4221;pass:END;sub:END;*/

Shader "Shader Forge/SH_HoloBarrier" {
    Properties {
        _TilingTexture ("TilingTexture", 2D) = "white" {}
        _TilingTexture2 ("TilingTexture2", 2D) = "white" {}
        _IntersectionColor ("IntersectionColor", Color) = (0.5,0.5,0.5,1)
        _IntesectionDistance ("IntesectionDistance", Range(0, 5)) = 0
        _MainColor ("MainColor", Color) = (0.5597427,0.7445487,0.875,1)
        _IntersectionPower ("IntersectionPower", Range(0, 1)) = 0
        _Noise ("Noise", 2D) = "white" {}
        _TilingTexture3 ("TilingTexture3", 2D) = "white" {}
        _TilingTexture_copy ("TilingTexture_copy", 2D) = "white" {}
        _FlimmerPower ("FlimmerPower", Range(-1, 0.5)) = 0
        _Opacity ("Opacity", Range(0, 1)) = 0
        _DamageColor ("DamageColor", Color) = (0.5,0.5,0.5,1)
        _DamageAmmount ("DamageAmmount", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend OneMinusSrcAlpha One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _TilingTexture; uniform float4 _TilingTexture_ST;
            uniform sampler2D _TilingTexture2; uniform float4 _TilingTexture2_ST;
            uniform float4 _IntersectionColor;
            uniform float _IntesectionDistance;
            uniform float _IntersectionPower;
            uniform float4 _MainColor;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _TilingTexture3; uniform float4 _TilingTexture3_ST;
            uniform sampler2D _TilingTexture_copy; uniform float4 _TilingTexture_copy_ST;
            uniform float _FlimmerPower;
            uniform float _Opacity;
            uniform float4 _DamageColor;
            uniform float _DamageAmmount;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_4537 = _Time + _TimeEditor;
                float2 node_6235 = (i.uv0+node_4537.g*float2(0,-0.2));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_6235, _Noise));
                float node_2783 = 6.0;
                float2 node_2448 = ((i.uv0+node_4537.g*float2(-0.02,0.03))*node_2783);
                float4 _TilingTexture_copy_var = tex2D(_TilingTexture_copy,TRANSFORM_TEX(node_2448, _TilingTexture_copy));
                float2 node_8877 = ((i.uv0+node_4537.g*float2(0.01,-0.04))*node_2783);
                float4 _TilingTexture3_var = tex2D(_TilingTexture3,TRANSFORM_TEX(node_8877, _TilingTexture3));
                float node_6506 = (1.0 - _FlimmerPower);
                float node_5018 = pow((_TilingTexture_copy_var.r+_TilingTexture3_var.b),node_6506);
                float node_626 = clamp((((pow((1.0 - (_Noise_var.g*(_Noise_var.r*_Noise_var.b))),8.0)-(1.0 - (_IntersectionPower*2.0)))+_IntersectionPower)*node_5018),0.2,0.8);
                clip(node_626 - 0.5);
////// Lighting:
////// Emissive:
                float node_3392 = 24.0;
                float2 node_1653 = ((i.uv0+node_4537.g*float2(0,0.01))*node_3392);
                float4 _TilingTexture_var = tex2D(_TilingTexture,TRANSFORM_TEX(node_1653, _TilingTexture));
                float2 node_3767 = ((i.uv0+node_4537.g*float2(0,0.005))*node_3392);
                float4 _TilingTexture2_var = tex2D(_TilingTexture2,TRANSFORM_TEX(node_3767, _TilingTexture2));
                float node_128 = (_TilingTexture_var.r+_TilingTexture2_var.g);
                float3 node_4126 = (((saturate(( _MainColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_MainColor.rgb-0.5))*(1.0-pow((lerp(node_128,dot(node_128,float3(0.3,0.59,0.11)),1.0)*float3(0.4411765,0.4411765,0.4411765)),node_6506))) : (2.0*_MainColor.rgb*pow((lerp(node_128,dot(node_128,float3(0.3,0.59,0.11)),1.0)*float3(0.4411765,0.4411765,0.4411765)),node_6506)) ))*node_5018)+saturate(( _IntersectionColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_IntersectionColor.rgb-0.5))*(1.0-(1.0 - saturate((sceneZ-partZ)/_IntesectionDistance)))) : (2.0*_IntersectionColor.rgb*(1.0 - saturate((sceneZ-partZ)/_IntesectionDistance))) )))*node_626);
                float3 emissive = saturate((1.0-(1.0-lerp(node_4126,dot(node_4126,float3(0.3,0.59,0.11)),_DamageAmmount))*(1.0-(_DamageColor.rgb*_DamageAmmount))));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(1.0 - _Opacity));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
