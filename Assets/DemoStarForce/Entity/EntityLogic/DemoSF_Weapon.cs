using System;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 武器类。
/// </summary>
public class DemoSF_Weapon : EntityLogic {
    private const string AttachPoint = "Weapon Point";

    private float m_NextAttackTime = 0f;
    private float m_AttackInterval = 0.5f;

    protected override void OnInit (object userData) {
        base.OnInit (userData);
    }

    protected override void OnShow (object userData) {
        base.OnShow (userData);

        int ownerId = Convert.ToInt32(userData);

        // 附加到父实体身上
        DemoSF_GameEntry.Entity.AttachEntity (Entity, ownerId, AttachPoint);
    }

    protected override void OnAttachTo (EntityLogic parentEntity, Transform parentTransform, object userData) {
        base.OnAttachTo (parentEntity, parentTransform, userData);

        CachedTransform.localPosition = Vector3.zero;
    }

    public void TryAttack () {
        if (Time.time < m_NextAttackTime) {
            return;
        }

        m_NextAttackTime = Time.time + m_AttackInterval;

        Log.Debug("发射子弹");
        // DemoSF_GameEntry.Entity.ShowBullet (new BulletData (DemoSF_GameEntry.Entity.GenerateSerialId (), m_WeaponData.BulletId, m_WeaponData.OwnerId, m_WeaponData.OwnerCamp, m_WeaponData.Attack, m_WeaponData.BulletSpeed) {
        //     Position = CachedTransform.position,
        // });
    }
}