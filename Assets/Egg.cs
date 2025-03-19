using UnityEngine;

public class Egg : MonoBehaviour
{
    public Sprite brokenEggSprite; // Ảnh trứng bể
    public Animator scoreAnimator; // Animator hiển thị số điểm

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket")) // Chạm giỏ thì tăng điểm và biến mất
        {
            IncreaseScore();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground")) // Chạm đất thì đổi sprite thành trứng bể
        {
            GetComponent<SpriteRenderer>().sprite = brokenEggSprite;
            Destroy(gameObject, 1f); // Xóa trứng bể sau 1 giây
        }
    }

    void IncreaseScore()
    {
        if (scoreAnimator != null)
        {
            scoreAnimator.Play("Pts", 0, 0f);  // Reset animation về đầu
            scoreAnimator.SetTrigger("NextFrame");  // Chuyển frame tiếp theo
        }
    }
}
