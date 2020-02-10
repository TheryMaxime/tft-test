using System.Collections.Generic;
using UnityEngine;

public class MobIA : MonoBehaviour
{
    public float m_Player;
    public bool m_IsAttacking;
    public List<GameObject> m_Ennemies;
    public MobMovement m_Movement;
    public MobAttack m_Attack;

    private bool m_IsDead;
    private bool m_IsOn;
    private GameObject m_FocusedMob;
    private bool m_AsFocus;

    private void OnEnable()
    {
        m_IsDead = false;
        m_IsOn = true;
        m_AsFocus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsOn && !m_IsDead)
        {
            if (!m_AsFocus)
            {
                GetFocus();
                m_Attack.SetFocus(m_FocusedMob);
            }
            else
            {
                if (!m_IsAttacking)
                {
                    m_Movement.MoveToPoint(m_FocusedMob.transform.position);
                }
                else
                {
                    m_Movement.StopMoving();
                }
            }
        }
    }

    public void InteruptFocus()
    {
        m_AsFocus = false;
    }

    public void Die()
    {
        m_IsDead = true;
        m_Movement.Die();
        m_Attack.Die();
    }

    public bool IsDead()
    {
        return m_IsDead;
    }

    private void GetFocus()
    {
        GameObject closestEnnemy = null;
        foreach (GameObject ennemy in m_Ennemies)
        {
            if (!ennemy.GetComponent<MobIA>().IsDead())
            {
                if (!closestEnnemy)
                {
                    closestEnnemy = ennemy;
                }
                if (Vector3.Distance(transform.position, ennemy.transform.position)
                    < Vector3.Distance(transform.position, closestEnnemy.transform.position))
                {
                    closestEnnemy = ennemy;
                }
            }
        }
        m_AsFocus = true;
        m_FocusedMob = closestEnnemy;
    }


}
