using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragPanel : MonoBehaviour,IBeginDragHandler,  IDragHandler,  IEndDragHandler
{




    private RectTransform cachedRectTransform ;
    private RectTransform cachedParentRectTransform;


    //private RectTransform panelRectTransform;
    //// 父节点,这个最好是UI父节点，因为它的矩形大小刚好是屏幕大小  
    //private RectTransform parentRectTransform;
    // 鼠标起点  
    private Vector2 originalLocalPointerPosition;
    //// 面板起点  
    //private Vector3 originalPanelLocalPosition;
    private static int siblingIndex = 0;
    private void Awake()
    {
        cachedRectTransform = GetComponent<RectTransform>();
        cachedParentRectTransform = transform.parent as RectTransform;
        //panelRectTransform = transform.parent as RectTransform;

        cachedRectTransform.anchoredPosition = new Vector2(100, 0);
        cachedRectTransform.localPosition = new Vector3(50,0,100);

    }



    public void OnBeginDrag(PointerEventData data)
    {
        Vector2 localPointerPosition;
        //// 获取本地鼠标位置  
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(cachedRectTransform, data.position, data.pressEventCamera, out localPointerPosition))
        {
            originalLocalPointerPosition = localPointerPosition;
            Debug.Log("onBeginDrag"+ localPointerPosition);
            Debug.Log("onBeginDrag" + data.delta);
        }
        //setPointData(data);
    }

    public void OnDrag(PointerEventData data)
    {
        setPointData(data);
    }

    public void setPointData(PointerEventData data)
    {
        if (ClampToWindow(new Vector3(data.delta.x, data.delta.y, 0)))
        {
            cachedRectTransform.localPosition = cachedRectTransform.localPosition + new Vector3(data.delta.x, data.delta.y, 0);
        }

        //Vector2 localPointerPosition;
        ////// 获取本地鼠标位置  
        //if (RectTransformUtility.ScreenPointToLocalPointInRectangle(cachedRectTransform, data.position, data.pressEventCamera, out localPointerPosition))
        //{
        //    Debug.Log("localPosition" + localPointerPosition);
        //    Debug.Log("onBeginDrag" + data.delta);

        //    Debug.Log("before transform localPosition" + cachedRectTransform.localPosition);
        //    cachedRectTransform.localPosition = cachedRectTransform.localPosition + new Vector3(localPointerPosition.x, localPointerPosition.y, 0);
        //    Debug.Log("after transform localPosition" + cachedRectTransform.localPosition);
        //}

    }




    public void OnEndDrag(PointerEventData eventData)
    {

    }

    bool ClampToWindow(Vector3 offset)
    {
        Vector3[] selfWorldCorners = new Vector3[4];
        cachedRectTransform.GetWorldCorners(selfWorldCorners);

        Vector3[] parentWorldCorners = new Vector3[4];
        cachedParentRectTransform.GetWorldCorners(parentWorldCorners);


        for (int i = 0; i < selfWorldCorners.Length; i++)
        {
            selfWorldCorners[i] = selfWorldCorners[i] + offset;
        }



        //if(selfWorldCorners[0].x >= parentWorldCorners[0].x)
        //{
        //    return true;
        //}


        if (selfWorldCorners[0].x >= parentWorldCorners[0].x
            || selfWorldCorners[0].y >= parentWorldCorners[0].y
            || selfWorldCorners[2].x <= parentWorldCorners[2].x
            || selfWorldCorners[2].y <= parentWorldCorners[2].y)
        {
            return false;
        }
        return true;
        // 面板位置  
        //Vector3 pos = panelRectTransform.localPosition;

        //// 如果是UI父节点，设置面板大小为0，那么最大最小位置为正负屏幕的一半  
        //Vector3 minPosition = parentRectTransform.rect.min - panelRectTransform.rect.min;
        //Vector3 maxPosition = parentRectTransform.rect.max - panelRectTransform.rect.max;

        //pos.x = Mathf.Clamp(panelRectTransform.localPosition.x, minPosition.x, maxPosition.x);
        //pos.y = Mathf.Clamp(panelRectTransform.localPosition.y, minPosition.y, maxPosition.y);

        //panelRectTransform.localPosition = pos;
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
}
