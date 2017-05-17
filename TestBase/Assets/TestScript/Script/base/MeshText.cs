using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshText : MonoBehaviour
{


    //[SerializeField]
    //private string _testText = "";

    [SerializeField]
    private string _text = "123123123";
    public string Text
    {
        get { return _text; }
        set
        {
            _text = value;
            GenerateFilter();
        }
    }

    private string lastText = "";
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public Material fontMaterial;
    public Texture fontTexture;
    public TextAsset m_data;


    [HideInInspector]
    public Material material;

    public UIAtlas uiAtlas;

    [SerializeField]
    private Color _color1 = Color.white;
    public Color color1
    {
        get { return _color1; }
        set
        {
            _color1 = value;
        }
    }

    [SerializeField]
    private Color _color2 = Color.white;
    public Color color2
    {
        get { return _color2; }
        set
        {
            _color2 = value;
        }
    }

    public enum HorizontalAlignType
    {
        Left,
        Center,
        Right
    }

    //当text中存在宽度不一致的字体时，计算Center和Right会有误差。不过对于战斗HUD，够用了。
    public HorizontalAlignType HAlignType;


    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
#if UNITY_EDITOR
        meshRenderer.sharedMaterial = fontMaterial;
        material = meshRenderer.sharedMaterial;
#else
        meshRenderer.material = uiAtlas.spriteMaterial;
        material = meshRenderer.material;
#endif
        if (!string.IsNullOrEmpty(_text))
        {
            lastText = Text;
            GenerateFilter();
        }
    }

    private void Update()
    {
        if (lastText != Text)
        {
            lastText = Text;
            GenerateFilter();          
        }
    }

    private BMFont mbFont = new BMFont();
    public void GenerateFilter()
    {

        BMFontReader.Load(mbFont, m_data.name, m_data.bytes);  // 借用NGUI封装的读取类 

        Mesh mesh = new Mesh();

        int length = Text.Length;
        Vector3[] vertices = new Vector3[length << 2];
        Vector2[] uvs = new Vector2[vertices.Length];
        int[] triangles = new int[(length << 1) * 3];
        Texture tex = material.mainTexture;
        Color[] colors = new Color[vertices.Length];
        int tmp = 0;
        float tmp2 = 0;
        switch (HAlignType)
        {
            case HorizontalAlignType.Center:
                tmp2 = -(vertices.Length >> 3);
                break;
            case HorizontalAlignType.Left:
                tmp2 = 0;
                break;
            case HorizontalAlignType.Right:
                tmp2 = -(vertices.Length >> 2);
                break;
            default:
                tmp2 = 0;
                break;
        }
        float r = 1;
        int index = 0;
        for (int i = 0; i < vertices.Length; i += 4)
        {
            tmp = 0;

            string s = Text[i / 4].ToString();

            //r = (mSprite.width * 1.0f / mSprite.height);


            BMGlyph glyph = mbFont.GetGlyph(_text[index], true);
            r = glyph.width * 1.0f / glyph.height;
            //r  = ()
            //setting vertices

            vertices[i] = new Vector3(tmp2, tmp + 1);
            vertices[i + 1] = new Vector3(tmp2, tmp);
            tmp2 += r;
            vertices[i + 2] = new Vector3(tmp2, tmp + 1);
            vertices[i + 3] = new Vector3(tmp2, tmp);


            colors[i] = color1;
            colors[i + 1] = color2;
            colors[i + 2] = color1;
            colors[i + 3] = color2;


            //setting uvs
            //UISpriteData mSprite = uiAtlas.GetSprite(s);
            //Rect inner = new Rect(mSprite.x + mSprite.borderLeft, mSprite.y + mSprite.borderTop,
            //    mSprite.width - mSprite.borderLeft - mSprite.borderRight,
            //    mSprite.height - mSprite.borderBottom - mSprite.borderTop);
            Rect inner = new Rect(glyph.x, glyph.y, glyph.width, glyph.height);
            inner = MathUtil.ConvertToTexCoords(inner, tex.width, tex.height);

            uvs[i] = new Vector2(inner.xMin, inner.yMax);
            uvs[i + 1] = new Vector2(inner.xMin, inner.yMin);
            uvs[i + 2] = new Vector2(inner.xMax, inner.yMax);
            uvs[i + 3] = new Vector2(inner.xMax, inner.yMin);

            index = index + 1;
        }

        for (int i = 0; i < triangles.Length; i += 6)
        {
            tmp = (i / 3) << 1;
            triangles[i] = triangles[i + 3] = tmp;
            triangles[i + 1] = triangles[i + 5] = tmp + 3;
            triangles[i + 2] = tmp + 1;
            triangles[i + 4] = tmp + 2;
        }
        mesh.vertices = vertices;
        mesh.colors = colors;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        meshFilter.mesh = mesh;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        DrawMesh();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        DrawMesh();
    }

    private void DrawMesh()
    {
        if (meshFilter == null)
        {
            return;
        }
        Mesh mesh = meshFilter.sharedMesh;
        if (mesh == null)
        {
            return;
        }
        int[] tris = mesh.triangles;
        for (int i = 0; i < tris.Length; i += 3)
        {
            Gizmos.DrawLine(convert2World(mesh.vertices[tris[i]]), convert2World(mesh.vertices[tris[i + 1]]));
            Gizmos.DrawLine(convert2World(mesh.vertices[tris[i]]), convert2World(mesh.vertices[tris[i + 1]]));
            Gizmos.DrawLine(convert2World(mesh.vertices[tris[i]]), convert2World(mesh.vertices[tris[i + 2]]));
            Gizmos.DrawLine(convert2World(mesh.vertices[tris[i + 1]]), convert2World(mesh.vertices[tris[i + 2]]));
        }
    }

    private Vector3 convert2World(Vector3 src)
    {
        return transform.TransformPoint(src);
    }
}
