using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float moveDistance = 50f; // Khoảng cách di chuyển lên trên
    public float duration = 0.3f;    // Thời gian cho hiệu ứng chuyển động

    private Vector2 originalPosition; // Vị trí gốc của thẻ bài

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Lưu vị trí gốc của thẻ bài
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Tạo tween để di chuyển thẻ bài lên trên
        rectTransform.DOKill(); // Hủy bất kỳ tween nào hiện tại để tránh xung đột
        rectTransform.DOAnchorPosY(originalPosition.y + moveDistance, duration)
            .SetEase(Ease.OutBack); // Thêm hiệu ứng easing để chuyển động mượt mà
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Tạo tween để di chuyển thẻ bài về vị trí gốc
        rectTransform.DOKill(); // Hủy bất kỳ tween nào hiện tại để tránh xung đột
        rectTransform.DOAnchorPos(originalPosition, duration)
            .SetEase(Ease.InBack); // Thêm hiệu ứng easing để chuyển động mượt mà
    }
}