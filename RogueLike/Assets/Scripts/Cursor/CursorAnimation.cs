using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateAsset/CursorAnimation")]
public class CursorAnimation : ScriptableObject
{
    public CursorManager.CursorType cursorType;
    public Texture2D[] textureFrames;
    public float frameRate;
    public Vector2 offset;
}
