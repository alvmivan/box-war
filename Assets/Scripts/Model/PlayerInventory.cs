using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class PlayerInventory
    {
        public List<WeaponInfo> weapons;
        public int playerExperience;
    }
}