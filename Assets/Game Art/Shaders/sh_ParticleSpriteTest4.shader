// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32898,y:32770,varname:node_4795,prsc:2|diff-8508-OUT,spec-7029-OUT,normal-9577-RGB,clip-9564-OUT;n:type:ShaderForge.SFN_VertexColor,id:8093,x:32353,y:32964,varname:node_8093,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:2295,x:32353,y:32612,ptovrint:False,ptlb:A,ptin:_A,varname:node_2295,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:19555d7d9d114c7f1100f5ab44295342,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8635,x:32353,y:32791,ptovrint:False,ptlb:B,ptin:_B,varname:node_8635,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:529239097d02f9f42b0ddd436c6fcbb0,ntxv:0,isnm:False|UVIN-4481-OUT;n:type:ShaderForge.SFN_TexCoord,id:6478,x:32000,y:32739,varname:node_6478,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:4481,x:32174,y:32791,varname:node_4481,prsc:2|A-6478-UVOUT,B-508-OUT;n:type:ShaderForge.SFN_Vector1,id:508,x:31985,y:32893,varname:node_508,prsc:2,v1:8;n:type:ShaderForge.SFN_Lerp,id:8508,x:32540,y:32771,varname:node_8508,prsc:2|A-6650-RGB,B-2295-RGB,T-8093-R;n:type:ShaderForge.SFN_Vector1,id:7029,x:32714,y:32805,varname:node_7029,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:9577,x:32334,y:33163,ptovrint:False,ptlb:A_copy,ptin:_A_copy,varname:_A_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4b8d081e9d114c7f1100f5ab44295342,ntxv:3,isnm:True;n:type:ShaderForge.SFN_TexCoord,id:2136,x:31434,y:33756,varname:node_2136,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:9856,x:31612,y:33756,varname:node_9856,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2136-UVOUT;n:type:ShaderForge.SFN_Length,id:7237,x:31755,y:33534,varname:node_7237,prsc:2|IN-6650-RGB;n:type:ShaderForge.SFN_Floor,id:5737,x:31971,y:33578,varname:node_5737,prsc:2|IN-7420-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1955,x:31789,y:33756,varname:node_1955,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9856-OUT;n:type:ShaderForge.SFN_ArcTan2,id:3113,x:31961,y:33756,varname:node_3113,prsc:2,attp:3|A-1955-G,B-1955-R;n:type:ShaderForge.SFN_Power,id:8902,x:32147,y:33756,varname:node_8902,prsc:2|VAL-3113-OUT,EXP-9250-OUT;n:type:ShaderForge.SFN_Vector1,id:9250,x:31961,y:33907,varname:node_9250,prsc:2,v1:5;n:type:ShaderForge.SFN_Vector1,id:477,x:31735,y:33305,varname:node_477,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Power,id:7420,x:31755,y:33377,varname:node_7420,prsc:2|VAL-7237-OUT,EXP-477-OUT;n:type:ShaderForge.SFN_OneMinus,id:2636,x:32021,y:33385,varname:node_2636,prsc:2|IN-7420-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:7462,x:32147,y:33529,varname:node_7462,prsc:2,min:0,max:0.4|IN-7420-OUT;n:type:ShaderForge.SFN_Subtract,id:8,x:32355,y:33467,varname:node_8,prsc:2|A-2636-OUT,B-7462-OUT;n:type:ShaderForge.SFN_OneMinus,id:7568,x:32582,y:33467,varname:node_7568,prsc:2|IN-8-OUT;n:type:ShaderForge.SFN_Tex2d,id:6650,x:32352,y:33756,ptovrint:False,ptlb:node_6650,ptin:_node_6650,varname:node_6650,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f2e02d8286ac04497961e964165d4ed8,ntxv:0,isnm:False|UVIN-9524-UVOUT,MIP-9564-OUT;n:type:ShaderForge.SFN_TexCoord,id:9524,x:32147,y:33884,varname:node_9524,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:4024,x:31280,y:34025,varname:node_4024,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:3648,x:31458,y:34025,varname:node_3648,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4024-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:7437,x:31635,y:34025,varname:node_7437,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-3648-OUT;n:type:ShaderForge.SFN_TexCoord,id:2554,x:31280,y:34194,varname:node_2554,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:9596,x:31458,y:34194,varname:node_9596,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2554-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:4677,x:31635,y:34194,varname:node_4677,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-9596-OUT;n:type:ShaderForge.SFN_Multiply,id:6432,x:31845,y:34025,varname:node_6432,prsc:2|A-7437-OUT,B-7437-OUT;n:type:ShaderForge.SFN_Multiply,id:1871,x:31845,y:34194,varname:node_1871,prsc:2|A-4677-OUT,B-4677-OUT;n:type:ShaderForge.SFN_Multiply,id:2672,x:32028,y:34126,varname:node_2672,prsc:2|A-6432-OUT,B-1871-OUT;n:type:ShaderForge.SFN_Power,id:3179,x:32223,y:34126,varname:node_3179,prsc:2|VAL-2672-OUT,EXP-5191-OUT;n:type:ShaderForge.SFN_Vector1,id:3515,x:32028,y:34255,varname:node_3515,prsc:2,v1:5;n:type:ShaderForge.SFN_OneMinus,id:3642,x:32424,y:34126,varname:node_3642,prsc:2|IN-3179-OUT;n:type:ShaderForge.SFN_Floor,id:9564,x:32664,y:34126,varname:node_9564,prsc:2|IN-3642-OUT;n:type:ShaderForge.SFN_Slider,id:5191,x:32013,y:34440,ptovrint:False,ptlb:node_5191,ptin:_node_5191,varname:node_5191,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:8,max:8;proporder:2295-8635-9577-6650-5191;pass:END;sub:END;*/

Shader "Shader Forge/sh_ParticleSpriteTest4" {
    Properties {
        _A ("A", 2D) = "white" {}
        _B ("B", 2D) = "white" {}
        _A_copy ("A_copy", 2D) = "bump" {}
        _node_6650 ("node_6650", 2D) = "white" {}
        _node_5191 ("node_5191", Range(0, 8)) = 8
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _A; uniform float4 _A_ST;
            uniform sampler2D _A_copy; uniform float4 _A_copy_ST;
            uniform sampler2D _node_6650; uniform float4 _node_6650_ST;
            uniform float _node_5191;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _A_copy_var = UnpackNormal(tex2D(_A_copy,TRANSFORM_TEX(i.uv0, _A_copy)));
                float3 normalLocal = _A_copy_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float node_7437 = (i.uv0*2.0+-1.0).g;
                float node_4677 = (i.uv0*2.0+-1.0).r;
                float node_9564 = floor((1.0 - pow(((node_7437*node_7437)*(node_4677*node_4677)),_node_5191)));
                clip(node_9564 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_7029 = 1.0;
                float3 specularColor = float3(node_7029,node_7029,node_7029);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _node_6650_var = tex2Dlod(_node_6650,float4(TRANSFORM_TEX(i.uv0, _node_6650),0.0,node_9564));
                float4 _A_var = tex2D(_A,TRANSFORM_TEX(i.uv0, _A));
                float3 diffuseColor = lerp(_node_6650_var.rgb,_A_var.rgb,i.vertexColor.r);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _A; uniform float4 _A_ST;
            uniform sampler2D _A_copy; uniform float4 _A_copy_ST;
            uniform sampler2D _node_6650; uniform float4 _node_6650_ST;
            uniform float _node_5191;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _A_copy_var = UnpackNormal(tex2D(_A_copy,TRANSFORM_TEX(i.uv0, _A_copy)));
                float3 normalLocal = _A_copy_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float node_7437 = (i.uv0*2.0+-1.0).g;
                float node_4677 = (i.uv0*2.0+-1.0).r;
                float node_9564 = floor((1.0 - pow(((node_7437*node_7437)*(node_4677*node_4677)),_node_5191)));
                clip(node_9564 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_7029 = 1.0;
                float3 specularColor = float3(node_7029,node_7029,node_7029);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _node_6650_var = tex2Dlod(_node_6650,float4(TRANSFORM_TEX(i.uv0, _node_6650),0.0,node_9564));
                float4 _A_var = tex2D(_A,TRANSFORM_TEX(i.uv0, _A));
                float3 diffuseColor = lerp(_node_6650_var.rgb,_A_var.rgb,i.vertexColor.r);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
