// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:1,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33471,y:32705,varname:node_4795,prsc:2|emission-2010-OUT,alpha-9086-OUT,clip-9086-OUT,refract-203-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:30715,y:32020,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:30715,y:31687,ptovrint:True,ptlb:FrontColor,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Fresnel,id:354,x:31041,y:32094,varname:node_354,prsc:2|EXP-7127-OUT;n:type:ShaderForge.SFN_Slider,id:7127,x:30685,y:32228,ptovrint:False,ptlb:Fresnel,ptin:_Fresnel,varname:node_7127,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2051282,max:1;n:type:ShaderForge.SFN_Blend,id:1083,x:31276,y:31920,varname:node_1083,prsc:2,blmd:6,clmp:True|SRC-8130-OUT,DST-354-OUT;n:type:ShaderForge.SFN_Color,id:2506,x:30715,y:31868,ptovrint:False,ptlb:BackColor,ptin:_BackColor,varname:node_2506,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2394572,c2:0.6716322,c3:0.7573529,c4:1;n:type:ShaderForge.SFN_Lerp,id:8130,x:31039,y:31792,varname:node_8130,prsc:2|A-797-RGB,B-2506-RGB,T-2053-RGB;n:type:ShaderForge.SFN_Clamp,id:9994,x:31511,y:31920,varname:node_9994,prsc:2|IN-1083-OUT,MIN-8227-OUT,MAX-8281-OUT;n:type:ShaderForge.SFN_Vector1,id:8227,x:31232,y:32143,varname:node_8227,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Vector1,id:8281,x:31232,y:32221,varname:node_8281,prsc:2,v1:1;n:type:ShaderForge.SFN_Color,id:8532,x:30204,y:32501,ptovrint:False,ptlb:HexagonColor,ptin:_HexagonColor,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5294118,c2:0.5294118,c3:0.5294118,c4:1;n:type:ShaderForge.SFN_Panner,id:4395,x:30025,y:32302,varname:node_4395,prsc:2,spu:0,spv:0.1|UVIN-3760-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6701,x:30204,y:32302,ptovrint:False,ptlb:Base Texture_copy,ptin:_BaseTexture_copy,varname:_BaseTexture_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4395-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3760,x:29783,y:32302,varname:node_3760,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:677,x:29523,y:32922,varname:node_677,prsc:2,spu:-0.2,spv:0.1|UVIN-8906-UVOUT;n:type:ShaderForge.SFN_Panner,id:9667,x:29523,y:33116,varname:node_9667,prsc:2,spu:0.1,spv:0.2|UVIN-4567-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:8906,x:29312,y:32874,varname:node_8906,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:4567,x:29312,y:33098,varname:node_4567,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:1438,x:29937,y:33034,varname:node_1438,prsc:2|A-7411-R,B-7596-R;n:type:ShaderForge.SFN_Add,id:5154,x:30006,y:33417,varname:node_5154,prsc:2|A-5441-R,B-2031-R;n:type:ShaderForge.SFN_Panner,id:5297,x:29526,y:33527,varname:node_5297,prsc:2,spu:0.3,spv:-0.1|UVIN-3826-UVOUT;n:type:ShaderForge.SFN_Panner,id:9993,x:29526,y:33333,varname:node_9993,prsc:2,spu:-0.2,spv:-0.3|UVIN-6666-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6666,x:29295,y:33338,varname:node_6666,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:3826,x:29317,y:33546,varname:node_3826,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:3373,x:30166,y:33234,varname:node_3373,prsc:2|A-1438-OUT,B-5154-OUT;n:type:ShaderForge.SFN_Add,id:8993,x:30365,y:33128,varname:node_8993,prsc:2|A-3373-OUT,B-1438-OUT;n:type:ShaderForge.SFN_Add,id:4921,x:30365,y:33333,varname:node_4921,prsc:2|A-3373-OUT,B-5154-OUT;n:type:ShaderForge.SFN_Multiply,id:4283,x:30565,y:33249,varname:node_4283,prsc:2|A-8993-OUT,B-4921-OUT;n:type:ShaderForge.SFN_Blend,id:5082,x:30504,y:32429,varname:node_5082,prsc:2,blmd:10,clmp:True|SRC-6701-G,DST-8532-RGB;n:type:ShaderForge.SFN_Tex2d,id:7411,x:29715,y:32922,ptovrint:False,ptlb:node_3671,ptin:_node_3671,varname:node_3671,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-677-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7596,x:29715,y:33127,ptovrint:False,ptlb:node_9198,ptin:_node_9198,varname:node_9198,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9667-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5441,x:29700,y:33361,ptovrint:False,ptlb:node_7799,ptin:_node_7799,varname:node_7799,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9993-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2031,x:29711,y:33571,ptovrint:False,ptlb:node_175,ptin:_node_175,varname:node_175,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5297-UVOUT;n:type:ShaderForge.SFN_Blend,id:9921,x:30965,y:33154,varname:node_9921,prsc:2,blmd:10,clmp:True|SRC-7499-OUT,DST-6270-RGB;n:type:ShaderForge.SFN_Color,id:6270,x:30753,y:33067,ptovrint:False,ptlb:CubePatternColor,ptin:_CubePatternColor,varname:node_7404,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:7499,x:30767,y:33299,varname:node_7499,prsc:2|A-4283-OUT,B-2289-OUT;n:type:ShaderForge.SFN_Slider,id:2289,x:30341,y:33527,ptovrint:False,ptlb:CubesPatternInensity,ptin:_CubesPatternInensity,varname:node_1993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8810127,max:1;n:type:ShaderForge.SFN_Panner,id:916,x:30021,y:32689,varname:node_916,prsc:2,spu:0,spv:0.03|UVIN-2621-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2828,x:30204,y:32689,ptovrint:False,ptlb:Base Texture_copy_copy,ptin:_BaseTexture_copy_copy,varname:_BaseTexture_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-916-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2621,x:29773,y:32689,varname:node_2621,prsc:2,uv:0;n:type:ShaderForge.SFN_Blend,id:5275,x:30490,y:32705,varname:node_5275,prsc:2,blmd:10,clmp:True|SRC-2828-G,DST-8532-RGB;n:type:ShaderForge.SFN_Blend,id:5735,x:30779,y:32575,varname:node_5735,prsc:2,blmd:10,clmp:True|SRC-5082-OUT,DST-5275-OUT;n:type:ShaderForge.SFN_Blend,id:3271,x:31200,y:32783,varname:node_3271,prsc:2,blmd:10,clmp:True|SRC-9122-OUT,DST-9921-OUT;n:type:ShaderForge.SFN_Blend,id:8919,x:31456,y:32947,varname:node_8919,prsc:2,blmd:10,clmp:True|SRC-3271-OUT,DST-1872-RGB;n:type:ShaderForge.SFN_Color,id:1872,x:31198,y:33074,ptovrint:False,ptlb:OverallColor,ptin:_OverallColor,varname:node_6001,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_OneMinus,id:4884,x:31060,y:33438,varname:node_4884,prsc:2|IN-7499-OUT;n:type:ShaderForge.SFN_Power,id:150,x:31262,y:33438,varname:node_150,prsc:2|VAL-4884-OUT,EXP-2168-OUT;n:type:ShaderForge.SFN_Slider,id:8538,x:30724,y:33598,ptovrint:False,ptlb:RefractionPower,ptin:_RefractionPower,varname:node_4863,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4519565,max:1;n:type:ShaderForge.SFN_OneMinus,id:2168,x:31060,y:33589,varname:node_2168,prsc:2|IN-8538-OUT;n:type:ShaderForge.SFN_Multiply,id:7233,x:32087,y:32470,varname:node_7233,prsc:2|A-9994-OUT,B-805-OUT;n:type:ShaderForge.SFN_Add,id:805,x:31700,y:32757,varname:node_805,prsc:2|A-9122-OUT,B-8919-OUT;n:type:ShaderForge.SFN_OneMinus,id:9122,x:30960,y:32613,varname:node_9122,prsc:2|IN-5735-OUT;n:type:ShaderForge.SFN_ComponentMask,id:203,x:31457,y:33417,varname:node_203,prsc:2,cc1:0,cc2:0,cc3:-1,cc4:-1|IN-150-OUT;n:type:ShaderForge.SFN_Slider,id:9751,x:32618,y:33264,ptovrint:False,ptlb:OutlineWidth,ptin:_OutlineWidth,varname:node_9751,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:837,x:32967,y:33339,ptovrint:False,ptlb:OutlineColor,ptin:_OutlineColor,varname:node_837,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:7042,x:32421,y:32527,varname:node_7042,prsc:2|A-7233-OUT,B-1369-OUT;n:type:ShaderForge.SFN_Blend,id:1369,x:31585,y:32365,varname:node_1369,prsc:2,blmd:10,clmp:True|SRC-354-OUT,DST-2349-RGB;n:type:ShaderForge.SFN_Color,id:2349,x:31985,y:32738,ptovrint:False,ptlb:FresnelColor,ptin:_FresnelColor,varname:node_2349,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:1741,x:32623,y:32650,varname:node_1741,prsc:2|A-7042-OUT,B-9122-OUT;n:type:ShaderForge.SFN_DepthBlend,id:3027,x:32511,y:32863,varname:node_3027,prsc:2|DIST-1566-OUT;n:type:ShaderForge.SFN_Slider,id:1566,x:32129,y:32950,ptovrint:False,ptlb:IntesectionDistance,ptin:_IntesectionDistance,varname:node_1566,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:50;n:type:ShaderForge.SFN_OneMinus,id:2203,x:32855,y:32840,varname:node_2203,prsc:2|IN-3027-OUT;n:type:ShaderForge.SFN_Color,id:3915,x:32895,y:33113,ptovrint:False,ptlb:IntersectionColor,ptin:_IntersectionColor,varname:node_3915,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Blend,id:2653,x:33117,y:32952,varname:node_2653,prsc:2,blmd:10,clmp:True|SRC-2203-OUT,DST-3915-RGB;n:type:ShaderForge.SFN_Add,id:2010,x:33126,y:32701,varname:node_2010,prsc:2|A-1741-OUT,B-2653-OUT;n:type:ShaderForge.SFN_Power,id:9086,x:32696,y:33023,varname:node_9086,prsc:2|VAL-3027-OUT,EXP-2149-OUT;n:type:ShaderForge.SFN_Slider,id:2149,x:32088,y:33275,ptovrint:False,ptlb:IntersectionPower,ptin:_IntersectionPower,varname:node_2149,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:50;proporder:797-7127-2506-8532-6701-7411-7596-5441-2031-6270-2289-2828-1872-8538-9751-837-2349-1566-3915-2149;pass:END;sub:END;*/

Shader "Shader Forge/SH_ShieldShader_01" {
    Properties {
        _TintColor ("FrontColor", Color) = (1,0,0,1)
        _Fresnel ("Fresnel", Range(0, 1)) = 0.2051282
        _BackColor ("BackColor", Color) = (0.2394572,0.6716322,0.7573529,1)
        _HexagonColor ("HexagonColor", Color) = (0.5294118,0.5294118,0.5294118,1)
        _BaseTexture_copy ("Base Texture_copy", 2D) = "white" {}
        _node_3671 ("node_3671", 2D) = "white" {}
        _node_9198 ("node_9198", 2D) = "white" {}
        _node_7799 ("node_7799", 2D) = "white" {}
        _node_175 ("node_175", 2D) = "white" {}
        _CubePatternColor ("CubePatternColor", Color) = (0.5,0.5,0.5,1)
        _CubesPatternInensity ("CubesPatternInensity", Range(0, 1)) = 0.8810127
        _BaseTexture_copy_copy ("Base Texture_copy_copy", 2D) = "white" {}
        _OverallColor ("OverallColor", Color) = (0.5,0.5,0.5,1)
        _RefractionPower ("RefractionPower", Range(0, 1)) = 0.4519565
        _OutlineWidth ("OutlineWidth", Range(0, 1)) = 0
        _OutlineColor ("OutlineColor", Color) = (0.5,0.5,0.5,1)
        _FresnelColor ("FresnelColor", Color) = (0.5,0.5,0.5,1)
        _IntesectionDistance ("IntesectionDistance", Range(0, 50)) = 0
        _IntersectionColor ("IntersectionColor", Color) = (0.5,0.5,0.5,1)
        _IntersectionPower ("IntersectionPower", Range(0, 50)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent+1"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
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
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform float4 _TintColor;
            uniform float _Fresnel;
            uniform float4 _BackColor;
            uniform float4 _HexagonColor;
            uniform sampler2D _BaseTexture_copy; uniform float4 _BaseTexture_copy_ST;
            uniform sampler2D _node_3671; uniform float4 _node_3671_ST;
            uniform sampler2D _node_9198; uniform float4 _node_9198_ST;
            uniform sampler2D _node_7799; uniform float4 _node_7799_ST;
            uniform sampler2D _node_175; uniform float4 _node_175_ST;
            uniform float4 _CubePatternColor;
            uniform float _CubesPatternInensity;
            uniform sampler2D _BaseTexture_copy_copy; uniform float4 _BaseTexture_copy_copy_ST;
            uniform float4 _OverallColor;
            uniform float _RefractionPower;
            uniform float4 _FresnelColor;
            uniform float _IntesectionDistance;
            uniform float4 _IntersectionColor;
            uniform float _IntersectionPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_6652 = _Time + _TimeEditor;
                float2 node_677 = (i.uv0+node_6652.g*float2(-0.2,0.1));
                float4 _node_3671_var = tex2D(_node_3671,TRANSFORM_TEX(node_677, _node_3671));
                float2 node_9667 = (i.uv0+node_6652.g*float2(0.1,0.2));
                float4 _node_9198_var = tex2D(_node_9198,TRANSFORM_TEX(node_9667, _node_9198));
                float node_1438 = (_node_3671_var.r+_node_9198_var.r);
                float2 node_9993 = (i.uv0+node_6652.g*float2(-0.2,-0.3));
                float4 _node_7799_var = tex2D(_node_7799,TRANSFORM_TEX(node_9993, _node_7799));
                float2 node_5297 = (i.uv0+node_6652.g*float2(0.3,-0.1));
                float4 _node_175_var = tex2D(_node_175,TRANSFORM_TEX(node_5297, _node_175));
                float node_5154 = (_node_7799_var.r+_node_175_var.r);
                float node_3373 = (node_1438*node_5154);
                float node_7499 = (((node_3373+node_1438)*(node_3373+node_5154))+_CubesPatternInensity);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + pow((1.0 - node_7499),(1.0 - _RefractionPower)).rr;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float node_3027 = saturate((sceneZ-partZ)/_IntesectionDistance);
                float node_9086 = pow(node_3027,_IntersectionPower);
                clip(node_9086 - 0.5);
////// Lighting:
////// Emissive:
                float node_354 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_Fresnel);
                float2 node_4395 = (i.uv0+node_6652.g*float2(0,0.1));
                float4 _BaseTexture_copy_var = tex2D(_BaseTexture_copy,TRANSFORM_TEX(node_4395, _BaseTexture_copy));
                float2 node_916 = (i.uv0+node_6652.g*float2(0,0.03));
                float4 _BaseTexture_copy_copy_var = tex2D(_BaseTexture_copy_copy,TRANSFORM_TEX(node_916, _BaseTexture_copy_copy));
                float3 node_9122 = (1.0 - saturate(( saturate(( _HexagonColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_HexagonColor.rgb-0.5))*(1.0-_BaseTexture_copy_copy_var.g)) : (2.0*_HexagonColor.rgb*_BaseTexture_copy_copy_var.g) )) > 0.5 ? (1.0-(1.0-2.0*(saturate(( _HexagonColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_HexagonColor.rgb-0.5))*(1.0-_BaseTexture_copy_copy_var.g)) : (2.0*_HexagonColor.rgb*_BaseTexture_copy_copy_var.g) ))-0.5))*(1.0-saturate(( _HexagonColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_HexagonColor.rgb-0.5))*(1.0-_BaseTexture_copy_var.g)) : (2.0*_HexagonColor.rgb*_BaseTexture_copy_var.g) )))) : (2.0*saturate(( _HexagonColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_HexagonColor.rgb-0.5))*(1.0-_BaseTexture_copy_copy_var.g)) : (2.0*_HexagonColor.rgb*_BaseTexture_copy_copy_var.g) ))*saturate(( _HexagonColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_HexagonColor.rgb-0.5))*(1.0-_BaseTexture_copy_var.g)) : (2.0*_HexagonColor.rgb*_BaseTexture_copy_var.g) ))) )));
                float3 emissive = ((((clamp(saturate((1.0-(1.0-lerp(_TintColor.rgb,_BackColor.rgb,i.vertexColor.rgb))*(1.0-node_354))),0.05,1.0)*(node_9122+saturate(( _OverallColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_OverallColor.rgb-0.5))*(1.0-saturate(( saturate(( _CubePatternColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_CubePatternColor.rgb-0.5))*(1.0-node_7499)) : (2.0*_CubePatternColor.rgb*node_7499) )) > 0.5 ? (1.0-(1.0-2.0*(saturate(( _CubePatternColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_CubePatternColor.rgb-0.5))*(1.0-node_7499)) : (2.0*_CubePatternColor.rgb*node_7499) ))-0.5))*(1.0-node_9122)) : (2.0*saturate(( _CubePatternColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_CubePatternColor.rgb-0.5))*(1.0-node_7499)) : (2.0*_CubePatternColor.rgb*node_7499) ))*node_9122) )))) : (2.0*_OverallColor.rgb*saturate(( saturate(( _CubePatternColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_CubePatternColor.rgb-0.5))*(1.0-node_7499)) : (2.0*_CubePatternColor.rgb*node_7499) )) > 0.5 ? (1.0-(1.0-2.0*(saturate(( _CubePatternColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_CubePatternColor.rgb-0.5))*(1.0-node_7499)) : (2.0*_CubePatternColor.rgb*node_7499) ))-0.5))*(1.0-node_9122)) : (2.0*saturate(( _CubePatternColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_CubePatternColor.rgb-0.5))*(1.0-node_7499)) : (2.0*_CubePatternColor.rgb*node_7499) ))*node_9122) ))) ))))+saturate(( _FresnelColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_FresnelColor.rgb-0.5))*(1.0-node_354)) : (2.0*_FresnelColor.rgb*node_354) )))+node_9122)+saturate(( _IntersectionColor.rgb > 0.5 ? (1.0-(1.0-2.0*(_IntersectionColor.rgb-0.5))*(1.0-(1.0 - node_3027))) : (2.0*_IntersectionColor.rgb*(1.0 - node_3027)) )));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,node_9086),1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
