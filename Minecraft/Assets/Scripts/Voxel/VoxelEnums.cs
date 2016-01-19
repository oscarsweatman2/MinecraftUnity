
public class VoxelType
{
    public const int Unknown = -1;
    public const int Grass = 0;
    public const int Dirt = 1;
    public const int Stone = 2;
    public const int Debug = 3;
    public const int NumVoxelTypes = 4;

    public int Type = VoxelType.Unknown;
    public float Health = 1;
    public VoxelUVSet UV = null;

    public VoxelType(int type, float health, VoxelUVSet uvSet)
    {
        Type = type;
        Health = health;
        UV = uvSet;
    }
}

public struct IntVec3
{
    public int X;
    public int Y;
    public int Z;
    public IntVec3(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public IntVec3 Offset(IntVec3 v)
    {
        return new IntVec3(X + v.X, Y + v.Y, Z + v.Z);
    }

    public bool InRange(int xlen, int ylen, int zlen)
    {
        return X >= 0 && Y >= 0 && Z >= 0 && X < xlen && Y < ylen && Z < zlen;
    }
}

public class Side
{
    public const int TNW = 0;
    public const int TN = 1;
    public const int TNE = 2;
    public const int TW = 3;
    public const int T = 4;
    public const int TE = 5;
    public const int TSW = 6;
    public const int TS = 7;
    public const int TSE = 8;
    public const int NW = 9;
    public const int N = 10;
    public const int NE = 11;
    public const int W = 12;
    public const int E = 13;
    public const int SW = 14;
    public const int S = 15;
    public const int SE = 16;
    public const int BNW = 17;
    public const int BN = 18;
    public const int BNE = 19;
    public const int BW = 20;
    public const int B = 21;
    public const int BE = 22;
    public const int BSW = 23;
    public const int BS = 24;
    public const int BSE = 25;
    public const int Num = 26;

    public static IntVec3[] Offset = new IntVec3[Side.Num]
    {
        new IntVec3( -1,  1,  1),
        new IntVec3(  0,  1,  1),
        new IntVec3(  1,  1,  1),
        new IntVec3( -1,  1,  0),
        new IntVec3(  0,  1,  0),
        new IntVec3(  1,  1,  0),
        new IntVec3( -1,  1, -1),
        new IntVec3(  0,  1, -1),
        new IntVec3(  1,  1, -1),
        new IntVec3( -1,  0,  1),
        new IntVec3(  0,  0,  1),
        new IntVec3(  1,  0,  1),
        new IntVec3( -1,  0,  0),
        new IntVec3(  1,  0,  0),
        new IntVec3( -1,  0, -1),
        new IntVec3(  0,  0, -1),
        new IntVec3(  1,  0, -1),
        new IntVec3( -1, -1,  1),
        new IntVec3(  0, -1,  1),
        new IntVec3(  1, -1,  1),
        new IntVec3( -1, -1,  0),
        new IntVec3(  0, -1,  0),
        new IntVec3(  1, -1,  0),
        new IntVec3( -1, -1, -1),
        new IntVec3(  0, -1, -1),
        new IntVec3(  1, -1, -1),
    };
}