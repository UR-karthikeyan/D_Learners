using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    private Vector2 originalPosition;  // Store the initial position
    public int id = 0;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition; // Store starting position
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;  // Make it slightly transparent
        canvasGroup.blocksRaycasts = false;  // Allow drop detection
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;  // Move UI element
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;  // Restore visibility
        canvasGroup.blocksRaycasts = true;  // Enable raycasts again

        // Check if dropped on a valid drop zone
        DropZone d = GetDropTarget(eventData);
        if (d != null && d.id == -1)
        {
            d.id  = id;
            d.enableImg();
        }
        rectTransform.anchoredPosition = originalPosition;

    }

    private DropZone GetDropTarget(PointerEventData eventData)
    {
        // Check if pointer is over a UI object
        PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = eventData.position };
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            DropZone dropZone = result.gameObject.GetComponent<DropZone>();
            if (dropZone != null)
            {
                return dropZone; // Return the DropZone component instead of RaycastResult
            }
        }
        return null;
    }

}
