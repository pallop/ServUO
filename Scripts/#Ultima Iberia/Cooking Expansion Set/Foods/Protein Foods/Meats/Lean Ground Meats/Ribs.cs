
using System;
using Server.Network;

namespace Server.Items
{
    public class Ribs : Food
    {
        [Constructable]
        public Ribs() : this(1) { }

        [Constructable]
        public Ribs(int amount)
            : base(amount, 0x9F2)
        {
            Weight = 1.0;
            FillFactor = 5;
        }

        public Ribs(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }

        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}