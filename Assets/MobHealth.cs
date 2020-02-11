using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;
    public Slider m_Slider;
    public Image m_FillImage;
    public MobIA m_IA;

    private Color FullHealthColor = Color.green;
    private Color ZeroHealthColor = Color.red;

    private float m_CurrentHealth;
    private bool m_IsDead;

    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_IsDead = false;
        SetHealthUI();
    }

    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;
        SetHealthUI();

        if (m_CurrentHealth <= 0f && !m_IsDead)
        {
            OnDeath();
        }
    }

    private void SetHealthUI()
    {
        m_Slider.value = m_CurrentHealth/ m_StartingHealth;
        m_FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }

    private void OnDeath()
    {
        m_IsDead = true;
        m_IA.Die();
        gameObject.SetActive(false);
    }
}
