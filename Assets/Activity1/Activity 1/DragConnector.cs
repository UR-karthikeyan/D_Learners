using UnityEngine;

public class DragConnector : MonoBehaviour
{
    public  LineRenderer lineRenderer; // Shared across instances
    private  Transform startPoint; // Start of the connection
    private bool isDragging = false;
    public DropHandler currentDropHandler;
    public int answer = 0;
    public ActivityManager activityManager;
    public int audioInt;
    void Start()
    {
        // Initialize the LineRenderer once
        if (lineRenderer == null)
        {
            GameObject lineObj = new GameObject("LineRenderer");
            lineRenderer = lineObj.AddComponent<LineRenderer>();

            // LineRenderer properties
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.positionCount = 2;
            lineRenderer.enabled = false;
        }
    }

    void OnMouseDown()
    {
        // Set start point
        startPoint = transform;
        isDragging = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.enabled = true;
        activityManager.PlaySoundQuestion(audioInt);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane + 1f; // Adjust depth
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            lineRenderer.SetPosition(1, worldPos);
        }
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            Debug.DrawRay(mousePosition, Vector2.up * 0.1f, Color.red, 1f); // Debug visualization

            if (hit.collider != null)
            {
                //Debug.Log("Hit: " + hit.collider.name); // Log detected object

                DropHandler dropHandler = hit.collider.GetComponent<DropHandler>();
                if (dropHandler != null)
                {
                    currentDropHandler = dropHandler;
                    activityManager.PlaySoundAnswer(audioInt);
                    lineRenderer.SetPosition(1, hit.transform.position);
                    activityManager.CheckWin();
                    return;
                }
                else
                {
                    //Debug.Log("Hit object does not have DropHandler!");
                    lineRenderer.enabled = false;
                    currentDropHandler = null;
                }
            }
            else
            {
                //Debug.Log("Raycast2D did not hit anything.");
                lineRenderer.enabled = false;
                currentDropHandler = null;
            }

            isDragging = false;
        }
    }




}
