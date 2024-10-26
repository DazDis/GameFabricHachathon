using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class ZoneUnit : MonoBehaviour
    {

        [Header("Events")]
        public UnityEvent<AZone> OnEnter = new UnityEvent<AZone>();
        public UnityEvent<AZone> OnExit = new UnityEvent<AZone>();

    }
}