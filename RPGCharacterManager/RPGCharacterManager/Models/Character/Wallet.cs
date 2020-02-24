using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public enum eMoneyType
    {
        COPPER,
        SILVER,
        ELECTRUM,
        GOLD,
        PLATINUM
    }

    public class Wallet
    {
        public int copper { get; set; }
        public int silver { get; set; }
        public int electrum { get; set; }
        public int gold { get; set; }
        public int platinum { get; set; }

    }
}
