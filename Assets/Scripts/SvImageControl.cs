using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using OculusSampleFramework; // Import Oculus Sample Framework

public class SvImageControl : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Image pickerImage;

    private RawImage SVimage;
    private ColourPickerControl CC;
    private RectTransform rectTransform, pickerTransform;
    private Canvas canvas;

    private void Awake()
    {
        SVimage = GetComponent<RawImage>();
        CC = FindObjectOfType<ColourPickerControl>();
        rectTransform = GetComponent<RectTransform>();
        pickerTransform = pickerImage.GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        pickerTransform.localPosition = new Vector2(-rectTransform.sizeDelta.x * 0.5f, -rectTransform.sizeDelta.y * 0.5f);
    }

    private void UpdateColour(Vector2 localCursor)
    {
        var rect = rectTransform.rect;

        localCursor.x = Mathf.Clamp(localCursor.x, rect.xMin, rect.xMax);
        localCursor.y = Mathf.Clamp(localCursor.y, rect.yMin, rect.yMax);

        float xNorm = (localCursor.x - rect.xMin) / rect.width;
        float yNorm = (localCursor.y - rect.yMin) / rect.height;

        pickerTransform.localPosition = localCursor;
        pickerImage.color = Color.HSVToRGB(0, 0, 1 - yNorm);

        CC.SetSV(xNorm, yNorm);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localCursor;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            UpdateColour(localCursor);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 localCursor;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            UpdateColour(localCursor);
        }
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Vector2 localCursor;
            Vector3 pointerPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, pointerPos, null, out localCursor))
            {
                UpdateColour(localCursor);
            }
        }
    }
}
