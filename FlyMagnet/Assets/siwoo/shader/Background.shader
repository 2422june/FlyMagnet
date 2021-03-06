// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33181,y:32621,varname:node_3138,prsc:2|emission-1402-OUT;n:type:ShaderForge.SFN_Blend,id:2381,x:32549,y:32572,varname:node_2381,prsc:2,blmd:7,clmp:True|SRC-9651-RGB,DST-9651-RGB;n:type:ShaderForge.SFN_Tex2d,id:9651,x:32142,y:32506,ptovrint:False,ptlb:node_9651,ptin:_node_9651,varname:node_9651,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fa519fd7071919644a37191c6c79526a,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Round,id:5451,x:32751,y:32572,varname:node_5451,prsc:2|IN-2381-OUT;n:type:ShaderForge.SFN_Vector1,id:7970,x:32776,y:32479,varname:node_7970,prsc:2,v1:10;n:type:ShaderForge.SFN_Multiply,id:1402,x:32987,y:32572,varname:node_1402,prsc:2|A-7970-OUT,B-5451-OUT;proporder:9651;pass:END;sub:END;*/

Shader "Shader Forge/Background" {
    Properties {
        _node_9651 ("node_9651", 2D) = "bump" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _node_9651; uniform float4 _node_9651_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _node_9651_var = tex2D(_node_9651,TRANSFORM_TEX(i.uv0, _node_9651));
                float3 emissive = (10.0*round(saturate((_node_9651_var.rgb/(1.0-_node_9651_var.rgb)))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
