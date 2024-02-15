using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 적 프로젝타일과 충돌했을 때
            TakeDamage(1); // 데미지를 입음
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("데미지를 입음! 현재 체력: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하가 되면 사망 처리
        }
    }

    void Die()
    {
        // 죽었을 때 처리할 내용을 여기에 작성
        Destroy(gameObject);
    }
}