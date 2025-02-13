using UnityEngine;

namespace PlayerSettings.PlayerConfigs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Movement")]
        public float MovementSpeed;
    }
}