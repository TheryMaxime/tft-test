using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    public float m_Speed = 1f;

    private Vector3 m_TargetPosition;
    private bool m_IsDead;
    private bool m_IsOn;
    private bool m_IsStop;

    private void OnEnable()
    {
        m_IsDead = false;
        m_IsOn = true;
        m_IsStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsDead && m_IsOn)
        {
            if (!m_IsStop)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    m_TargetPosition, Time.deltaTime * m_Speed);
                transform.LookAt(m_TargetPosition);
            }
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        m_TargetPosition = point;
        m_IsStop = false;
    }

    public void StopMoving()
    {
        m_IsStop = true;
    }

    public void Die()
    {
        m_IsDead = true;
    }
}
