using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler,IPointerClickHandler
{
    public Image[] img;
    public Manager manager;
    public int count = 0;
    public int id = 0;
    public int winCount = 2;
    public void OnDrop(PointerEventData eventData)
    {
        if(count >= 6)
        {
            return;
        }
        
        GameObject droppedObject = eventData.pointerDrag;
        DraggableUI ui = droppedObject.GetComponent<DraggableUI>();
        if (ui.id == id)
        {

            enableImg();
        }
    }

    public void enableImg()
    {
        img[count].gameObject.SetActive(true);
        img[count].sprite = manager.allSprites[id];
        img[count].SetNativeSize();
        count++;
        manager.CheckWin();
    }
    private void disableImg()
    {
        count--;
        img[count].sprite = null;
        img[count].gameObject.SetActive(false);
        if (count == 0)
        {
            id = -1;
        }
        manager.CheckWin();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(count > 0)
        {
            disableImg();
        }
    }
}
