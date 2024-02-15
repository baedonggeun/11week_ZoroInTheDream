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
            // �� ������Ÿ�ϰ� �浹���� ��
            TakeDamage(1); // �������� ����
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("�������� ����! ���� ü��: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ���ϰ� �Ǹ� ��� ó��
        }
    }

    void Die()
    {
        // �׾��� �� ó���� ������ ���⿡ �ۼ�
        Destroy(gameObject);
    }
}