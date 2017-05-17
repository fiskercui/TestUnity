﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MyFont
{

    [HideInInspector]
    [SerializeField]
    Font m_myFont;
    public Font myFont
    {
        get
        {
            return m_myFont;
        }
        set
        {
            m_myFont = value;
        }
    }

    [HideInInspector]
    [SerializeField]
    Texture pTexture;
    public Texture texture
    {
        get
        {
            return pTexture;
        }
        set
        {
            pTexture = value;
        }
    }
    //public Font m_myFont;
    public TextAsset m_data;
    private BMFont mbFont = new BMFont();
    void Start()
    {
        BMFontReader.Load(mbFont, m_data.name, m_data.bytes);  // 借用NGUI封装的读取类 
        CharacterInfo[] characterInfo = new CharacterInfo[mbFont.glyphs.Count];
        for (int i = 0; i < mbFont.glyphs.Count; i++)
        {
            BMGlyph bmInfo = mbFont.glyphs[i];
            CharacterInfo info = new CharacterInfo();
            info.index = bmInfo.index;
            info.uv.x = (float)bmInfo.x / (float)mbFont.texWidth;
            info.uv.y = 1 - (float)bmInfo.y / (float)mbFont.texHeight;
            info.uv.width = (float)bmInfo.width / (float)mbFont.texWidth;
            info.uv.height = (float)bmInfo.height / (float)mbFont.texHeight;
            info.vert.x = (float)bmInfo.offsetX;
            info.vert.y = (float)bmInfo.offsetY;
            //info.vert.y = 0f;//自定义字库UV从下往上，所以这里不需要偏移，填0即可。  
            info.vert.width = (float)bmInfo.width;
            info.vert.height = (float)bmInfo.height;
            info.width = (float)bmInfo.advance;
            characterInfo[i] = info;
        }
        m_myFont.characterInfo = characterInfo;
    }
}
