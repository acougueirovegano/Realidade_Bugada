using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_AnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update

    private Entity entity;

     void Awake() {
        entity = GetComponentInParent<Entity>();
    }
     void DisabledMovement()
    {
        entity.EnableJumpandMove(false);
    }

     void EnableMovement()
    {
        entity.EnableJumpandMove(true);
    }

    void DamageTarget()
    {
        entity.DamageTarget();
    }
}
