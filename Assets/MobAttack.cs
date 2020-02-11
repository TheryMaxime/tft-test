using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    public float m_Damage = 10f;
    public float m_Range = 1f;
    public float m_AttackSpeed = 1f;
    public MobIA m_mobIA;

    private bool m_IsDead;
    private bool m_IsOn;
    private GameObject m_FocusedMob;
    private bool m_CanAttack;
    private float m_AttackTimmer;

    private void OnEnable()
    {
        m_IsDead = false;
        m_IsOn = true;
        m_AttackTimmer = 0f;
        m_FocusedMob = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsOn && !m_IsDead && m_FocusedMob)
        {
            if (!m_FocusedMob.GetComponent<MobIA>().IsDead())
            {
                if (m_CanAttack)
                {
                    if (Vector3.Distance(transform.position, m_FocusedMob.transform.position) < m_Range)
                    {
                        m_mobIA.m_IsAttacking = true;
                        m_FocusedMob.GetComponent<MobHealth>().TakeDamage(m_Damage);
                        m_CanAttack = false;
                        m_AttackTimmer = 0f;
                    }
                    else
                    {
                        m_mobIA.m_IsAttacking = false;
                    }
                }
                else
                {
                    m_AttackTimmer += Time.deltaTime;
                    if (m_AttackTimmer > m_AttackSpeed)
                    {
                        m_CanAttack = true;
                    }
                }
            }
            else
            {
                m_mobIA.InteruptFocus();
            }
        }
    }

    public void SetFocus(GameObject ennemy)
    {
        m_FocusedMob = ennemy;
    }

    public void Die()
    {
        m_IsDead = true;
    }

}
