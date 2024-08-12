using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class CardInHandUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float duration = 0.2f;
    public HorizontalLayoutGroup horizontalLayoutGroup;
    private Tween currentTween;
    [SerializeField]private float spacingIncrease; // Khoảng cách tăng thêm khi hover
    [SerializeField]private float originalSpacing; // Khoảng cách gốc

    private void Start()
    {
        // Lưu giá trị khoảng cách gốc
        if (horizontalLayoutGroup != null)
        {
            originalSpacing = horizontalLayoutGroup.spacing;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Hủy tween hiện tại nếu có
        currentTween?.Kill();

        // Tạo tween để phóng to UI
        currentTween = transform.DOScale(hoverScale, duration)
            .SetEase(Ease.OutBack); // Thêm hiệu ứng easing để chuyển động mượt mà hơn

        // Tạo tween để tăng khoảng cách giữa các thẻ bài
        if (horizontalLayoutGroup != null)
        {
            DOTween.To(() => horizontalLayoutGroup.spacing, x => horizontalLayoutGroup.spacing = x, originalSpacing + spacingIncrease, duration)
                .SetEase(Ease.OutBack);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hủy tween hiện tại để tránh xung đột và lãng phí tài nguyên
        currentTween?.Kill();

        // Tạo tween để thu nhỏ UI về kích thước ban đầu
        currentTween = transform.DOScale(Vector3.one, duration)
            .SetEase(Ease.InBack); // Thêm hiệu ứng easing để chuyển động mượt mà hơn

        // Tạo tween để khôi phục khoảng cách giữa các thẻ bài
        if (horizontalLayoutGroup != null)
        {
            DOTween.To(() => horizontalLayoutGroup.spacing, x => horizontalLayoutGroup.spacing = x, originalSpacing, duration)
                .SetEase(Ease.InBack);
        }
    }
}
