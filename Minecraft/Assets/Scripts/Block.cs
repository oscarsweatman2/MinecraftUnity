using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{

    public BlockType Type = BlockType.None;
    public BlockTerrain.BlockDef Definition = null;

    public GameObject Top = null;
    public GameObject North = null;
    public GameObject East = null;
    public GameObject South = null;
    public GameObject West = null;
    public GameObject Bottom = null;

    public Texture TxtTop = null;
    public Texture TxtSide = null;
    public Texture TxtBottom = null;

    public bool Active = true;
    public bool Exposed = true;

    public Block[] Neighbors = new Block[(int)BlockTerrain.Neighbor.NumNeighbors];

    public float Health = 1;

	// Use this for initialization
	void Start () 
    {
	}

    public void RefreshTextures()
    {
        Top.GetComponent<Renderer>().material.mainTexture = Definition.TextureTop;
        North.GetComponent<Renderer>().material.mainTexture = Definition.TextureSide;
        East.GetComponent<Renderer>().material.mainTexture = Definition.TextureSide;
        South.GetComponent<Renderer>().material.mainTexture = Definition.TextureSide;
        West.GetComponent<Renderer>().material.mainTexture = Definition.TextureSide;
        Bottom.GetComponent<Renderer>().material.mainTexture = Definition.TextureBottom;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0.0f)
        {
            this.DestoryBlock();
        }
    }

    public void DestoryBlock()
    {
        Active = false;
        BlockTerrain.Instance.UpdateBlocks();
    }

    public void SetDef(BlockTerrain.BlockDef def)
    {
        Active = true;
        Definition = def;
        Health = Definition.Health;
        RefreshTextures();
    }
}

public enum BlockType
{
    None,
    Grass,
    Dirt,
    Stone
}
