using UnityEngine;
using System.Collections.Generic;

public class VoxelTerrain : MonoBehaviour
{
    public static VoxelTerrain Inst = null;

    public int XLen = 10;
    public int YLen = 10;
    public int ZLen = 10;

    public float VoxelSize = 1.0f;

    private Voxel[,,] Voxels = null;

    private Dictionary<BoxCollider, Voxel> ColliderToVoxel = null;

    private VoxelType VoxelGrass = new VoxelType(VoxelType.Grass, 1, VoxelUVSet.Grass);
    private VoxelType VoxelDirt = new VoxelType(VoxelType.Dirt, 1, VoxelUVSet.Dirt);
    private VoxelType VoxelStone = new VoxelType(VoxelType.Stone, 2, VoxelUVSet.Stone);
    private VoxelType VoxelDebug = new VoxelType(VoxelType.Debug, 10, VoxelUVSet.Debug);

    private Mesh Mesh = null;
    private MeshFilter MeshFilter = null;

    private Vector3[] Verts = null;
    private Vector3[] Norms = null;
    private Vector2[] Coords = null;
    private int[] Inds = null;

	void Start ()
    {
        Inst = this;

        Voxels = new Voxel[XLen, YLen, ZLen];
        ColliderToVoxel = new Dictionary<BoxCollider, Voxel>();

        Mesh = new Mesh();

        MeshFilter = gameObject.GetComponent<MeshFilter>();
        MeshFilter.mesh = Mesh;

        InitVoxels();

        GenVoxelData();

        UpdateExposedVoxels();

        RefreshMesh();
    }

    void Update()
    {
        //RefreshMesh();
    }

    public void InitVoxels()
    {
        // Construct Each Voxel
        for (int x = 0; x < XLen; ++x)
            for (int y = 0; y < YLen; ++y)
                for (int z = 0; z < ZLen; ++z)
                {
                    // Create a box collider for this voxel and add it to the terrain object
                    BoxCollider voxelCollider = gameObject.AddComponent<BoxCollider>();
                    voxelCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
                    voxelCollider.center = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);

                    // Create the voxel, tell it where and what collider belongs to it
                    Voxel voxel = Voxels[x, y, z] = new Voxel(new IntVec3(x, y, z), voxelCollider);

                    ColliderToVoxel[voxelCollider] = voxel;
                }

        for (int x = 0; x < XLen; ++x)
            for (int y = 0; y < YLen; ++y)
                for (int z = 0; z < ZLen; ++z)
                {
                    Voxel voxel = Voxels[x, y, z];

                    voxel.Neighbors[Side.TNW] = NeighborOrNull(voxel, Side.TNW);
                    voxel.Neighbors[Side.TN] = NeighborOrNull(voxel, Side.TN);
                    voxel.Neighbors[Side.TNE] = NeighborOrNull(voxel, Side.TNE);
                    voxel.Neighbors[Side.TW] = NeighborOrNull(voxel, Side.TW);
                    voxel.Neighbors[Side.T] = NeighborOrNull(voxel, Side.T);
                    voxel.Neighbors[Side.TE] = NeighborOrNull(voxel, Side.TE);
                    voxel.Neighbors[Side.TSW] = NeighborOrNull(voxel, Side.TSW);
                    voxel.Neighbors[Side.TS] = NeighborOrNull(voxel, Side.TS);
                    voxel.Neighbors[Side.TSE] = NeighborOrNull(voxel, Side.TSE);
                    voxel.Neighbors[Side.NW] = NeighborOrNull(voxel, Side.NW);
                    voxel.Neighbors[Side.N] = NeighborOrNull(voxel, Side.N);
                    voxel.Neighbors[Side.NE] = NeighborOrNull(voxel, Side.NE);
                    voxel.Neighbors[Side.W] = NeighborOrNull(voxel, Side.W);
                    voxel.Neighbors[Side.E] = NeighborOrNull(voxel, Side.E);
                    voxel.Neighbors[Side.SW] = NeighborOrNull(voxel, Side.SW);
                    voxel.Neighbors[Side.S] = NeighborOrNull(voxel, Side.S);
                    voxel.Neighbors[Side.SE] = NeighborOrNull(voxel, Side.SE);
                    voxel.Neighbors[Side.BNW] = NeighborOrNull(voxel, Side.BNW);
                    voxel.Neighbors[Side.BN] = NeighborOrNull(voxel, Side.BN);
                    voxel.Neighbors[Side.BNE] = NeighborOrNull(voxel, Side.BNE);
                    voxel.Neighbors[Side.BW] = NeighborOrNull(voxel, Side.BW);
                    voxel.Neighbors[Side.B] = NeighborOrNull(voxel, Side.B);
                    voxel.Neighbors[Side.BE] = NeighborOrNull(voxel, Side.BE);
                    voxel.Neighbors[Side.BSW] = NeighborOrNull(voxel, Side.BSW);
                    voxel.Neighbors[Side.BS] = NeighborOrNull(voxel, Side.BS);
                    voxel.Neighbors[Side.BSE] = NeighborOrNull(voxel, Side.BSE);
                }
    }

    public void UpdateExposedVoxels()
    {
        for (int x = 0; x < XLen; ++x)
            for (int y = 0; y < YLen; ++y)
                for (int z = 0; z < ZLen; ++z)
                {
                    Voxel voxel = Voxels[x, y, z];
                    bool hidden = !voxel.Enabled ||
                                  (Voxel.Exist(voxel.Neighbors[Side.T]) &&
                                  Voxel.Exist(voxel.Neighbors[Side.N]) &&
                                  Voxel.Exist(voxel.Neighbors[Side.E]) &&
                                  Voxel.Exist(voxel.Neighbors[Side.S]) &&
                                  Voxel.Exist(voxel.Neighbors[Side.W]) &&
                                  Voxel.Exist(voxel.Neighbors[Side.B]));
                    voxel.Exposed = !hidden;
                    voxel.Collider.enabled = voxel.Exposed;
                }
    }

    public void GenVoxelData()
    {
        for (int x = 0; x < XLen; ++x)
            for (int y = 0; y < YLen; ++y)
                for (int z = 0; z < ZLen; ++z)
                {
                    Voxel voxel = Voxels[x, y, z];

                    voxel.Type = VoxelGrass;// Random.value > 0.5f ? Grass : Dirt;
                }
    }

    public void RefreshMesh()
    {
        List<Voxel> exposedVoxels = new List<Voxel>();

        for (int x = 0; x < XLen; ++x)
            for (int y = 0; y < YLen; ++y)
                for (int z = 0; z < ZLen; ++z)
                    if (Voxels[x, y, z].Exposed)
                        exposedVoxels.Add(Voxels[x, y, z]);

        int numVoxels = exposedVoxels.Count;

        int numVerts = numVoxels * 24;
        int numInds = numVoxels * 36;

        Verts = new Vector3[numVerts];
        Norms = new Vector3[numVerts];
        Coords = new Vector2[numVerts];
        Inds = new int[numInds];

        int vertIndex = 0;
        int indIndex = 0;

        Vector3 up = Vector3.up;
        Vector3 north = Vector3.forward;
        Vector3 east = Vector3.right;
        Vector3 south = -north;
        Vector3 west = -east;
        Vector3 down = -up;

        foreach (Voxel voxel in exposedVoxels)
        {
            IntVec3 index = voxel.Index;

            Vector3 bsw = new Vector3(index.X * VoxelSize, index.Y * VoxelSize, index.Z * VoxelSize);
            Vector3 bnw = bsw + new Vector3(0, 0, VoxelSize);
            Vector3 bne = bsw + new Vector3(VoxelSize, 0, VoxelSize);
            Vector3 bse = bsw + new Vector3(VoxelSize, 0, 0);
            Vector3 tsw = bsw + new Vector3(0, VoxelSize, 0);
            Vector3 tnw = bsw + new Vector3(0, VoxelSize, VoxelSize);
            Vector3 tne = bsw + new Vector3(VoxelSize, VoxelSize, VoxelSize);
            Vector3 tse = bsw + new Vector3(VoxelSize, VoxelSize, 0);

            // Bottom
            Verts[vertIndex + 0] = bnw;
            Verts[vertIndex + 1] = bsw;
            Verts[vertIndex + 2] = bse;
            Verts[vertIndex + 3] = bne;
            Norms[vertIndex + 0] = down;
            Norms[vertIndex + 1] = down;
            Norms[vertIndex + 2] = down;
            Norms[vertIndex + 3] = down;
            Coords[vertIndex + 0] = voxel.Type.UV.Bottom.A;
            Coords[vertIndex + 1] = voxel.Type.UV.Bottom.B;
            Coords[vertIndex + 2] = voxel.Type.UV.Bottom.C;
            Coords[vertIndex + 3] = voxel.Type.UV.Bottom.D;
            Inds[indIndex + 0] = vertIndex + 0;
            Inds[indIndex + 1] = vertIndex + 1;
            Inds[indIndex + 2] = vertIndex + 2;
            Inds[indIndex + 3] = vertIndex + 0;
            Inds[indIndex + 4] = vertIndex + 2;
            Inds[indIndex + 5] = vertIndex + 3;
            vertIndex += 4;
            indIndex += 6;

            // South
            Verts[vertIndex + 0] = bsw;
            Verts[vertIndex + 1] = tsw;
            Verts[vertIndex + 2] = tse;
            Verts[vertIndex + 3] = bse;
            Norms[vertIndex + 0] = south;
            Norms[vertIndex + 1] = south;
            Norms[vertIndex + 2] = south;
            Norms[vertIndex + 3] = south;
            Coords[vertIndex + 0] = voxel.Type.UV.Side.A;
            Coords[vertIndex + 1] = voxel.Type.UV.Side.B;
            Coords[vertIndex + 2] = voxel.Type.UV.Side.C;
            Coords[vertIndex + 3] = voxel.Type.UV.Side.D;
            Inds[indIndex + 0] = vertIndex + 0;
            Inds[indIndex + 1] = vertIndex + 1;
            Inds[indIndex + 2] = vertIndex + 2;
            Inds[indIndex + 3] = vertIndex + 0;
            Inds[indIndex + 4] = vertIndex + 2;
            Inds[indIndex + 5] = vertIndex + 3;
            vertIndex += 4;
            indIndex += 6;

            // West
            Verts[vertIndex + 0] = bnw;
            Verts[vertIndex + 1] = tnw;
            Verts[vertIndex + 2] = tsw;
            Verts[vertIndex + 3] = bsw;
            Norms[vertIndex + 0] = west;
            Norms[vertIndex + 1] = west;
            Norms[vertIndex + 2] = west;
            Norms[vertIndex + 3] = west;
            Coords[vertIndex + 0] = voxel.Type.UV.Side.A;
            Coords[vertIndex + 1] = voxel.Type.UV.Side.B;
            Coords[vertIndex + 2] = voxel.Type.UV.Side.C;
            Coords[vertIndex + 3] = voxel.Type.UV.Side.D;
            Inds[indIndex + 0] = vertIndex + 0;
            Inds[indIndex + 1] = vertIndex + 1;
            Inds[indIndex + 2] = vertIndex + 2;
            Inds[indIndex + 3] = vertIndex + 0;
            Inds[indIndex + 4] = vertIndex + 2;
            Inds[indIndex + 5] = vertIndex + 3;
            vertIndex += 4;
            indIndex += 6;

            // North
            Verts[vertIndex + 0] = bne;
            Verts[vertIndex + 1] = tne;
            Verts[vertIndex + 2] = tnw;
            Verts[vertIndex + 3] = bnw;
            Norms[vertIndex + 0] = north;
            Norms[vertIndex + 1] = north;
            Norms[vertIndex + 2] = north;
            Norms[vertIndex + 3] = north;
            Coords[vertIndex + 0] = voxel.Type.UV.Side.A;
            Coords[vertIndex + 1] = voxel.Type.UV.Side.B;
            Coords[vertIndex + 2] = voxel.Type.UV.Side.C;
            Coords[vertIndex + 3] = voxel.Type.UV.Side.D;
            Inds[indIndex + 0] = vertIndex + 0;
            Inds[indIndex + 1] = vertIndex + 1;
            Inds[indIndex + 2] = vertIndex + 2;
            Inds[indIndex + 3] = vertIndex + 0;
            Inds[indIndex + 4] = vertIndex + 2;
            Inds[indIndex + 5] = vertIndex + 3;
            vertIndex += 4;
            indIndex += 6;

            // East
            Verts[vertIndex + 0] = bse;
            Verts[vertIndex + 1] = tse;
            Verts[vertIndex + 2] = tne;
            Verts[vertIndex + 3] = bne;
            Norms[vertIndex + 0] = east;
            Norms[vertIndex + 1] = east;
            Norms[vertIndex + 2] = east;
            Norms[vertIndex + 3] = east;
            Coords[vertIndex + 0] = voxel.Type.UV.Side.A;
            Coords[vertIndex + 1] = voxel.Type.UV.Side.B;
            Coords[vertIndex + 2] = voxel.Type.UV.Side.C;
            Coords[vertIndex + 3] = voxel.Type.UV.Side.D;
            Inds[indIndex + 0] = vertIndex + 0;
            Inds[indIndex + 1] = vertIndex + 1;
            Inds[indIndex + 2] = vertIndex + 2;
            Inds[indIndex + 3] = vertIndex + 0;
            Inds[indIndex + 4] = vertIndex + 2;
            Inds[indIndex + 5] = vertIndex + 3;
            vertIndex += 4;
            indIndex += 6;

            // Top
            Verts[vertIndex + 0] = tsw;
            Verts[vertIndex + 1] = tnw;
            Verts[vertIndex + 2] = tne;
            Verts[vertIndex + 3] = tse;
            Norms[vertIndex + 0] = up;
            Norms[vertIndex + 1] = up;
            Norms[vertIndex + 2] = up;
            Norms[vertIndex + 3] = up;
            Coords[vertIndex + 0] = voxel.Type.UV.Top.A;
            Coords[vertIndex + 1] = voxel.Type.UV.Top.B;
            Coords[vertIndex + 2] = voxel.Type.UV.Top.C;
            Coords[vertIndex + 3] = voxel.Type.UV.Top.D;
            Inds[indIndex + 0] = vertIndex + 0;
            Inds[indIndex + 1] = vertIndex + 1;
            Inds[indIndex + 2] = vertIndex + 2;
            Inds[indIndex + 3] = vertIndex + 0;
            Inds[indIndex + 4] = vertIndex + 2;
            Inds[indIndex + 5] = vertIndex + 3;
            vertIndex += 4;
            indIndex += 6;
        }

        for (int i = 0; i < numInds; ++i)
            if (Inds[i] < 0 || Inds[i] >= numVerts)
                Debug.Log("Index[" + i + "] out of range: " + Inds[i] + " of " + numVerts);

        Mesh.Clear();
        Mesh.vertices = Verts;
        Mesh.normals = Norms;
        Mesh.uv = Coords;
        Mesh.triangles = Inds;
    }

    public Voxel NeighborOrNull(Voxel voxel, int side)
    {
        IntVec3 index = voxel.Index.Offset(Side.Offset[side]);
        if (index.InRange(XLen, YLen, ZLen))
            return Voxels[index.X, index.Y, index.Z];
        return null;
    }

    public Voxel GetVoxelFromCollider(Collider collider)
    {
        return ColliderToVoxel[collider as BoxCollider];
    }
}
