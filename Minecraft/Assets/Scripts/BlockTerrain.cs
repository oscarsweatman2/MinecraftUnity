using UnityEngine;
using System.Collections;

public class BlockTerrain : MonoBehaviour
{
    public static BlockTerrain Instance = null;

    public enum Neighbor
    {
        TopNorthWest,
        TopNorth,
        TopNorthEast,
        TopWest,
        Top,
        TopEast,
        TopSouthWest,
        TopSouth,
        TopSouthEast,
        NorthWest,
        North,
        NorthEast,
        West,
        East,
        SouthWest,
        South,
        SouthEast,
        BottomNorthWest,
        BottomNorth,
        BottomNorthEast,
        BottomWest,
        Bottom,
        BottomEast,
        BottomSouthWest,
        BottomSouth,
        BottomSouthEast,
        NumNeighbors
    }

    public Transform Player = null;

    public int Width = 10;
    public int Depth = 10;
    public int Height = 10;

    public float BlockSize = 1.0f;

    public Block BlockPrefab = null;

    public BlockDef DefGrass = new BlockDef();
    public BlockDef DefDirt = new BlockDef();
    public BlockDef DefStone = new BlockDef();

    public Texture2D Map;

    public int NumBlocks = 0;
    private Block[,,] Blocks = null;
    private Block[] AllBlocks = null;

	void Start () 
    {
        Instance = this;

        NumBlocks = Width * Height * Depth;

        Blocks = new Block[Width, Height, Depth];
        AllBlocks = new Block[NumBlocks];
        
        // Create All Blocks
        for (int x = 0; x < Width; ++x)
            for (int y = 0; y < Height; ++y)
                for (int z = 0; z < Depth; ++z)
                {
                    Vector3 position = new Vector3(x * BlockSize, y * BlockSize, z * BlockSize);
                    Block block = Instantiate(BlockPrefab, position, Quaternion.identity) as Block;
                    block.gameObject.name = "Block(" + x + ", " + y + ", " + z + ")";
                    block.Exposed = false;
                    block.SetDef(DefGrass);
                    block.transform.parent = this.transform;
                    Blocks[x, y, z] = block;
                    AllBlocks[(x * Width * Height) + (y * Width) + z] = block;
                }

        // Assign Neighbors
        for (int x = 0; x < Width; ++x)
            for (int y = 0; y < Height; ++y)
                for (int z = 0; z < Depth; ++z)
                {
                    Block block = Blocks[x, y, z];

                    if ((x - 1 >= 0) && (y + 1 < Height) && (z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.TopNorthWest] = Blocks[x - 1, y + 1, z + 1];
                    if ((y + 1 < Height) && (z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.TopNorth] = Blocks[x, y + 1, z + 1];
                    if ((x + 1 < Width) && (y + 1 < Height) && (z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.TopNorthEast] = Blocks[x + 1, y + 1, z + 1];
                    if ((x - 1 >= 0) && (y + 1 < Height))
                        block.Neighbors[(int)Neighbor.TopWest] = Blocks[x - 1, y + 1, z];
                    if ((y + 1 < Height))
                        block.Neighbors[(int)Neighbor.Top] = Blocks[x, y + 1, z];
                    if ((x + 1 < Width) && (y + 1 < Height))
                        block.Neighbors[(int)Neighbor.TopEast] = Blocks[x + 1, y + 1, z];
                    if ((x - 1 >= 0) && (y + 1 < Height) && (z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.TopSouthWest] = Blocks[x - 1, y + 1, z - 1];
                    if ((y + 1 < Height) && (z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.TopSouth] = Blocks[x, y + 1, z - 1];
                    if ((x + 1 < Width) && (y + 1 < Height) && (z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.TopSouthEast] = Blocks[x + 1, y + 1, z - 1];
                    if ((x - 1 >= 0) && (z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.NorthWest] = Blocks[x - 1, y, z + 1];
                    if ((z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.North] = Blocks[x, y, z + 1];
                    if ((x + 1 < Width) && (z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.NorthEast] = Blocks[x + 1, y, z + 1];
                    if ((x - 1 >= 0))
                        block.Neighbors[(int)Neighbor.West] = Blocks[x - 1, y, z];
                    if ((x + 1 < Width))
                        block.Neighbors[(int)Neighbor.East] = Blocks[x + 1, y, z];
                    if ((x - 1 >= 0) && (z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.SouthWest] = Blocks[x - 1, y, z - 1];
                    if ((z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.South] = Blocks[x, y, z - 1];
                    if ((x + 1 < Width) && (z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.SouthEast] = Blocks[x + 1, y, z - 1];
                    if ((x - 1 >= 0) && (y - 1 >= 0) && (z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.BottomNorthWest] = Blocks[x - 1, y - 1, z + 1];
                    if ((y - 1 >= 0) && (z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.BottomNorth] = Blocks[x, y - 1, z + 1];
                    if ((x + 1 < Width) && (y - 1 >= 0) && (z + 1 < Depth))
                        block.Neighbors[(int)Neighbor.BottomNorthEast] = Blocks[x + 1, y - 1, z + 1];
                    if ((x - 1 >= 0) && (y - 1 >= 0))
                        block.Neighbors[(int)Neighbor.BottomWest] = Blocks[x - 1, y - 1, z];
                    if ((y - 1 >= 0))
                        block.Neighbors[(int)Neighbor.Bottom] = Blocks[x, y - 1, z];
                    if ((x + 1 < Width) && (y - 1 >= 0))
                        block.Neighbors[(int)Neighbor.BottomEast] = Blocks[x + 1, y - 1, z];
                    if ((x - 1 >= 0) && (y - 1 >= 0) && (z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.BottomSouthWest] = Blocks[x - 1, y - 1, z - 1];
                    if ((y - 1 >= 0) && (z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.BottomSouth] = Blocks[x, y - 1, z - 1];
                    if ((x + 1 < Width) && (y - 1 >= 0) && (z - 1 >= 0))
                        block.Neighbors[(int)Neighbor.BottomSouthEast] = Blocks[x + 1, y - 1, z - 1];
                }

        Player.position = new Vector3(Width * 0.5f, Height + BlockSize * 5.0f, Depth * 0.5f);

        Gen();

        UpdateBlocks();
	}

    public void Gen()
    {
        // Height Map
        for (int x = 0; x < Width; ++x)
            for (int y = 0; y < Height; ++y)
                for (int z = 0; z < Depth; ++z)
                {
                    Block block = Blocks[x, y, z];

                    float xr = (float)x / (float)Width;
                    float yr = (float)y / (float)Height;
                    float zr = (float)z / (float)Depth;

                    float val = Map.GetPixel((int)(xr * Map.width), (int)(zr * Map.height)).r;

                    block.Active = yr < val;
                }

        // Erosion... ish
        for (int x = 0; x < Width; ++x)
            for (int y = 0; y < Height; ++y)
                for (int z = 0; z < Depth; ++z)
                {
                    Block block = Blocks[x, y, z];
                    float erodeChance = 0.0f;
                    //foreach (Block neighbor in block.Neighbors)
                    //    if (neighbor == null || (block != null && block.Active == false))
                    //        erodeChance += 0.05f;
                    if (Random.value < erodeChance)
                        block.Active = false;
                }

        // Block Type
        for (int x = 0; x < Width; ++x)
            for (int y = 0; y < Height; ++y)
                for (int z = 0; z < Depth; ++z)
                {
                    Block block = Blocks[x, y, z];

                    if (block.Active == false)
                        continue;

                    BlockDef def = DefDirt;

                    if (y < 2)
                        def = DefStone;

                    if (def == DefDirt)
                    {
                        Block above = block.Neighbors[(int)Neighbor.Top];
                        if (above == null || (above != null && above.Active == false))
                            def = DefGrass;
                    }

                    block.SetDef(def);
                }
    }

    public void UpdateBlocks()
    {
        Block block = null;
        for (int x = 0; x < Width; ++x)
            for (int y = 0; y < Height; ++y)
                for (int z = 0; z < Depth; ++z)
                {
                    block = Blocks[x, y, z];

                    if (block.Active)
                    {
                        Block top = block.Neighbors[(int)Neighbor.Top];
                        Block north = block.Neighbors[(int)Neighbor.North];
                        Block east = block.Neighbors[(int)Neighbor.East];
                        Block south = block.Neighbors[(int)Neighbor.South];
                        Block west = block.Neighbors[(int)Neighbor.West];
                        Block bottom = block.Neighbors[(int)Neighbor.Bottom];

                        bool topShowing = false;
                        bool northShowing = false;
                        bool eastShowing = false;
                        bool southShowing = false;
                        bool westShowing = false;
                        bool bottomShowing = false;

                        if (top == null || top.Active == false)
                        {
                            block.Exposed = true;
                            topShowing = true;
                        }
                        if (north == null || north.Active == false)
                        {
                            block.Exposed = true;
                            northShowing = true;
                        }
                        if (east == null || east.Active == false)
                        {
                            block.Exposed = true;
                            eastShowing = true;
                        }
                        if (south == null || south.Active == false)
                        {
                            block.Exposed = true;
                            southShowing = true;
                        }
                        if (west == null || west.Active == false)
                        {
                            block.Exposed = true;
                            westShowing = true;
                        }
                        if (bottom == null || bottom.Active == false)
                        {
                            block.Exposed = true;
                            bottomShowing = true;
                        }

                        block.Top.SetActive(topShowing);
                        block.North.SetActive(northShowing);
                        block.East.SetActive(eastShowing);
                        block.South.SetActive(southShowing);
                        block.West.SetActive(westShowing);
                        block.Bottom.SetActive(bottomShowing);
                    }
                    else
                    {
                        block.Exposed = false;
                    }

                    block.gameObject.SetActive(block.Exposed);
                }
    }

    [System.Serializable]
    public class BlockDef
    {
        public float Health = 1;
        public Texture TextureTop;
        public Texture TextureSide;
        public Texture TextureBottom;
    }
}
