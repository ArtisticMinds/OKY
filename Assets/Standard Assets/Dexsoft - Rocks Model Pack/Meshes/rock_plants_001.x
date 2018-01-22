xof 0303txt 0032

// DirectX 9.0 file
// Creator: Ultimate Unwrap3D Pro v3.22
// Website: http://www.unwrap3d.com
// Time: Fri Mar 12 17:21:31 2010

// Start of Templates

template VertexDuplicationIndices {
 <b8d65549-d7c9-4995-89cf-53a9a8b031e3>
 DWORD nIndices;
 DWORD nOriginalVertices;
 array DWORD indices[nIndices];
}

template FVFData {
 <b6e70a0e-8ef9-4e83-94ad-ecc8b0c04897>
 DWORD dwFVF;
 DWORD nDWords;
 array DWORD data[nDWords];
}

template Header {
 <3D82AB43-62DA-11cf-AB39-0020AF71E433>
 WORD major;
 WORD minor;
 DWORD flags;
}

template Vector {
 <3D82AB5E-62DA-11cf-AB39-0020AF71E433>
 FLOAT x;
 FLOAT y;
 FLOAT z;
}

template Coords2d {
 <F6F23F44-7686-11cf-8F52-0040333594A3>
 FLOAT u;
 FLOAT v;
}

template Matrix4x4 {
 <F6F23F45-7686-11cf-8F52-0040333594A3>
 array FLOAT matrix[16];
}

template ColorRGBA {
 <35FF44E0-6C7C-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
 FLOAT alpha;
}

template ColorRGB {
 <D3E16E81-7835-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
}

template IndexedColor {
 <1630B820-7842-11cf-8F52-0040333594A3>
 DWORD index;
 ColorRGBA indexColor;
}

template Material {
 <3D82AB4D-62DA-11cf-AB39-0020AF71E433>
 ColorRGBA faceColor;
 FLOAT power;
 ColorRGB specularColor;
 ColorRGB emissiveColor;
 [...]
}

template TextureFilename {
 <A42790E1-7810-11cf-8F52-0040333594A3>
 STRING filename;
}

template MeshFace {
 <3D82AB5F-62DA-11cf-AB39-0020AF71E433>
 DWORD nFaceVertexIndices;
 array DWORD faceVertexIndices[nFaceVertexIndices];
}

template MeshTextureCoords {
 <F6F23F40-7686-11cf-8F52-0040333594A3>
 DWORD nTextureCoords;
 array Coords2d textureCoords[nTextureCoords];
}

template MeshMaterialList {
 <F6F23F42-7686-11cf-8F52-0040333594A3>
 DWORD nMaterials;
 DWORD nFaceIndexes;
 array DWORD faceIndexes[nFaceIndexes];
 [Material]
}

template MeshNormals {
 <F6F23F43-7686-11cf-8F52-0040333594A3>
 DWORD nNormals;
 array Vector normals[nNormals];
 DWORD nFaceNormals;
 array MeshFace faceNormals[nFaceNormals];
}

template MeshVertexColors {
 <1630B821-7842-11cf-8F52-0040333594A3>
 DWORD nVertexColors;
 array IndexedColor vertexColors[nVertexColors];
}

template Mesh {
 <3D82AB44-62DA-11cf-AB39-0020AF71E433>
 DWORD nVertices;
 array Vector vertices[nVertices];
 DWORD nFaces;
 array MeshFace faces[nFaces];
 [...]
}

template FrameTransformMatrix {
 <F6F23F41-7686-11cf-8F52-0040333594A3>
 Matrix4x4 frameMatrix;
}

template Frame {
 <3D82AB46-62DA-11cf-AB39-0020AF71E433>
 [...]
}

template FloatKeys {
 <10DD46A9-775B-11cf-8F52-0040333594A3>
 DWORD nValues;
 array FLOAT values[nValues];
}

template TimedFloatKeys {
 <F406B180-7B3B-11cf-8F52-0040333594A3>
 DWORD time;
 FloatKeys tfkeys;
}

template AnimationKey {
 <10DD46A8-775B-11cf-8F52-0040333594A3>
 DWORD keyType;
 DWORD nKeys;
 array TimedFloatKeys keys[nKeys];
}

template AnimationOptions {
 <E2BF56C0-840F-11cf-8F52-0040333594A3>
 DWORD openclosed;
 DWORD positionquality;
}

template Animation {
 <3D82AB4F-62DA-11cf-AB39-0020AF71E433>
 [...]
}

template AnimationSet {
 <3D82AB50-62DA-11cf-AB39-0020AF71E433>
 [Animation]
}

template XSkinMeshHeader {
 <3CF169CE-FF7C-44ab-93C0-F78F62D172E2>
 WORD nMaxSkinWeightsPerVertex;
 WORD nMaxSkinWeightsPerFace;
 WORD nBones;
}

template SkinWeights {
 <6F0D123B-BAD2-4167-A0D0-80224F25FABB>
 STRING transformNodeName;
 DWORD nWeights;
 array DWORD vertexIndices[nWeights];
 array FLOAT weights[nWeights];
 Matrix4x4 matrixOffset;
}

template AnimTicksPerSecond {
 <9E415A43-7BA6-4a73-8743-B73D47E88476>
 DWORD AnimTicksPerSecond;
}

AnimTicksPerSecond {
 4800;
}

// Start of Frames

Frame rock_plants_001 {
   FrameTransformMatrix {
    1.000000, 0.000000, 0.000000, 0.000000,
    0.000000, 1.000000, 0.000000, 0.000000,
    0.000000, 0.000000, 1.000000, 0.000000,
    0.000000, 0.000000, 0.000000, 1.000000;;
   }

   Mesh rock_plants_001 {
    117;
    1.069394; 0.695310; 1.661836;,
    -0.157626; 2.169233; 0.856914;,
    -0.186888; 0.638667; 0.881875;,
    1.106115; 2.161338; 1.628496;,
    -0.968969; 0.735288; -0.411670;,
    -0.928426; 2.168233; -0.449297;,
    1.414000; -0.702981; 1.281924;,
    0.157717; -0.759623; 0.501963;,
    -0.624363; -0.663003; -0.791582;,
    -0.458544; 0.824711; -0.065303;,
    -1.207129; 2.168707; -0.851992;,
    -1.236937; 0.768628; -0.832832;,
    -0.420040; 2.165749; -0.089873;,
    -1.472676; 0.852515; -1.938701;,
    -1.429714; 2.163289; -1.966035;,
    -0.060542; -0.454547; -0.312891;,
    -0.838936; -0.510630; -1.080410;,
    -1.074674; -0.426743; -2.186289;,
    1.889925; 0.506569; 1.651387;,
    0.679246; 2.169614; 1.386406;,
    0.653372; 0.445365; 1.416250;,
    1.919828; 2.158153; 1.611035;,
    -0.302965; 0.559048; 0.540752;,
    -0.270997; 2.173385; 0.495020;,
    2.085043; -1.066909; 1.176426;,
    0.848490; -1.128113; 0.941289;,
    -0.107847; -1.014430; 0.065781;,
    -0.116274; 2.068451; 0.675654;,
    -0.159870; 0.697265; 0.393828;,
    -0.130720; 0.537321; 1.476279;,
    -0.077488; 1.850137; 1.748584;,
    0.437487; 0.964556; -0.532061;,
    0.495657; 2.247452; -0.264648;,
    0.290519; -0.579023; 0.237490;,
    0.319670; -0.738967; 1.319951;,
    0.887875; -0.311732; -0.688408;,
    1.006089; 1.975656; 1.173154;,
    0.846374; 0.436710; 0.999746;,
    0.628647; 0.416472; 1.990088;,
    0.791338; 1.889266; 2.160889;,
    1.606652; 0.542763; 0.281426;,
    1.770869; 1.981649; 0.450889;,
    1.115365; -1.023044; 1.041973;,
    0.897637; -1.043282; 2.032314;,
    1.875643; -0.916991; 0.323652;,
    0.447261; 1.034960; -0.875215;,
    -1.019926; 1.938961; -0.749805;,
    -0.532097; 0.635489; -0.593408;,
    -0.019885; 2.282423; -1.036689;,
    -1.554188; 0.309878; -0.960654;,
    -2.010732; 1.528633; -1.124746;,
    0.897749; -0.200511; -1.231416;,
    -0.081609; -0.599981; -0.949600;,
    -1.103700; -0.925592; -1.316855;,
    -0.450128; 0.479392; 0.737549;,
    -0.507193; 1.834662; -0.332754;,
    -0.376335; 0.440421; -0.353857;,
    -0.564329; 1.816129; 0.761201;,
    0.288278; 0.610855; -1.256514;,
    0.182614; 1.918117; -1.231562;,
    0.145285; -0.739361; 0.865342;,
    0.219078; -0.778332; -0.226064;,
    0.883691; -0.607898; -1.128721;,
    1.475751; 0.478234; 2.006465;,
    0.666675; -0.754521; 1.142373;,
    1.404460; -0.827320; 1.823701;,
    0.732275; 0.607795; 1.339189;,
    0.394044; -0.508337; 0.169492;,
    0.468252; 0.768120; 0.345068;,
    0.968087; -1.969972; 0.717305;,
    1.705872; -2.042771; 1.398623;,
    0.695456; -1.723788; -0.255576;,
    1.604360; -0.236125; 0.647344;,
    0.732607; 0.570795; 1.479453;,
    0.864615; -0.497121; 1.277617;,
    1.472969; 0.788088; 0.831807;,
    -0.156725; -0.579131; 1.447148;,
    -0.287801; 0.422681; 1.622695;,
    1.513492; -1.154976; 0.083994;,
    0.773747; -1.415972; 0.714248;,
    -0.247594; -1.497983; 0.883779;,
    0.742808; -0.990771; 1.873955;,
    0.861772; -0.196300; 0.666416;,
    0.717075; -1.255309; 0.903428;,
    0.891381; 0.022989; 1.649189;,
    1.397418; -0.455506; -0.187734;,
    1.246857; -1.446070; 0.030762;,
    1.036916; -1.983682; 2.186289;,
    1.011184; -2.248220; 1.215752;,
    1.540966; -2.438982; 0.343086;,
    0.029471; 1.998655; 1.044971;,
    0.617093; 1.585722; -0.215049;,
    -0.018062; 1.124785; 0.548311;,
    0.646171; 2.438981; 0.319658;,
    1.056754; 0.663203; -0.413389;,
    0.449514; 0.233440; 0.292432;,
    -0.195026; 1.527415; 1.992324;,
    -0.242559; 0.653545; 1.495654;,
    0.225017; -0.237800; 1.239766;,
    -1.543482; 1.378250; -0.558623;,
    -0.463234; 1.974013; -0.946123;,
    -1.235770; 1.371030; -1.317734;,
    -0.799680; 1.948907; -0.198857;,
    -0.642296; 1.049980; -1.832207;,
    0.086779; 1.604066; -1.478506;,
    -2.085043; 0.532520; -0.734668;,
    -1.777329; 0.525299; -1.493779;,
    -1.183857; 0.204249; -2.008242;,
    0.054188; 1.553617; 0.219521;,
    -0.369125; 1.570515; -1.002178;,
    -0.717317; 1.425781; -0.024268;,
    0.391246; 1.684222; -0.717305;,
    -1.261622; 0.877208; -0.374639;,
    -0.930272; 1.000569; -1.290410;,
    -0.112361; 1.078451; 1.106104;,
    -0.883867; 0.950615; 0.862314;,
    -1.428172; 0.402042; 0.511943;;
    104;
    3;0, 1, 2;,
    3;3, 1, 0;,
    3;1, 4, 2;,
    3;1, 5, 4;,
    3;6, 0, 7;,
    3;0, 2, 7;,
    3;4, 8, 7;,
    3;2, 4, 7;,
    3;9, 10, 11;,
    3;12, 10, 9;,
    3;10, 13, 11;,
    3;10, 14, 13;,
    3;15, 9, 16;,
    3;9, 11, 16;,
    3;13, 17, 16;,
    3;11, 13, 16;,
    3;18, 19, 20;,
    3;21, 19, 18;,
    3;19, 22, 20;,
    3;19, 23, 22;,
    3;24, 18, 25;,
    3;18, 20, 25;,
    3;20, 26, 25;,
    3;20, 22, 26;,
    3;27, 28, 29;,
    3;30, 27, 29;,
    3;27, 31, 28;,
    3;27, 32, 31;,
    3;29, 33, 34;,
    3;29, 28, 33;,
    3;28, 35, 33;,
    3;28, 31, 35;,
    3;36, 37, 38;,
    3;39, 36, 38;,
    3;36, 40, 37;,
    3;36, 41, 40;,
    3;38, 42, 43;,
    3;38, 37, 42;,
    3;40, 44, 42;,
    3;37, 40, 42;,
    3;45, 46, 47;,
    3;48, 46, 45;,
    3;47, 46, 49;,
    3;46, 50, 49;,
    3;51, 47, 52;,
    3;45, 47, 51;,
    3;52, 47, 53;,
    3;47, 49, 53;,
    3;54, 55, 56;,
    3;57, 55, 54;,
    3;55, 58, 56;,
    3;55, 59, 58;,
    3;60, 54, 61;,
    3;54, 56, 61;,
    3;56, 62, 61;,
    3;56, 58, 62;,
    3;63, 64, 65;,
    3;63, 66, 64;,
    3;66, 67, 64;,
    3;66, 68, 67;,
    3;65, 69, 70;,
    3;65, 64, 69;,
    3;67, 71, 69;,
    3;64, 67, 69;,
    3;72, 73, 74;,
    3;75, 73, 72;,
    3;74, 73, 76;,
    3;73, 77, 76;,
    3;78, 72, 79;,
    3;72, 74, 79;,
    3;79, 76, 80;,
    3;74, 76, 79;,
    3;81, 82, 83;,
    3;84, 82, 81;,
    3;83, 85, 86;,
    3;82, 85, 83;,
    3;87, 81, 88;,
    3;81, 83, 88;,
    3;88, 83, 89;,
    3;83, 86, 89;,
    3;90, 91, 92;,
    3;90, 93, 91;,
    3;92, 94, 95;,
    3;92, 91, 94;,
    3;96, 90, 97;,
    3;90, 92, 97;,
    3;97, 95, 98;,
    3;97, 92, 95;,
    3;99, 100, 101;,
    3;102, 100, 99;,
    3;101, 100, 103;,
    3;100, 104, 103;,
    3;105, 101, 106;,
    3;99, 101, 105;,
    3;106, 101, 107;,
    3;101, 103, 107;,
    3;108, 109, 110;,
    3;111, 109, 108;,
    3;110, 109, 112;,
    3;109, 113, 112;,
    3;114, 108, 115;,
    3;108, 110, 115;,
    3;115, 110, 116;,
    3;110, 112, 116;;

   MeshTextureCoords {
    117;
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.500000; 0.000000;,
    0.000000; 0.000000;,
    1.000000; 0.000000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.500000; 0.000000;,
    0.000000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.500000; 0.000000;,
    0.000000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 1.000000;,
    1.000000; 0.500000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 1.000000;,
    1.000000; 0.500000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;,
    0.000000; 0.500000;,
    0.500000; 1.000000;,
    0.500000; 0.500000;,
    0.000000; 1.000000;,
    1.000000; 0.500000;,
    1.000000; 1.000000;,
    0.000000; 0.000000;,
    0.500000; 0.000000;,
    1.000000; 0.000000;;
   }

   MeshMaterialList {
    1;
    104;
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0;

    Material lambert20SG_Smoothing {
     1.000000; 1.000000; 1.000000; 1.000000;;
     128.000000;
     0.000000; 0.000000; 0.000000;;
     0.000000; 0.000000; 0.000000;;

     TextureFilename {
      "brunches_02_c.tga";
     }
    }

   }
  }
}
