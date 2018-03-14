using System;
using Server.Network;

namespace Server.Items
{
    public class BreadLoaf : Food
    {
        [Constructable]
        public BreadLoaf() : this(1) { }

        [Constructable]
        public BreadLoaf(int amount)
            : base(amount, 0x103B)
        {
            Weight = 1.0;
            FillFactor = 3;
        }

        public BreadLoaf(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}