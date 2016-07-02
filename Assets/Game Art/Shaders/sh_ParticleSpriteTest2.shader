// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-1973-OUT,voffset-236-OUT;n:type:ShaderForge.SFN_Color,id:6219,x:32191,y:32486,ptovrint:False,ptlb:node_6219,ptin:_node_6219,varname:node_6219,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7379313,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:7478,x:32191,y:32661,ptovrint:False,ptlb:node_7478,ptin:_node_7478,varname:node_7478,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.006896496,c3:1,c4:1;n:type:ShaderForge.SFN_ComponentMask,id:9355,x:31355,y:32792,varname:node_9355,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-4618-X;n:type:ShaderForge.SFN_TexCoord,id:6365,x:30899,y:32750,varname:node_6365,prsc:2,uv:0;n:type:ShaderForge.SFN_Lerp,id:1973,x:32428,y:32735,varname:node_1973,prsc:2|A-6219-RGB,B-7478-RGB,T-2167-OUT;n:type:ShaderForge.SFN_Clamp01,id:2167,x:32256,y:32856,varname:node_2167,prsc:2|IN-4536-OUT;n:type:ShaderForge.SFN_Sin,id:5181,x:31925,y:32877,varname:node_5181,prsc:2|IN-6922-OUT;n:type:ShaderForge.SFN_Multiply,id:6922,x:31758,y:32887,varname:node_6922,prsc:2|A-1968-OUT,B-9355-OUT,C-4570-OUT;n:type:ShaderForge.SFN_Vector1,id:1968,x:31537,y:32755,varname:node_1968,prsc:2,v1:2;n:type:ShaderForge.SFN_RemapRange,id:4536,x:32090,y:32877,varname:node_4536,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-5181-OUT;n:type:ShaderForge.SFN_Tau,id:4570,x:31552,y:33065,varname:node_4570,prsc:2;n:type:ShaderForge.SFN_Add,id:9931,x:31519,y:32915,varname:node_9931,prsc:2|A-9355-OUT;n:type:ShaderForge.SFN_Time,id:1708,x:31311,y:32995,varname:node_1708,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:7807,x:32230,y:33083,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector1,id:9232,x:32238,y:33285,varname:node_9232,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:236,x:32443,y:33059,varname:node_236,prsc:2|A-2167-OUT,B-7807-OUT,C-9232-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:4618,x:30945,y:32902,varname:node_4618,prsc:2;proporder:6219-7478;pass:END;sub:END;*/

Shader "Shader Forge/sh_ParticleSpriteTest2" {
    Properties {
        _node_6219 ("node_6219", Color) = (0.7379313,0,1,1)
        _node_7478 ("node_7478", Color) = (0,0.006896496,1,1)
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
            Blend One One
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
            uniform float4 _node_6219;
            uniform float4 _node_7478;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_9355 = mul(unity_ObjectToWorld, v.vertex).r.r;
                float node_2167 = saturate((sin((2.0*node_9355*6.28318530718))*0.5+0.5));
                v.vertex.xyz += (node_2167*v.normal*0.2);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_9355 = i.posWorld.r.r;
                float node_2167 = saturate((sin((2.0*node_9355*6.28318530718))*0.5+0.5));
                float3 emissive = lerp(_node_6219.rgb,_node_7478.rgb,node_2167);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
