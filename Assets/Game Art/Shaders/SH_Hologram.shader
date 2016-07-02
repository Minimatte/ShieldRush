// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:2,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33235,y:32695,varname:node_4795,prsc:2|emission-3829-OUT,alpha-5079-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31521,y:32614,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:483541809c6054b4dad91ee33c88016a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2393,x:32042,y:32826,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-1628-OUT,D-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:31521,y:32795,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:31521,y:33001,ptovrint:True,ptlb:Color1,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6764706,c2:0.2984429,c3:0.2984429,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:31802,y:33146,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Slider,id:5079,x:32253,y:33248,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_5079,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Multiply,id:3829,x:32785,y:32823,varname:node_3829,prsc:2|A-4702-OUT,B-5079-OUT;n:type:ShaderForge.SFN_Tex2d,id:5370,x:31273,y:32238,ptovrint:False,ptlb:TilingTexture,ptin:_TilingTexture,varname:node_5370,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9078-UVOUT;n:type:ShaderForge.SFN_Panner,id:9078,x:31093,y:32245,varname:node_9078,prsc:2,spu:0,spv:0.2|UVIN-2404-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2404,x:30908,y:32245,varname:node_2404,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:9925,x:31093,y:32416,varname:node_9925,prsc:2,spu:0,spv:0.05|UVIN-7587-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8713,x:31273,y:32431,ptovrint:False,ptlb:TilingTexture2,ptin:_TilingTexture2,varname:node_8713,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9925-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7587,x:30908,y:32416,varname:node_7587,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:6576,x:31557,y:32365,varname:node_6576,prsc:2|A-5370-R,B-8713-G;n:type:ShaderForge.SFN_Desaturate,id:3091,x:32085,y:32524,varname:node_3091,prsc:2|COL-6576-OUT,DES-2873-OUT;n:type:ShaderForge.SFN_Vector1,id:2873,x:31895,y:32558,varname:node_2873,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:4985,x:32383,y:32641,varname:node_4985,prsc:2|A-3091-OUT,B-2393-OUT;n:type:ShaderForge.SFN_Add,id:4702,x:32466,y:32907,varname:node_4702,prsc:2|A-4985-OUT,B-2393-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4272,x:32757,y:32982,varname:node_4272,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-4702-OUT;n:type:ShaderForge.SFN_Multiply,id:9595,x:32975,y:33037,varname:node_9595,prsc:2|A-4272-OUT,B-5079-OUT;n:type:ShaderForge.SFN_Lerp,id:1628,x:31802,y:33022,varname:node_1628,prsc:2|A-797-RGB,B-5608-RGB,T-6074-RGB;n:type:ShaderForge.SFN_Color,id:5608,x:31521,y:33190,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:node_5608,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3612575,c2:0.3088235,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7796,x:33045,y:32738,varname:node_7796,prsc:2|A-3829-OUT,B-8347-OUT;n:type:ShaderForge.SFN_Slider,id:8347,x:32706,y:32730,ptovrint:False,ptlb:EmiPwer,ptin:_EmiPwer,varname:node_8347,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:8402,x:32980,y:32642,varname:node_8402,prsc:2,v1:1;proporder:6074-797-5079-5370-8713-5608-8347;pass:END;sub:END;*/

Shader "Shader Forge/SH_Hologram" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color1", Color) = (0.6764706,0.2984429,0.2984429,1)
        _Opacity ("Opacity", Range(0, 2)) = 0
        _TilingTexture ("TilingTexture", 2D) = "white" {}
        _TilingTexture2 ("TilingTexture2", 2D) = "white" {}
        _Color2 ("Color2", Color) = (0.3612575,0.3088235,1,1)
        _EmiPwer ("EmiPwer", Range(0, 1)) = 0
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
            Blend SrcColor One
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
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _Opacity;
            uniform sampler2D _TilingTexture; uniform float4 _TilingTexture_ST;
            uniform sampler2D _TilingTexture2; uniform float4 _TilingTexture2_ST;
            uniform float4 _Color2;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_1307 = _Time + _TimeEditor;
                float2 node_9078 = (i.uv0+node_1307.g*float2(0,0.2));
                float4 _TilingTexture_var = tex2D(_TilingTexture,TRANSFORM_TEX(node_9078, _TilingTexture));
                float2 node_9925 = (i.uv0+node_1307.g*float2(0,0.05));
                float4 _TilingTexture2_var = tex2D(_TilingTexture2,TRANSFORM_TEX(node_9925, _TilingTexture2));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_2393 = (_MainTex_var.rgb*i.vertexColor.rgb*lerp(_TintColor.rgb,_Color2.rgb,_MainTex_var.rgb)*2.0);
                float3 node_4702 = ((lerp((_TilingTexture_var.r+_TilingTexture2_var.g),dot((_TilingTexture_var.r+_TilingTexture2_var.g),float3(0.3,0.59,0.11)),1.0)*node_2393)+node_2393);
                float3 node_3829 = (node_4702*_Opacity);
                float3 emissive = node_3829;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,_Opacity);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
