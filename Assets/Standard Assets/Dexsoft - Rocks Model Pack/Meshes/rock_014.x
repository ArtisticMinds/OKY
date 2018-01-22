xof 0303txt 0032

// DirectX 9.0 file
// Creator: Ultimate Unwrap3D Pro v3.22
// Website: http://www.unwrap3d.com
// Time: Fri Mar 12 17:18:03 2010

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

Frame rock_014 {
   FrameTransformMatrix {
    1.000000, 0.000000, 0.000000, 0.000000,
    0.000000, 1.000000, 0.000000, 0.000000,
    0.000000, 0.000000, 1.000000, 0.000000,
    0.000000, 0.000000, 0.000000, 1.000000;;
   }

   Mesh rock_014 {
    324;
    0.863298; 0.075500; -0.977978;,
    0.942085; 0.076846; -0.856483;,
    0.960866; 0.000000; -0.845013;,
    0.893491; 0.000000; -0.986351;,
    0.665940; 0.260426; -0.875290;,
    0.721858; 0.205069; -0.805189;,
    0.818210; 0.188492; -0.864341;,
    0.790853; 0.188492; -0.941395;,
    0.311396; 0.107966; -0.636537;,
    0.254574; 0.000000; -0.600196;,
    0.423561; 0.000000; -0.499561;,
    0.457068; 0.126490; -0.548702;,
    0.644781; 0.128812; -1.062819;,
    0.786354; 0.089937; -1.083066;,
    0.646880; 0.000000; -1.144070;,
    0.797005; 0.000000; -1.117000;,
    0.802142; 0.107584; -0.762672;,
    0.830544; 0.000000; -0.731126;,
    0.960866; 0.000000; -0.845013;,
    0.471284; 0.227422; -0.663343;,
    0.408976; 0.227422; -0.710765;,
    0.617699; 0.202363; -0.985444;,
    0.724123; 0.187603; -0.983540;,
    0.576247; 0.227422; -0.690348;,
    0.581505; 0.117529; -0.601251;,
    0.592291; 0.000000; -0.578352;,
    0.423561; 0.000000; -0.499561;,
    0.267752; 0.089937; -0.796341;,
    0.374682; 0.000000; -0.978154;,
    0.202643; 0.000000; -0.796358;,
    0.404944; 0.128812; -0.943264;,
    0.395561; 0.227422; -0.813088;,
    0.465883; 0.227422; -0.915269;,
    0.528725; 0.260426; -0.776681;,
    0.202643; 0.000000; -0.796358;,
    0.797005; 0.000000; -1.117000;,
    0.181613; 0.095132; 0.254259;,
    0.009235; 0.096828; 0.299658;,
    0.158530; 0.000000; 0.278524;,
    -0.010720; 0.000000; 0.318004;,
    0.118918; 0.328144; 0.008024;,
    0.010142; 0.258392; 0.010930;,
    0.056425; 0.237505; 0.189596;,
    0.159483; 0.237505; 0.171687;,
    -0.194830; 0.159380; -0.285021;,
    -0.089339; 0.000000; -0.470687;,
    -0.244572; 0.000000; -0.327919;,
    -0.021848; 0.136040; -0.387349;,
    0.392283; 0.162306; 0.010941;,
    0.335903; 0.113323; 0.166737;,
    0.454453; 0.000000; 0.026963;,
    0.357834; 0.000000; 0.181102;,
    -0.047310; 0.135559; 0.088472;,
    -0.063258; 0.000000; 0.096910;,
    -0.010720; 0.000000; 0.318004;,
    -0.079893; 0.286558; -0.230443;,
    -0.002202; 0.286558; -0.289939;,
    0.229983; 0.254983; -0.025674;,
    0.232090; 0.236385; 0.106705;,
    -0.079707; 0.286558; -0.114604;,
    -0.219688; 0.148090; -0.138078;,
    -0.251148; 0.000000; -0.129924;,
    -0.244572; 0.000000; -0.327919;,
    0.177455; 0.000000; -0.506707;,
    0.154732; 0.113323; -0.445973;,
    0.222382; 0.000000; -0.261124;,
    0.215156; 0.162306; -0.247495;,
    0.127465; 0.286558; -0.289295;,
    0.161714; 0.286558; -0.186621;,
    0.041055; 0.328144; -0.152655;,
    0.177455; 0.000000; -0.506707;,
    0.454453; 0.000000; 0.026963;,
    1.410396; 0.107674; 0.382008;,
    1.215292; 0.109593; 0.433392;,
    1.384269; 0.000000; 0.409472;,
    1.192706; 0.000000; 0.454156;,
    1.352565; 0.300445; 0.113520;,
    1.084305; 0.237102; 0.204194;,
    1.247028; 0.218134; 0.362393;,
    1.404546; 0.218134; 0.332159;,
    0.984324; 0.180392; -0.228368;,
    1.103722; 0.000000; -0.438512;,
    0.928024; 0.000000; -0.276921;,
    1.180111; 0.153975; -0.344187;,
    1.648839; 0.183704; 0.106612;,
    1.585026; 0.128262; 0.282947;,
    1.719205; 0.000000; 0.124746;,
    1.609848; 0.000000; 0.299206;,
    1.070057; 0.153431; 0.257690;,
    1.052007; 0.000000; 0.267241;,
    1.192706; 0.000000; 0.454156;,
    1.064719; 0.262681; -0.196850;,
    1.186164; 0.262681; -0.281757;,
    1.523165; 0.234006; 0.061493;,
    1.518595; 0.217117; 0.240142;,
    1.097970; 0.262681; -0.038618;,
    0.995956; 0.167613; -0.060246;,
    0.960348; 0.000000; -0.051017;,
    0.928024; 0.000000; -0.276921;,
    1.313503; 0.000000; -0.399746;,
    1.287783; 0.128262; -0.331006;,
    1.456540; 0.000000; -0.201321;,
    1.428477; 0.183704; -0.167819;,
    1.290805; 0.262681; -0.208964;,
    1.409081; 0.262681; -0.133776;,
    1.243781; 0.300445; -0.098899;,
    1.313503; 0.000000; -0.399746;,
    1.719205; 0.000000; 0.124746;,
    -0.471639; 0.095918; -1.578504;,
    -0.288786; 0.097628; -1.561633;,
    -0.459761; 0.000000; -1.598315;,
    -0.263729; 0.000000; -1.565978;,
    -0.498482; 0.330854; -1.426067;,
    -0.385789; 0.260526; -1.421808;,
    -0.382240; 0.239467; -1.500544;,
    -0.482669; 0.239467; -1.523080;,
    -0.267008; 0.000000; -1.119457;,
    -0.489200; 0.137164; -1.126259;,
    -0.489750; 0.000000; -1.079129;,
    -0.296041; 0.160697; -1.160504;,
    -0.711688; 0.163647; -1.504693;,
    -0.635845; 0.114258; -1.588491;,
    -0.796322; 0.000000; -1.544657;,
    -0.664475; 0.000000; -1.610299;,
    -0.285575; 0.136679; -1.443500;,
    -0.232638; 0.000000; -1.443279;,
    -0.263729; 0.000000; -1.565978;,
    -0.407719; 0.288925; -1.222783;,
    -0.500777; 0.288925; -1.212849;,
    -0.648329; 0.257089; -1.453504;,
    -0.573175; 0.238337; -1.508306;,
    -0.364196; 0.288925; -1.290649;,
    -0.266195; 0.149313; -1.250782;,
    -0.234524; 0.000000; -1.245476;,
    -0.267008; 0.000000; -1.119457;,
    -0.688488; 0.114259; -1.179852;,
    -0.807612; 0.000000; -1.322798;,
    -0.733249; 0.000000; -1.145776;,
    -0.749854; 0.163647; -1.321951;,
    -0.618395; 0.288925; -1.254771;,
    -0.678318; 0.288925; -1.340461;,
    -0.488314; 0.330854; -1.307067;,
    -0.733249; 0.000000; -1.145776;,
    -0.664475; 0.000000; -1.610299;,
    -0.531074; 0.068760; 0.214629;,
    -0.628955; 0.069986; 0.369145;,
    -0.513705; 0.000000; 0.238140;,
    -0.634813; 0.000000; 0.394609;,
    -0.692516; 0.237177; 0.092113;,
    -0.745873; 0.186762; 0.191298;,
    -0.658045; 0.171665; 0.245249;,
    -0.589225; 0.171665; 0.168935;,
    -1.036764; 0.098328; -0.092700;,
    -1.090015; 0.000000; -0.123570;,
    -1.140157; 0.000000; 0.103885;,
    -1.081071; 0.115198; 0.104079;,
    -0.511481; 0.117312; -0.050059;,
    -0.449035; 0.081908; 0.072543;,
    -0.411958; 0.000000; 0.060702;,
    -0.429683; 0.000000; -0.100854;,
    -0.764406; 0.097980; 0.295919;,
    -0.634813; 0.000000; 0.394609;,
    -0.787451; 0.000000; 0.343657;,
    -0.962304; 0.207120; 0.043202;,
    -0.933509; 0.207120; -0.047370;,
    -0.596856; 0.184297; -0.025740;,
    -0.567022; 0.170855; 0.077552;,
    -0.820798; 0.207120; 0.087907;,
    -0.908240; 0.107037; 0.150856;,
    -0.927900; 0.000000; 0.176082;,
    -1.140157; 0.000000; 0.103885;,
    -0.909531; 0.000000; -0.300862;,
    -0.890132; 0.081908; -0.238416;,
    -0.676609; 0.000000; -0.254041;,
    -0.702440; 0.117312; -0.202346;,
    -0.835288; 0.207120; -0.126737;,
    -0.712236; 0.207120; -0.125714;,
    -0.831947; 0.237177; 0.024622;,
    -0.909531; 0.000000; -0.300862;,
    -0.411958; 0.000000; 0.060702;,
    -1.158042; 0.086639; -0.624721;,
    -1.252721; 0.088184; -0.731703;,
    -1.180456; 0.000000; -0.635888;,
    -1.270689; 0.000000; -0.741814;,
    -1.051813; 0.298850; -0.709265;,
    -1.151731; 0.235325; -0.800664;,
    -1.174533; 0.216303; -0.719373;,
    -1.122871; 0.216303; -0.653809;,
    -1.020361; 0.000000; -1.009830;,
    -0.897616; 0.123896; -0.871736;,
    -0.880554; 0.000000; -0.931184;,
    -1.023020; 0.145152; -0.969233;,
    -0.941772; 0.147817; -0.526597;,
    -1.048196; 0.103206; -0.537108;,
    -0.924968; 0.000000; -0.482386;,
    -1.046933; 0.000000; -0.519999;,
    -1.216699; 0.123458; -0.825480;,
    -1.227727; 0.000000; -0.834642;,
    -1.270689; 0.000000; -0.741814;,
    -0.941745; 0.260977; -0.841726;,
    -1.005314; 0.260977; -0.883164;,
    -0.988430; 0.232220; -0.641108;,
    -1.058440; 0.215282; -0.616712;,
    -1.067254; 0.260977; -0.862921;,
    -1.111835; 0.134870; -0.960276;,
    -1.020361; 0.000000; -1.009830;,
    -1.129044; 0.000000; -0.979824;,
    -0.752350; 0.000000; -0.759657;,
    -0.794141; 0.103206; -0.764251;,
    -0.865482; 0.000000; -0.687066;,
    -0.875729; 0.147817; -0.689514;,
    -0.889152; 0.260977; -0.755208;,
    -0.930137; 0.260977; -0.714553;,
    -0.997581; 0.298850; -0.789058;,
    -0.752350; 0.000000; -0.759657;,
    -0.924968; 0.000000; -0.482386;,
    -0.420187; 0.105281; 0.916502;,
    -0.424194; 0.114158; 0.788122;,
    -0.440061; 0.000000; 0.892466;,
    -0.438922; 0.000000; 0.766931;,
    -0.168710; 0.277703; 0.916225;,
    -0.192614; 0.230254; 0.734752;,
    -0.367046; 0.210605; 0.820246;,
    -0.373732; 0.205047; 0.922797;,
    0.262931; 0.000000; 0.675587;,
    0.210046; 0.174231; 0.713970;,
    0.368416; 0.000000; 0.803216;,
    0.270559; 0.141916; 0.848385;,
    -0.226666; 0.161959; 1.098841;,
    -0.369487; 0.116687; 1.037881;,
    -0.259571; 0.000000; 1.133354;,
    -0.390485; 0.000000; 1.046263;,
    -0.237743; 0.155557; 0.716566;,
    -0.243998; 0.000000; 0.697484;,
    -0.438922; 0.000000; 0.766931;,
    0.166046; 0.247060; 0.765041;,
    0.215298; 0.241687; 0.850487;,
    -0.159633; 0.210919; 1.026389;,
    -0.316642; 0.198859; 1.004265;,
    0.019235; 0.248793; 0.769641;,
    0.058944; 0.165206; 0.703342;,
    0.056543; 0.000000; 0.672593;,
    0.262931; 0.000000; 0.675587;,
    0.289705; 0.000000; 0.931607;,
    0.235816; 0.115329; 0.913856;,
    0.084119; 0.000000; 1.001337;,
    0.062447; 0.164144; 0.988177;,
    0.128820; 0.239635; 0.908994;,
    0.037335; 0.237189; 0.975858;,
    0.041976; 0.277423; 0.869564;,
    0.289705; 0.000000; 0.931607;,
    -0.259571; 0.000000; 1.133354;,
    -1.616424; 0.108795; -0.560934;,
    -1.543252; 0.110735; -0.365926;,
    -1.590327; 0.000000; -0.558601;,
    -1.526429; 0.000000; -0.342494;,
    -1.785310; 0.375274; -0.512979;,
    -1.733947; 0.295504; -0.395830;,
    -1.651815; 0.271617; -0.431129;,
    -1.678456; 0.271617; -0.544795;,
    -1.956335; 0.182272; -0.175032;,
    -2.135168; 0.000000; -0.332555;,
    -1.983886; 0.000000; -0.125102;,
    -2.086783; 0.155579; -0.355292;,
    -1.810443; 0.185618; -0.769501;,
    -1.687404; 0.129599; -0.733502;,
    -1.811484; 0.000000; -0.875657;,
    -1.679294; 0.000000; -0.773510;,
    -1.662262; 0.155029; -0.304249;,
    -1.636318; 0.000000; -0.250098;,
    -1.526429; 0.000000; -0.342494;,
    -1.947966; 0.327716; -0.319828;,
    -2.004111; 0.327716; -0.409917;,
    -1.831378; 0.291605; -0.679515;,
    -1.738281; 0.270336; -0.629885;,
    -1.857168; 0.327716; -0.308947;,
    -1.849419; 0.169360; -0.189194;,
    -1.983886; 0.000000; -0.125102;,
    -1.839180; 0.000000; -0.154238;,
    -2.130591; 0.129599; -0.585230;,
    -2.015865; 0.185618; -0.718124;,
    -2.187506; 0.000000; -0.614080;,
    -2.043553; 0.000000; -0.777506;,
    -2.019459; 0.327716; -0.550712;,
    -1.961605; 0.327716; -0.654247;,
    -1.901766; 0.375274; -0.443770;,
    -2.187506; 0.000000; -0.614080;,
    -1.679294; 0.000000; -0.773510;,
    -0.726084; 0.062577; 0.808364;,
    -0.794468; 0.063693; 0.731094;,
    -0.742273; 0.000000; 0.800299;,
    -0.807446; 0.000000; 0.723792;,
    -0.649359; 0.215850; 0.747301;,
    -0.721526; 0.169968; 0.681287;,
    -0.737995; 0.156229; 0.740000;,
    -0.700681; 0.156229; 0.787355;,
    -0.626642; 0.000000; 0.530212;,
    -0.537987; 0.089486; 0.629953;,
    -0.525663; 0.000000; 0.587016;,
    -0.628562; 0.104839; 0.559534;,
    -0.569879; 0.106763; 0.879236;,
    -0.646746; 0.074542; 0.871644;,
    -0.557742; 0.000000; 0.911169;,
    -0.645834; 0.000000; 0.884002;,
    -0.768450; 0.089170; 0.663362;,
    -0.776415; 0.000000; 0.656745;,
    -0.807446; 0.000000; 0.723792;,
    -0.569860; 0.188495; 0.651628;,
    -0.615774; 0.188495; 0.621699;,
    -0.603578; 0.167725; 0.796529;,
    -0.654145; 0.155492; 0.814149;,
    -0.660511; 0.188495; 0.636320;,
    -0.692710; 0.097412; 0.566003;,
    -0.626642; 0.000000; 0.530212;,
    -0.705140; 0.000000; 0.551884;,
    -0.433066; 0.000000; 0.710905;,
    -0.463250; 0.074542; 0.707587;,
    -0.514778; 0.000000; 0.763335;,
    -0.522179; 0.106763; 0.761566;,
    -0.531873; 0.188495; 0.714118;,
    -0.561475; 0.188495; 0.743482;,
    -0.610188; 0.215850; 0.689669;,
    -0.433066; 0.000000; 0.710905;,
    -0.557742; 0.000000; 0.911169;;
    468;
    3;0, 1, 2;,
    3;3, 0, 2;,
    3;4, 5, 6;,
    3;7, 4, 6;,
    3;8, 9, 10;,
    3;11, 8, 10;,
    3;12, 13, 14;,
    3;14, 13, 15;,
    3;1, 16, 17;,
    3;18, 1, 17;,
    3;6, 5, 16;,
    3;6, 16, 1;,
    3;11, 19, 8;,
    3;19, 20, 8;,
    3;21, 22, 12;,
    3;12, 22, 13;,
    3;7, 6, 1;,
    3;7, 1, 0;,
    3;23, 19, 24;,
    3;19, 11, 24;,
    3;24, 11, 25;,
    3;25, 11, 26;,
    3;27, 28, 29;,
    3;27, 30, 28;,
    3;31, 32, 27;,
    3;32, 30, 27;,
    3;33, 20, 19;,
    3;23, 33, 19;,
    3;21, 4, 22;,
    3;4, 7, 22;,
    3;33, 32, 31;,
    3;33, 31, 20;,
    3;20, 31, 27;,
    3;8, 20, 27;,
    3;8, 27, 34;,
    3;8, 34, 9;,
    3;35, 13, 3;,
    3;13, 0, 3;,
    3;22, 7, 13;,
    3;13, 7, 0;,
    3;5, 23, 16;,
    3;23, 24, 16;,
    3;16, 24, 25;,
    3;17, 16, 25;,
    3;30, 14, 28;,
    3;30, 12, 14;,
    3;32, 21, 30;,
    3;21, 12, 30;,
    3;33, 4, 32;,
    3;32, 4, 21;,
    3;33, 23, 5;,
    3;4, 33, 5;,
    3;36, 37, 38;,
    3;38, 37, 39;,
    3;40, 41, 42;,
    3;43, 40, 42;,
    3;44, 45, 46;,
    3;44, 47, 45;,
    3;48, 49, 50;,
    3;50, 49, 51;,
    3;37, 52, 53;,
    3;37, 53, 54;,
    3;42, 41, 52;,
    3;42, 52, 37;,
    3;44, 55, 47;,
    3;55, 56, 47;,
    3;57, 58, 48;,
    3;48, 58, 49;,
    3;43, 42, 36;,
    3;42, 37, 36;,
    3;59, 55, 60;,
    3;55, 44, 60;,
    3;60, 44, 61;,
    3;44, 62, 61;,
    3;63, 64, 65;,
    3;64, 66, 65;,
    3;67, 66, 64;,
    3;67, 68, 66;,
    3;69, 56, 55;,
    3;69, 55, 59;,
    3;57, 40, 58;,
    3;40, 43, 58;,
    3;67, 69, 68;,
    3;56, 69, 67;,
    3;47, 67, 64;,
    3;56, 67, 47;,
    3;64, 70, 45;,
    3;47, 64, 45;,
    3;49, 36, 51;,
    3;51, 36, 38;,
    3;49, 58, 36;,
    3;58, 43, 36;,
    3;41, 59, 60;,
    3;41, 60, 52;,
    3;52, 60, 61;,
    3;52, 61, 53;,
    3;66, 48, 65;,
    3;65, 48, 71;,
    3;68, 57, 66;,
    3;66, 57, 48;,
    3;69, 40, 68;,
    3;68, 40, 57;,
    3;69, 59, 41;,
    3;40, 69, 41;,
    3;72, 73, 74;,
    3;74, 73, 75;,
    3;76, 77, 78;,
    3;79, 76, 78;,
    3;80, 81, 82;,
    3;80, 83, 81;,
    3;84, 85, 86;,
    3;86, 85, 87;,
    3;73, 88, 89;,
    3;73, 89, 90;,
    3;78, 77, 73;,
    3;77, 88, 73;,
    3;80, 91, 83;,
    3;91, 92, 83;,
    3;93, 94, 84;,
    3;84, 94, 85;,
    3;79, 78, 72;,
    3;78, 73, 72;,
    3;95, 91, 96;,
    3;91, 80, 96;,
    3;96, 80, 97;,
    3;80, 98, 97;,
    3;99, 100, 101;,
    3;100, 102, 101;,
    3;103, 102, 100;,
    3;103, 104, 102;,
    3;105, 92, 91;,
    3;105, 91, 95;,
    3;93, 76, 94;,
    3;76, 79, 94;,
    3;92, 105, 103;,
    3;103, 105, 104;,
    3;83, 103, 100;,
    3;92, 103, 83;,
    3;81, 100, 106;,
    3;83, 100, 81;,
    3;85, 72, 87;,
    3;87, 72, 74;,
    3;85, 94, 72;,
    3;94, 79, 72;,
    3;77, 95, 96;,
    3;77, 96, 88;,
    3;88, 96, 97;,
    3;88, 97, 89;,
    3;101, 102, 107;,
    3;102, 84, 107;,
    3;104, 93, 102;,
    3;102, 93, 84;,
    3;105, 76, 104;,
    3;104, 76, 93;,
    3;76, 105, 95;,
    3;76, 95, 77;,
    3;108, 109, 110;,
    3;110, 109, 111;,
    3;112, 113, 114;,
    3;115, 112, 114;,
    3;116, 117, 118;,
    3;119, 117, 116;,
    3;120, 121, 122;,
    3;121, 123, 122;,
    3;109, 124, 125;,
    3;126, 109, 125;,
    3;114, 113, 124;,
    3;114, 124, 109;,
    3;119, 127, 117;,
    3;127, 128, 117;,
    3;129, 130, 121;,
    3;120, 129, 121;,
    3;115, 114, 108;,
    3;114, 109, 108;,
    3;131, 127, 132;,
    3;127, 119, 132;,
    3;132, 119, 133;,
    3;133, 119, 134;,
    3;135, 136, 137;,
    3;135, 138, 136;,
    3;139, 138, 135;,
    3;139, 140, 138;,
    3;127, 141, 128;,
    3;131, 141, 127;,
    3;129, 112, 130;,
    3;112, 115, 130;,
    3;141, 140, 139;,
    3;141, 139, 128;,
    3;117, 139, 135;,
    3;128, 139, 117;,
    3;135, 142, 118;,
    3;117, 135, 118;,
    3;121, 108, 143;,
    3;143, 108, 110;,
    3;121, 130, 108;,
    3;130, 115, 108;,
    3;113, 131, 132;,
    3;113, 132, 124;,
    3;124, 132, 133;,
    3;125, 124, 133;,
    3;138, 120, 136;,
    3;120, 122, 136;,
    3;140, 129, 138;,
    3;129, 120, 138;,
    3;141, 112, 140;,
    3;140, 112, 129;,
    3;141, 131, 113;,
    3;112, 141, 113;,
    3;144, 145, 146;,
    3;146, 145, 147;,
    3;148, 149, 150;,
    3;151, 148, 150;,
    3;152, 153, 154;,
    3;155, 152, 154;,
    3;156, 157, 158;,
    3;159, 156, 158;,
    3;145, 160, 161;,
    3;160, 162, 161;,
    3;150, 149, 160;,
    3;150, 160, 145;,
    3;155, 163, 152;,
    3;163, 164, 152;,
    3;165, 166, 156;,
    3;156, 166, 157;,
    3;151, 150, 144;,
    3;150, 145, 144;,
    3;167, 163, 168;,
    3;163, 155, 168;,
    3;168, 155, 169;,
    3;155, 170, 169;,
    3;171, 172, 173;,
    3;172, 174, 173;,
    3;175, 174, 172;,
    3;175, 176, 174;,
    3;177, 164, 163;,
    3;177, 163, 167;,
    3;165, 148, 166;,
    3;148, 151, 166;,
    3;175, 177, 176;,
    3;177, 175, 164;,
    3;164, 175, 172;,
    3;152, 164, 172;,
    3;152, 172, 178;,
    3;152, 178, 153;,
    3;157, 144, 179;,
    3;179, 144, 146;,
    3;166, 151, 157;,
    3;157, 151, 144;,
    3;149, 167, 168;,
    3;149, 168, 160;,
    3;160, 168, 169;,
    3;160, 169, 162;,
    3;174, 156, 173;,
    3;173, 156, 159;,
    3;174, 176, 156;,
    3;176, 165, 156;,
    3;177, 148, 176;,
    3;176, 148, 165;,
    3;148, 177, 167;,
    3;148, 167, 149;,
    3;180, 181, 182;,
    3;181, 183, 182;,
    3;184, 185, 186;,
    3;184, 186, 187;,
    3;188, 189, 190;,
    3;191, 189, 188;,
    3;192, 193, 194;,
    3;193, 195, 194;,
    3;181, 196, 197;,
    3;181, 197, 198;,
    3;186, 185, 196;,
    3;186, 196, 181;,
    3;191, 199, 189;,
    3;200, 199, 191;,
    3;201, 202, 193;,
    3;192, 201, 193;,
    3;187, 186, 181;,
    3;187, 181, 180;,
    3;203, 200, 191;,
    3;203, 191, 204;,
    3;204, 191, 205;,
    3;204, 205, 206;,
    3;207, 208, 209;,
    3;208, 210, 209;,
    3;211, 210, 208;,
    3;211, 212, 210;,
    3;200, 213, 199;,
    3;213, 200, 203;,
    3;201, 184, 202;,
    3;184, 187, 202;,
    3;211, 213, 212;,
    3;199, 213, 211;,
    3;199, 211, 208;,
    3;189, 199, 208;,
    3;189, 208, 214;,
    3;190, 189, 214;,
    3;193, 180, 195;,
    3;180, 182, 195;,
    3;202, 187, 193;,
    3;193, 187, 180;,
    3;185, 203, 196;,
    3;203, 204, 196;,
    3;196, 204, 197;,
    3;204, 206, 197;,
    3;210, 192, 209;,
    3;209, 192, 215;,
    3;212, 201, 210;,
    3;210, 201, 192;,
    3;213, 184, 212;,
    3;212, 184, 201;,
    3;213, 203, 185;,
    3;184, 213, 185;,
    3;216, 217, 218;,
    3;217, 219, 218;,
    3;220, 221, 222;,
    3;220, 222, 223;,
    3;224, 225, 226;,
    3;225, 227, 226;,
    3;228, 229, 230;,
    3;229, 231, 230;,
    3;217, 232, 233;,
    3;217, 233, 234;,
    3;222, 221, 232;,
    3;222, 232, 217;,
    3;225, 235, 227;,
    3;235, 236, 227;,
    3;237, 238, 228;,
    3;228, 238, 229;,
    3;223, 222, 216;,
    3;222, 217, 216;,
    3;239, 235, 240;,
    3;235, 225, 240;,
    3;240, 225, 241;,
    3;241, 225, 242;,
    3;243, 244, 245;,
    3;244, 246, 245;,
    3;247, 246, 244;,
    3;247, 248, 246;,
    3;235, 249, 236;,
    3;239, 249, 235;,
    3;237, 220, 238;,
    3;220, 223, 238;,
    3;236, 249, 247;,
    3;247, 249, 248;,
    3;236, 247, 244;,
    3;227, 236, 244;,
    3;226, 244, 250;,
    3;227, 244, 226;,
    3;229, 216, 231;,
    3;216, 218, 231;,
    3;229, 238, 216;,
    3;238, 223, 216;,
    3;221, 239, 240;,
    3;221, 240, 232;,
    3;232, 240, 241;,
    3;232, 241, 233;,
    3;246, 228, 245;,
    3;245, 228, 251;,
    3;248, 237, 246;,
    3;246, 237, 228;,
    3;249, 220, 248;,
    3;248, 220, 237;,
    3;220, 249, 239;,
    3;220, 239, 221;,
    3;252, 253, 254;,
    3;254, 253, 255;,
    3;256, 257, 258;,
    3;259, 256, 258;,
    3;260, 261, 262;,
    3;260, 263, 261;,
    3;264, 265, 266;,
    3;266, 265, 267;,
    3;253, 268, 269;,
    3;270, 253, 269;,
    3;258, 257, 268;,
    3;258, 268, 253;,
    3;260, 271, 263;,
    3;271, 272, 263;,
    3;273, 274, 265;,
    3;264, 273, 265;,
    3;259, 258, 252;,
    3;258, 253, 252;,
    3;275, 271, 260;,
    3;275, 260, 276;,
    3;276, 260, 277;,
    3;278, 276, 277;,
    3;279, 280, 281;,
    3;280, 282, 281;,
    3;283, 284, 279;,
    3;284, 280, 279;,
    3;285, 272, 271;,
    3;285, 271, 275;,
    3;273, 256, 274;,
    3;256, 259, 274;,
    3;285, 284, 283;,
    3;285, 283, 272;,
    3;272, 283, 279;,
    3;263, 272, 279;,
    3;279, 286, 261;,
    3;263, 279, 261;,
    3;287, 265, 254;,
    3;265, 252, 254;,
    3;265, 274, 252;,
    3;274, 259, 252;,
    3;257, 275, 276;,
    3;257, 276, 268;,
    3;268, 276, 278;,
    3;269, 268, 278;,
    3;280, 266, 282;,
    3;280, 264, 266;,
    3;284, 273, 280;,
    3;273, 264, 280;,
    3;285, 256, 284;,
    3;284, 256, 273;,
    3;285, 275, 257;,
    3;256, 285, 257;,
    3;288, 289, 290;,
    3;289, 291, 290;,
    3;292, 293, 294;,
    3;292, 294, 295;,
    3;296, 297, 298;,
    3;299, 297, 296;,
    3;300, 301, 302;,
    3;301, 303, 302;,
    3;289, 304, 305;,
    3;289, 305, 306;,
    3;294, 293, 304;,
    3;294, 304, 289;,
    3;299, 307, 297;,
    3;308, 307, 299;,
    3;309, 310, 301;,
    3;300, 309, 301;,
    3;295, 294, 289;,
    3;295, 289, 288;,
    3;311, 308, 299;,
    3;311, 299, 312;,
    3;312, 299, 313;,
    3;312, 313, 314;,
    3;315, 316, 317;,
    3;316, 318, 317;,
    3;319, 318, 316;,
    3;319, 320, 318;,
    3;308, 321, 307;,
    3;321, 308, 311;,
    3;309, 292, 310;,
    3;292, 295, 310;,
    3;319, 321, 320;,
    3;307, 321, 319;,
    3;307, 319, 316;,
    3;297, 307, 316;,
    3;297, 316, 322;,
    3;298, 297, 322;,
    3;301, 288, 303;,
    3;288, 290, 303;,
    3;310, 295, 301;,
    3;301, 295, 288;,
    3;293, 311, 304;,
    3;311, 312, 304;,
    3;304, 312, 305;,
    3;312, 314, 305;,
    3;318, 300, 317;,
    3;317, 300, 323;,
    3;320, 309, 318;,
    3;318, 309, 300;,
    3;321, 292, 320;,
    3;320, 292, 309;,
    3;321, 311, 293;,
    3;292, 321, 293;;

   MeshTextureCoords {
    324;
    0.436147; 0.438600;,
    0.473009; 0.428036;,
    0.472701; 0.406619;,
    0.430247; 0.418274;,
    0.457565; 0.494058;,
    0.473028; 0.482419;,
    0.463045; 0.462641;,
    0.446283; 0.466464;,
    0.497489; 0.574587;,
    0.510891; 0.602937;,
    0.548526; 0.566379;,
    0.523884; 0.540247;,
    0.413442; 0.493559;,
    0.407545; 0.460039;,
    0.381407; 0.494663;,
    0.385147; 0.457576;,
    0.488624; 0.460740;,
    0.505994; 0.446524;,
    0.477652; 0.421707;,
    0.492568; 0.533107;,
    0.481862; 0.543812;,
    0.434161; 0.500697;,
    0.435407; 0.478863;,
    0.489650; 0.513599;,
    0.516550; 0.511321;,
    0.538562; 0.500586;,
    0.554072; 0.538865;,
    0.456821; 0.583324;,
    0.407667; 0.559927;,
    0.442024; 0.604002;,
    0.431472; 0.545546;,
    0.462203; 0.544311;,
    0.446072; 0.529509;,
    0.472196; 0.520358;,
    0.457050; 0.612536;,
    0.389590; 0.440593;,
    0.477652; 0.149620;,
    0.511236; 0.160576;,
    0.485806; 0.130505;,
    0.524659; 0.140402;,
    0.469160; 0.205384;,
    0.495703; 0.202628;,
    0.489335; 0.181371;,
    0.473479; 0.177489;,
    0.509247; 0.270755;,
    0.476033; 0.318523;,
    0.520961; 0.306412;,
    0.469116; 0.283323;,
    0.419847; 0.182407;,
    0.443117; 0.155567;,
    0.399132; 0.150433;,
    0.435691; 0.132980;,
    0.516672; 0.190466;,
    0.538452; 0.184825;,
    0.524145; 0.155282;,
    0.486208; 0.249357;,
    0.472007; 0.253889;,
    0.448391; 0.201692;,
    0.457682; 0.181576;,
    0.491546; 0.232587;,
    0.520241; 0.244667;,
    0.547000; 0.244630;,
    0.540801; 0.283453;,
    0.410582; 0.295900;,
    0.430676; 0.281255;,
    0.399382; 0.249160;,
    0.428745; 0.241460;,
    0.454008; 0.248194;,
    0.451349; 0.231221;,
    0.471779; 0.231863;,
    0.418193; 0.306848;,
    0.386669; 0.178575;,
    0.793577; 0.332385;,
    0.833096; 0.331423;,
    0.795435; 0.309795;,
    0.839179; 0.307566;,
    0.799719; 0.389159;,
    0.840339; 0.378191;,
    0.821118; 0.350786;,
    0.795675; 0.352911;,
    0.860655; 0.447253;,
    0.840485; 0.504193;,
    0.881832; 0.480328;,
    0.822742; 0.470102;,
    0.746017; 0.384231;,
    0.761356; 0.349731;,
    0.714984; 0.357622;,
    0.747060; 0.328712;,
    0.849536; 0.366443;,
    0.871983; 0.356070;,
    0.849485; 0.320340;,
    0.842008; 0.438507;,
    0.822321; 0.449754;,
    0.769774; 0.393972;,
    0.774784; 0.364853;,
    0.838043; 0.413845;,
    0.860522; 0.417122;,
    0.889072; 0.410372;,
    0.896258; 0.451678;,
    0.784017; 0.495407;,
    0.800723; 0.472240;,
    0.753428; 0.458866;,
    0.779307; 0.437056;,
    0.806021; 0.439735;,
    0.788962; 0.426673;,
    0.814629; 0.422225;,
    0.796570; 0.502793;,
    0.710965; 0.394013;,
    0.754034; 0.713724;,
    0.805349; 0.687347;,
    0.738954; 0.687227;,
    0.796411; 0.652975;,
    0.792571; 0.769641;,
    0.811620; 0.748297;,
    0.798724; 0.733814;,
    0.775939; 0.746464;,
    0.928172; 0.811297;,
    0.851400; 0.832490;,
    0.878289; 0.866114;,
    0.883638; 0.780255;,
    0.732059; 0.791535;,
    0.717736; 0.755550;,
    0.681220; 0.813819;,
    0.678673; 0.764179;,
    0.830229; 0.712556;,
    0.852274; 0.680700;,
    0.816136; 0.668463;,
    0.836514; 0.787300;,
    0.823151; 0.803123;,
    0.761370; 0.787527;,
    0.761668; 0.765073;,
    0.833296; 0.770393;,
    0.871174; 0.752170;,
    0.903024; 0.720219;,
    0.931327; 0.752438;,
    0.797755; 0.865428;,
    0.725523; 0.870227;,
    0.779912; 0.903030;,
    0.760423; 0.834884;,
    0.798405; 0.813713;,
    0.777618; 0.808885;,
    0.810838; 0.785900;,
    0.806684; 0.904209;,
    0.685693; 0.732158;,
    0.262486; 0.149052;,
    0.273651; 0.194575;,
    0.281070; 0.144793;,
    0.292005; 0.196549;,
    0.206780; 0.168303;,
    0.219228; 0.190103;,
    0.239161; 0.180476;,
    0.234669; 0.158210;,
    0.124851; 0.203893;,
    0.099362; 0.213641;,
    0.131521; 0.260320;,
    0.155377; 0.239996;,
    0.205588; 0.112689;,
    0.241110; 0.111703;,
    0.245980; 0.088148;,
    0.204748; 0.076225;,
    0.240430; 0.211426;,
    0.285687; 0.209268;,
    0.253726; 0.234153;,
    0.164731; 0.205935;,
    0.154680; 0.189849;,
    0.199259; 0.136384;,
    0.221457; 0.142216;,
    0.192074; 0.191209;,
    0.194102; 0.223747;,
    0.202903; 0.248670;,
    0.154579; 0.270568;,
    0.094154; 0.141081;,
    0.115900; 0.154973;,
    0.138518; 0.101446;,
    0.153149; 0.128054;,
    0.154267; 0.164769;,
    0.169110; 0.146219;,
    0.179660; 0.183239;,
    0.090334; 0.151439;,
    0.258753; 0.095320;,
    0.217443; 0.752423;,
    0.240538; 0.790210;,
    0.240681; 0.741519;,
    0.267151; 0.778125;,
    0.172733; 0.786632;,
    0.195592; 0.804488;,
    0.202477; 0.787655;,
    0.191652; 0.772430;,
    0.145667; 0.897073;,
    0.126099; 0.834167;,
    0.104918; 0.867080;,
    0.169078; 0.856969;,
    0.146889; 0.730008;,
    0.182849; 0.729181;,
    0.161426; 0.683315;,
    0.197604; 0.702681;,
    0.223705; 0.813791;,
    0.250833; 0.826781;,
    0.257075; 0.796457;,
    0.150750; 0.813630;,
    0.164097; 0.821958;,
    0.159691; 0.767032;,
    0.176990; 0.762158;,
    0.176583; 0.817387;,
    0.194132; 0.848788;,
    0.195129; 0.895245;,
    0.222049; 0.872776;,
    0.063554; 0.794328;,
    0.096042; 0.800925;,
    0.081316; 0.757163;,
    0.119256; 0.775063;,
    0.140325; 0.796586;,
    0.146988; 0.786092;,
    0.162132; 0.801884;,
    0.069606; 0.819212;,
    0.112414; 0.698988;,
    0.512075; 0.763715;,
    0.535000; 0.779537;,
    0.524916; 0.742451;,
    0.553498; 0.759392;,
    0.486873; 0.808881;,
    0.513337; 0.817961;,
    0.516170; 0.788666;,
    0.502559; 0.780173;,
    0.491770; 0.919378;,
    0.495504; 0.880622;,
    0.457617; 0.916259;,
    0.464742; 0.880769;,
    0.459363; 0.781484;,
    0.486546; 0.762714;,
    0.454965; 0.744752;,
    0.487206; 0.739139;,
    0.526358; 0.813875;,
    0.552040; 0.819576;,
    0.558506; 0.780923;,
    0.488016; 0.865073;,
    0.473873; 0.865249;,
    0.468350; 0.799547;,
    0.485921; 0.780295;,
    0.496648; 0.844196;,
    0.509490; 0.857204;,
    0.536867; 0.866808;,
    0.524434; 0.903295;,
    0.427688; 0.883646;,
    0.450585; 0.873149;,
    0.422860; 0.839608;,
    0.452931; 0.836555;,
    0.468872; 0.850493;,
    0.464988; 0.833699;,
    0.480600; 0.840768;,
    0.434996; 0.895303;,
    0.429582; 0.770795;,
    0.754035; 0.713722;,
    0.805357; 0.687337;,
    0.738954; 0.687228;,
    0.796411; 0.652974;,
    0.792570; 0.769640;,
    0.811620; 0.748297;,
    0.798725; 0.733811;,
    0.775939; 0.746464;,
    0.883639; 0.780255;,
    0.878288; 0.866113;,
    0.928172; 0.811295;,
    0.851401; 0.832490;,
    0.732058; 0.791535;,
    0.717736; 0.755550;,
    0.681221; 0.813818;,
    0.678673; 0.764178;,
    0.830231; 0.712552;,
    0.852272; 0.680701;,
    0.816128; 0.668472;,
    0.836514; 0.787299;,
    0.823152; 0.803123;,
    0.761369; 0.787527;,
    0.761667; 0.765072;,
    0.833296; 0.770393;,
    0.871174; 0.752169;,
    0.931328; 0.752438;,
    0.903023; 0.720219;,
    0.797755; 0.865428;,
    0.760422; 0.834884;,
    0.779913; 0.903031;,
    0.725524; 0.870225;,
    0.798404; 0.813712;,
    0.777618; 0.808887;,
    0.810838; 0.785900;,
    0.806683; 0.904208;,
    0.685693; 0.732159;,
    0.151021; 0.449299;,
    0.192961; 0.434039;,
    0.145694; 0.424949;,
    0.186276; 0.407284;,
    0.173595; 0.499419;,
    0.196008; 0.481340;,
    0.181342; 0.471247;,
    0.164301; 0.478399;,
    0.272542; 0.549525;,
    0.208439; 0.554504;,
    0.235036; 0.581568;,
    0.239847; 0.518530;,
    0.113995; 0.511531;,
    0.121388; 0.477086;,
    0.072831; 0.487196;,
    0.099747; 0.457345;,
    0.211007; 0.456674;,
    0.229422; 0.433818;,
    0.201185; 0.421214;,
    0.194452; 0.526720;,
    0.205519; 0.515650;,
    0.152127; 0.507667;,
    0.151269; 0.490029;,
    0.204117; 0.502480;,
    0.237726; 0.492696;,
    0.282435; 0.502352;,
    0.266773; 0.471387;,
    0.156917; 0.605002;,
    0.170344; 0.575592;,
    0.125481; 0.579629;,
    0.150699; 0.547800;,
    0.175940; 0.532996;,
    0.167378; 0.523996;,
    0.185894; 0.512980;,
    0.175011; 0.608189;,
    0.077162; 0.537385;;
   }

   MeshMaterialList {
    1;
    468;
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

    Material rocks_zusaetze_lambert12SG_Smoothing {
     0.000000; 0.000000; 0.000000; 1.000000;;
     128.000000;
     0.050000; 0.050000; 0.050000;;
     0.000000; 0.000000; 0.000000;;

     TextureFilename {
      "rock_006_c.tga";
     }
    }

   }
  }
}
