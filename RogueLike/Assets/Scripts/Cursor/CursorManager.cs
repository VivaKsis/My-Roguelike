using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    //TODO delete singleton
    public static CursorManager Instance { get; private set; }

    [SerializeField] private List<CursorAnimation> cursorAnimations;

    private CursorAnimation currentCursorAnimation;
    private int currentFrameIndex, frameCount;
    private float frameTimer, frameRate;

    public enum CursorType
    {
        arrow, 
        attack
    }

    private void Awake()
    {
        Instance = this;
    }

    private CursorAnimation GetCursorAnimation (CursorType cursorType)
    {
        for (int a = 0; a < cursorAnimations.Count; a++)
        {
            if(cursorAnimations[a].cursorType == cursorType)
            {
                return cursorAnimations[a];
            }
        }
        return null;
    }

    private void SetCurrentCursorAnimation(CursorAnimation cursorAnimation)
    {
        currentCursorAnimation = cursorAnimation;
        currentFrameIndex = 0;
        frameTimer = frameRate = currentCursorAnimation.frameRate;
        frameCount = currentCursorAnimation.textureFrames.Length;
    }
    public void SetActiveCursorType(CursorType cursorType)
    {
        SetCurrentCursorAnimation(GetCursorAnimation(cursorType));
    }

    private void Start()
    {
        SetActiveCursorType(CursorType.arrow);
    }

    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if(frameTimer <= 0f)
        {
            frameTimer += frameRate;
            currentFrameIndex = (currentFrameIndex + 1) % frameCount;
            Cursor.SetCursor(currentCursorAnimation.textureFrames[currentFrameIndex], currentCursorAnimation.offset, CursorMode.Auto);
        }
    }

    //TODO make SO
    [System.Serializable]
    public class CursorAnimation
    {
        public CursorType cursorType;
        public Texture2D[] textureFrames;
        public float frameRate;
        public Vector2 offset;
    }
}
