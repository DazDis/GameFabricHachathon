using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Game
{
    public abstract class AZone : MonoBehaviour
    {
        public string ZoneName { get; protected set; }
        public new Collider2D collider;
        public List<Collider2D> TargetsInZone = new List<Collider2D>();

        [Header("Zone Events")]
        public UnityEvent<Collider2D> OnEnter = new UnityEvent<Collider2D>();
        public UnityEvent<Collider2D> OnExit = new UnityEvent<Collider2D>();

        public void Activate()
        {
            if (collider != null)
            {
                collider.enabled = false;
            }
        }

        public void Deactivate()
        {
            if (collider != null)
            {
                collider.enabled = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
           
            TargetsInZone.Add(other);
            OnEnter?.Invoke(other);

            ZoneUnit ZoneUnit = other.GetComponent<ZoneUnit>();
            if (ZoneUnit != null) ZoneUnit.OnEnter.Invoke(this);
           
        }
     
        private void OnTriggerExit2D(Collider2D other)
        {
            if (TargetsInZone.Contains(other))
            {
                TargetsInZone.Remove(other);
                OnExit?.Invoke(other);

                ZoneUnit ZoneUnit = other.GetComponent<ZoneUnit>();
                if (ZoneUnit != null) ZoneUnit.OnExit.Invoke(this);
            }
        }


        
    }
}
