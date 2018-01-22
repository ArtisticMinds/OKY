xof 0303txt 0032

// DirectX 9.0 file
// Creator: Ultimate Unwrap3D Pro v3.22
// Website: http://www.unwrap3d.com
// Time: Fri Mar 12 17:00:33 2010

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

Frame rock_009_LOD3 {
   FrameTransformMatrix {
    1.000000, 0.000000, 0.000000, 0.000000,
    0.000000, 1.000000, 0.000000, 0.000000,
    0.000000, 0.000000, 1.000000, 0.000000,
    0.000000, 0.000000, 0.000000, 1.000000;;
   }

   Mesh rock_009_LOD3 {
    60;
    2.277221; 0.000000; 3.031427;,
    2.021381; 0.000000; -0.179178;,
    1.466832; 1.161788; 1.757729;,
    -0.465272; 9.931932; -6.578009;,
    -1.750733; 6.755650; -10.846667;,
    -2.575509; 8.642562; -7.460097;,
    -0.465272; 9.931932; -6.578009;,
    -2.920016; 7.988118; -2.624301;,
    -2.237075; 7.081990; -3.690715;,
    -0.213683; 9.768354; -0.085505;,
    2.728485; 7.782525; 0.453383;,
    2.168311; 9.224135; -1.687488;,
    0.211308; 6.530508; -3.650579;,
    -1.218567; 5.064062; -1.562580;,
    -1.698257; 1.402996; -0.562789;,
    -0.149934; 4.445835; -1.928065;,
    0.815021; 0.995112; -1.071070;,
    -0.470557; 2.381961; -11.496472;,
    -1.009548; 4.676444; -9.222878;,
    0.022320; 4.596291; -12.281108;,
    0.159243; 2.781290; -9.104053;,
    1.470529; 5.549408; -7.938572;,
    1.427804; 2.169234; -10.097866;,
    3.032307; 0.000000; -12.095107;,
    1.062482; 2.217322; -11.208594;,
    -1.257411; 0.000000; -8.944293;,
    1.810854; 0.000000; -8.976217;,
    -0.909492; 2.181035; -9.745435;,
    1.810854; 0.000000; -8.976217;,
    0.159243; 2.781290; -9.104053;,
    -0.302041; 7.291719; -11.645839;,
    1.434904; 7.198567; -10.873606;,
    -0.302041; 7.291719; -11.645839;,
    2.053460; 4.393953; 1.290285;,
    1.470529; 5.549408; -7.938572;,
    3.404815; 8.576302; -4.878370;,
    3.540189; 7.214424; -2.981891;,
    0.211308; 6.530508; -3.650579;,
    1.864936; 5.223541; -0.943700;,
    -2.265500; 2.027282; 1.737164;,
    0.159194; 0.000000; 4.478307;,
    -0.279920; 3.852771; 2.250066;,
    -2.206469; 2.717751; 1.057959;,
    0.159194; 0.000000; 4.478307;,
    -2.471517; 4.963131; 1.096150;,
    0.815021; 0.995112; -1.071070;,
    -0.149934; 4.445835; -1.928065;,
    1.951625; 4.370802; -10.999374;,
    0.022320; 4.596291; -12.281108;,
    -1.825221; 1.332536; 0.753048;,
    -3.594873; 0.000000; 1.757846;,
    0.488928; 0.000000; -13.360327;,
    -0.470557; 2.381961; -11.496472;,
    -1.218567; 5.064062; -1.562580;,
    -2.797769; 0.000000; -1.353270;,
    -0.279920; 3.852771; 2.250066;,
    -2.761206; 0.000000; -11.898185;,
    0.488928; 0.000000; -13.360327;,
    -0.406375; 8.363294; 1.531080;,
    -0.406375; 8.363294; 1.531080;;
    79;
    3;0, 1, 2;,
    3;3, 4, 5;,
    3;6, 5, 7;,
    3;5, 8, 7;,
    3;9, 10, 11;,
    3;8, 12, 13;,
    3;14, 15, 16;,
    3;17, 18, 4;,
    3;4, 19, 17;,
    3;18, 20, 21;,
    3;22, 23, 24;,
    3;25, 26, 20;,
    3;25, 20, 27;,
    3;18, 27, 20;,
    3;27, 18, 17;,
    3;28, 22, 29;,
    3;4, 3, 30;,
    3;31, 32, 6;,
    3;28, 23, 22;,
    3;33, 0, 2;,
    3;34, 35, 36;,
    3;37, 34, 36;,
    3;35, 34, 31;,
    3;9, 11, 7;,
    3;10, 38, 36;,
    3;11, 10, 36;,
    3;39, 40, 41;,
    3;39, 41, 42;,
    3;0, 33, 43;,
    3;42, 41, 44;,
    3;13, 15, 14;,
    3;38, 45, 46;,
    3;33, 2, 38;,
    3;6, 7, 11;,
    3;35, 6, 11;,
    3;47, 31, 34;,
    3;47, 48, 31;,
    3;42, 49, 39;,
    3;39, 49, 50;,
    3;24, 51, 52;,
    3;24, 23, 51;,
    3;38, 46, 53;,
    3;36, 38, 53;,
    3;36, 53, 37;,
    3;38, 2, 45;,
    3;1, 45, 2;,
    3;22, 24, 47;,
    3;24, 52, 48;,
    3;24, 48, 47;,
    3;34, 29, 22;,
    3;22, 47, 34;,
    3;36, 35, 11;,
    3;54, 50, 49;,
    3;43, 33, 55;,
    3;50, 40, 39;,
    3;56, 27, 17;,
    3;27, 56, 25;,
    3;17, 57, 56;,
    3;13, 44, 8;,
    3;14, 42, 44;,
    3;14, 44, 13;,
    3;14, 49, 42;,
    3;54, 49, 14;,
    3;14, 16, 54;,
    3;31, 48, 32;,
    3;19, 4, 30;,
    3;18, 21, 12;,
    3;18, 12, 8;,
    3;4, 18, 8;,
    3;4, 8, 5;,
    3;7, 58, 9;,
    3;10, 9, 59;,
    3;31, 6, 35;,
    3;7, 44, 58;,
    3;8, 44, 7;,
    3;44, 41, 58;,
    3;59, 55, 33;,
    3;10, 59, 33;,
    3;33, 38, 10;;

   MeshTextureCoords {
    60;
    0.929106; 0.173909;,
    0.853135; 0.142675;,
    0.884890; 0.192302;,
    0.381635; 0.559677;,
    0.292726; 0.681170;,
    0.454706; 0.643533;,
    0.480559; 0.556712;,
    0.646505; 0.673737;,
    0.597769; 0.727589;,
    0.770136; 0.543552;,
    0.755168; 0.398362;,
    0.681628; 0.466887;,
    0.590105; 0.828326;,
    0.696120; 0.832858;,
    0.793562; 0.925661;,
    0.703886; 0.882925;,
    0.742857; 0.960396;,
    0.160395; 0.822381;,
    0.320169; 0.787185;,
    0.177481; 0.723226;,
    0.298346; 0.889718;,
    0.396728; 0.849871;,
    0.229729; 0.178924;,
    0.089730; 0.098035;,
    0.144435; 0.217610;,
    0.205650; 0.970991;,
    0.268508; 0.981453;,
    0.228773; 0.885667;,
    0.222589; 0.042193;,
    0.363234; 0.165781;,
    0.251317; 0.627200;,
    0.298891; 0.419769;,
    0.243295; 0.469114;,
    0.834094; 0.294647;,
    0.399231; 0.303329;,
    0.563660; 0.415572;,
    0.632818; 0.364843;,
    0.576335; 0.240672;,
    0.732367; 0.279914;,
    0.871132; 0.896739;,
    0.980419; 0.894372;,
    0.911797; 0.801810;,
    0.838336; 0.872913;,
    0.972060; 0.217898;,
    0.809081; 0.775264;,
    0.804587; 0.140820;,
    0.717645; 0.181106;,
    0.250096; 0.311776;,
    0.163296; 0.375448;,
    0.829469; 0.920532;,
    0.871211; 0.961569;,
    0.024239; 0.181526;,
    0.092816; 0.259089;,
    0.685783; 0.208708;,
    0.806737; 0.969007;,
    0.920830; 0.312136;,
    0.114295; 0.924396;,
    0.060476; 0.840640;,
    0.852653; 0.637540;,
    0.857849; 0.442418;;
   }

   MeshMaterialList {
    1;
    79;
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

    Material lambert18SG_Smoothing {
     1.000000; 1.000000; 1.000000; 1.000000;;
     128.000000;
     0.050000; 0.050000; 0.050000;;
     0.000000; 0.000000; 0.000000;;

     TextureFilename {
      "rock_009_C.tga";
     }
    }

   }
  }
}
