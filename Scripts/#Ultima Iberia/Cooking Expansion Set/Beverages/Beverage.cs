using System;
using Server;
using Server.Network;
using Server.Targeting;
using Server.Engines.Plants;
using System.Collections;
using Server.Mobiles;
using Server.Engines.Quests;
using Server.Engines.Quests.Hag;
using Server.Engines.Quests.Matriarch;

namespace Server.Items
{
	public enum BeverageType
	{
		Ale,
		Cider,
		Liquor,
		Milk,
		Wine,
		Water,
        #region Cooking System
        Juice,
        Mead
        #endregion
    }

	public interface IHasQuantity
	{
		int Quantity{ get; set; }
	}

	public interface IWaterSource : IHasQuantity
	{
	}

    #region Cooking System
    public class MagicalKegOfWater : BaseBeverage
	{
		public override int MaxQuantity{ get{ return 100; } }

		public override int ComputeItemID()
		{
			return 6464;
		}

		[Constructable]
		public MagicalKegOfWater() : this( BeverageType.Water ){}

		[Constructable]
		public MagicalKegOfWater( BeverageType type ) : base( type )
		{
			Weight = 10.0;
			Name = "Magical Keg of Water";
			ItemID = 6464;
		}

		public MagicalKegOfWater( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
    #endregion

    [TypeAlias( "Server.Items.BottleAle", "Server.Items.BottleLiquor", "Server.Items.BottleWine" )]
	public class BeverageBottle : BaseBeverage
	{
		public override int BaseLabelNumber{ get{ return 1042959; } }
		public override int MaxQuantity{ get{ return 5; } }
		public override bool Fillable{ get{ return false; } }

		public override int ComputeItemID()
		{
            if (!this.IsEmpty)
			{
                switch (this.Content)
				{
					case BeverageType.Ale: return 0x99F;
					case BeverageType.Cider: return 0x99F;
					case BeverageType.Liquor: return 0x99B;
					case BeverageType.Milk: return 0x99B;
					case BeverageType.Wine: return 0x9C7;
					case BeverageType.Water: return 0x99B;
                    #region Cooking System
                    case BeverageType.Juice: return 0x99B;
					case BeverageType.Mead: return 0x9C7;
                    #endregion
                }
			}

			return 0;
		}

		[Constructable]
		public BeverageBottle( BeverageType type ) : base( type )
		{
            Weight = 1.0;
		}

		public BeverageBottle( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
                    if (CheckType("BottleAle"))
					{
                        Quantity = MaxQuantity;
                        Content = BeverageType.Ale;
					}
                    else if (CheckType("BottleLiquor"))
					{
                        Quantity = MaxQuantity;
                        Content = BeverageType.Liquor;
					}
                    else if (CheckType("BottleWine"))
					{
                        Quantity = MaxQuantity;
                        Content = BeverageType.Wine;
					}
					else
					{
						throw new Exception( World.LoadingType );
					}

					break;
				}
			}
		}
	}

	public class Jug : BaseBeverage
	{
		public override int BaseLabelNumber{ get{ return 1042965; } }
		public override int MaxQuantity{ get{ return 10; } }

		public override int ComputeItemID()
		{
            if (!IsEmpty)
            {
                return 0x9C8;
            }
			return 0;
		}

		[Constructable]
		public Jug( BeverageType type ) : base( type )
		{
            Weight = 1.0;
		}

		public Jug( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class CeramicMug : BaseBeverage
	{
		public override int BaseLabelNumber{ get{ return 1042982; } }
		public override int MaxQuantity{ get{ return 1; } }

		public override int ComputeItemID()
		{
            if (ItemID >= 0x995 && ItemID <= 0x999)
            {
                return ItemID;
            }
            else if (ItemID == 0x9CA)
            {
                return ItemID;
            }
			return 0x995;
		}

		[Constructable]
		public CeramicMug()
		{
            Weight = 1.0;
		}

		[Constructable]
		public CeramicMug( BeverageType type ) : base( type )
		{
            Weight = 1.0;
		}

		public CeramicMug( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class PewterMug : BaseBeverage
	{
		public override int BaseLabelNumber{ get{ return 1042994; } }
		public override int MaxQuantity{ get{ return 1; } }

		public override int ComputeItemID()
		{
            if (ItemID >= 0xFFF && ItemID <= 0x1002)
            {
                return ItemID;
            }
			return 0xFFF;
		}

		[Constructable]
		public PewterMug()
		{
            Weight = 1.0;
		}

		[Constructable]
		public PewterMug( BeverageType type ) : base( type )
		{
            Weight = 1.0;
		}

		public PewterMug( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class Goblet : BaseBeverage
	{
		public override int BaseLabelNumber{ get{ return 1043000; } }
		public override int MaxQuantity{ get{ return 1; } }

		public override int ComputeItemID()
		{
            if (ItemID == 0x99A || ItemID == 0x9B3 || ItemID == 0x9BF || ItemID == 0x9CB)
            {
                return ItemID;
            }
			return 0x99A;
		}

		[Constructable]
		public Goblet()
		{
            Weight = 1.0;
		}

		[Constructable]
		public Goblet( BeverageType type ) : base( type )
		{
            Weight = 1.0;
		}

		public Goblet( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	[TypeAlias( "Server.Items.MugAle", "Server.Items.GlassCider", "Server.Items.GlassLiquor", "Server.Items.GlassMilk",
		  "Server.Items.GlassWine", "Server.Items.GlassWater", "Server.Items.GlassJuice", "Server.Items.GlassMead" )]
	public class GlassMug : BaseBeverage
	{
		public override int EmptyLabelNumber{ get{ return 1022456; } }
		public override int BaseLabelNumber{ get{ return 1042976; } }
		public override int MaxQuantity{ get{ return 5; } }

		public override int ComputeItemID()
		{
			if ( IsEmpty )
				return (ItemID >= 0x1F81 && ItemID <= 0x1F84 ? ItemID : 0x1F81);

			switch ( Content )
			{
				case BeverageType.Ale: return (ItemID == 0x9EF ? 0x9EF : 0x9EE);
				case BeverageType.Cider: return (ItemID >= 0x1F7D && ItemID <= 0x1F80 ? ItemID : 0x1F7D);
				case BeverageType.Liquor: return (ItemID >= 0x1F85 && ItemID <= 0x1F88 ? ItemID : 0x1F85);
				case BeverageType.Milk: return (ItemID >= 0x1F89 && ItemID <= 0x1F8C ? ItemID : 0x1F89);
				case BeverageType.Wine: return (ItemID >= 0x1F8D && ItemID <= 0x1F90 ? ItemID : 0x1F8D);
				case BeverageType.Water: return (ItemID >= 0x1F91 && ItemID <= 0x1F94 ? ItemID : 0x1F91);
				case BeverageType.Juice: return (ItemID >= 0x1F91 && ItemID <= 0x1F94 ? ItemID : 0x1F91);
				case BeverageType.Mead: return (ItemID >= 0x1F8D && ItemID <= 0x1F90 ? ItemID : 0x1F8D);
			}

			return 0;
		}

		[Constructable]
		public GlassMug()
		{
            Weight = 1.0;
		}

		[Constructable]
		public GlassMug( BeverageType type ) : base( type )
		{
            Weight = 1.0;
		}

		public GlassMug( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					if ( CheckType( "MugAle" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Ale;
					}
					else if ( CheckType( "GlassCider" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Cider;
					}
					else if ( CheckType( "GlassLiquor" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Liquor;
					}
					else if ( CheckType( "GlassMilk" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Milk;
					}
					else if ( CheckType( "GlassWine" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Wine;
					}
					else if ( CheckType( "GlassWater" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Water;
					}
					else if ( CheckType( "GlassJuice" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Juice;
					}
					else if ( CheckType( "GlassMead" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Mead;
					}
					else
					{
						throw new Exception( World.LoadingType );
					}

					break;
				}
			}
		}
	}

	[TypeAlias( "Server.Items.PitcherAle", "Server.Items.PitcherCider", "Server.Items.PitcherLiquor",
		 		"Server.Items.PitcherMilk", "Server.Items.PitcherWine","Server.Items.PitcherWater",
				"Server.Items.PitcherJuice", "Server.Items.PitcherMead", "Server.Items.GlassPitcher" )]
	public class Pitcher : BaseBeverage
	{
		public override int BaseLabelNumber{ get{ return 1048128; } }
		public override int MaxQuantity{ get{ return 5; } }

		public override int ComputeItemID()
		{
			if ( IsEmpty )
			{
                if (ItemID == 0x9A7 || ItemID == 0xFF7)
                {
                    return this.ItemID;
                }
				return 0xFF6;
			}

			switch ( Content )
			{
				case BeverageType.Ale:
				{
                    if (ItemID == 0x1F96)
                    {
                        return ItemID;
                    }
					return 0x1F95;
				}
				case BeverageType.Cider:
				{
                    if (ItemID == 0x1F98)
                    {
                        return ItemID;
                    }
					return 0x1F97;
				}
				case BeverageType.Liquor:
				{
                    if (ItemID == 0x1F9A)
                    {
                        return ItemID;
                    }
					return 0x1F99;
				}
				case BeverageType.Milk:
				{
                    if (ItemID == 0x9AD)
                    {
                        return ItemID;
                    }
					return 0x9F0;
				}
				case BeverageType.Wine:
				{
                    if (ItemID == 0x1F9C)
                    {
                        return ItemID;
                    }
					return 0x1F9B;
				}
				case BeverageType.Water:
				{
                    if (ItemID == 0xFF8 || ItemID == 0xFF9 || ItemID == 0x1F9E)
                    {
                        return ItemID;
                    }
					return 0x1F9D;
				}
				case BeverageType.Juice:
				{
                    if (ItemID == 0x1F9C)
                    {
                        return ItemID;
                    }
					return 0x1F9B;
				}
				case BeverageType.Mead:
				{
                    if (ItemID == 0x1F9C)
                    {
                        return ItemID;
                    }
					return 0x1F97;
				}
			}
			return 0;
		}

		[Constructable]
		public Pitcher()
		{
            Weight = 2.0;
		}

		[Constructable]
		public Pitcher( BeverageType type ) : base( type )
		{
			Weight = 2.0;
		}

		public Pitcher( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			if ( this.CheckType( "PitcherWater" ) || this.CheckType( "GlassPitcher" ) )
                base.InternalDeserialize(reader, false);
			else
                base.InternalDeserialize(reader, true);

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					if ( CheckType( "PitcherAle" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Ale;
					}
					else if ( CheckType( "PitcherCider" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Cider;
					}
					else if ( CheckType( "PitcherLiquor" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Liquor;
					}
					else if ( CheckType( "PitcherMilk" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Milk;
					}
					else if ( this.CheckType( "PitcherWine" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Wine;
					}
					else if ( CheckType( "PitcherWater" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Water;
					}
					else if ( CheckType( "GlassPitcher" ) )
					{
						Quantity = 0;
						Content = BeverageType.Water;
					}
					else if ( CheckType( "PitcherJuice" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Juice;
					}
					else if ( CheckType( "PitcherMead" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Mead;
					}
					else
					{
						throw new Exception( World.LoadingType );
					}

					break;
				}
			}
		}
	}

	public abstract class BaseBeverage : Item, IHasQuantity
	{
		private BeverageType m_Content;
		private int m_Quantity;
		private Mobile m_Poisoner;
		private Poison m_Poison;

		public override int LabelNumber
		{
			get
			{
				int num = BaseLabelNumber;

				if ( IsEmpty || num == 0 )
					return EmptyLabelNumber;

				return BaseLabelNumber + (int)m_Content;
			}
		}

		public virtual bool ShowQuantity{ get{ return ( MaxQuantity > 1 ); } }
		public virtual bool Fillable{ get{ return true; } }
		public virtual bool Pourable{ get{ return true; } }

		public virtual  int EmptyLabelNumber{ get{ return base.LabelNumber; } }
		public virtual  int BaseLabelNumber{ get{ return 0; } }

		public abstract int MaxQuantity{ get; }
		public abstract int ComputeItemID();

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsEmpty
		{
			get{ return ( m_Quantity <= 0 ); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool ContainsAlchohol
		{
			get{ return ( !IsEmpty && m_Content != BeverageType.Milk && m_Content != BeverageType.Water ); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsFull
		{
			get{ return ( m_Quantity >= MaxQuantity ); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Poison Poison
		{
			get{ return m_Poison; }
			set{ m_Poison = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Poisoner
		{
			get{ return m_Poisoner; }
			set{ m_Poisoner = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public BeverageType Content
		{
			get{ return m_Content; }
			set
			{
				m_Content = value;

				InvalidateProperties();

				int itemID = ComputeItemID();

                if (itemID > 0)
                {
                    ItemID = itemID;
                }
                else
                {
                    this.Delete();
                }
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Quantity
		{
			get{ return m_Quantity; }
			set
			{
				if ( value < 0 )
					value = 0;
				else if ( value > MaxQuantity )
					value = MaxQuantity;

				m_Quantity = value;

                QuantityChanged();
				InvalidateProperties();

				int itemID = this.ComputeItemID();

				if ( itemID > 0 )
					ItemID = itemID;
				else
					this.Delete();
			}
		}

		public virtual int GetQuantityDescription()
		{
			int perc = ( m_Quantity * 100 ) / MaxQuantity;

			if ( perc <= 0 )
				return 1042975;
			else if ( perc <= 33 )
				return 1042974;
			else if ( perc <= 66 )
				return 1042973;
			else
				return 1042972;
		}

        public virtual void QuantityChanged()
        {
        }

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( ShowQuantity )
				list.Add( GetQuantityDescription() );
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			if ( ShowQuantity )
				LabelTo( from, GetQuantityDescription() );
		}

		public virtual bool ValidateUse( Mobile from, bool message )
		{
			if ( this.Deleted )
				return false;

			if ( !Movable && !Fillable )
			{
				Multis.BaseHouse house = Multis.BaseHouse.FindHouseAt( this );

				if ( house == null || !house.IsLockedDown( this ) )
				{
					if ( message )
						from.SendLocalizedMessage( 502946, "", 0x59 );

					return false;
				}
			}

			if ( from.Map != Map || !from.InRange( GetWorldLocation(), 2 ) || !from.InLOS( this ) )
			{
				if ( message )
					from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 );

				return false;
			}

			return true;
		}

		public virtual void Fill_OnTarget( Mobile from, object targ )
		{
			if ( !IsEmpty || !Fillable || !ValidateUse( from, false ) )
				return;

			if ( targ is BaseBeverage )
			{
				BaseBeverage bev = (BaseBeverage)targ;

				if ( bev.IsEmpty || !bev.ValidateUse( from, true ) )
					return;

				Content = bev.Content;
				Poison = bev.Poison;
				Poisoner = bev.Poisoner;

				if ( bev.Quantity > MaxQuantity )
				{
					Quantity = MaxQuantity;
					bev.Quantity -= MaxQuantity;
				}
				else
				{
					Quantity += bev.Quantity;
					bev.Quantity = 0;
				}
			}
            else if (targ is BaseWaterContainer)
            {
                BaseWaterContainer bwc = targ as BaseWaterContainer;

                if (Quantity == 0 || (Content == BeverageType.Water && !IsFull))
                {
                    Content = BeverageType.Water;

                    int iNeed = Math.Min((MaxQuantity - Quantity), bwc.Quantity);

                    if (iNeed > 0 && !bwc.IsEmpty && !IsFull)
                    {
                        bwc.Quantity -= iNeed;
                        Quantity += iNeed;

                        from.PlaySound(0x4E);
                    }
                }
            }
			else if ( targ is Item )
			{
				Item item = (Item)targ;
				IWaterSource src;

				src = ( item as IWaterSource );

				if ( src == null && item is AddonComponent )
					src = ( ((AddonComponent)item).Addon as IWaterSource );

				if ( src == null || src.Quantity <= 0 )
					return;

				if ( from.Map != item.Map || !from.InRange( item.GetWorldLocation(), 2 ) || !from.InLOS( item ) )
				{
					from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 );
					return;
				}

				Content = BeverageType.Water;
				Poison = null;
				Poisoner = null;

				if ( src.Quantity > MaxQuantity )
				{
					this.Quantity = MaxQuantity;
					src.Quantity -= MaxQuantity;
				}
				else
				{
					Quantity += src.Quantity;
					src.Quantity = 0;
				}

				from.SendLocalizedMessage( 1010089 );
			}
            else if (targ is Cow1)
            {
                Cow1 cow = (Cow1)targ;

                if (cow.TryMilk(from))
                {
                    Content = BeverageType.Milk;
                    Quantity = MaxQuantity;
                    from.SendLocalizedMessage(1080197); // You fill the container with milk.
                }
            }
			else if ( targ is LandTarget )
			{
				int tileID = ((LandTarget)targ).TileID;

				PlayerMobile player = from as PlayerMobile;

				if ( player != null )
				{
					QuestSystem qs = player.Quest;

					if ( qs is WitchApprenticeQuest )
					{
						FindIngredientObjective obj = qs.FindObjective( typeof( FindIngredientObjective ) ) as FindIngredientObjective;

						if ( obj != null && !obj.Completed && obj.Ingredient == Ingredient.SwampWater )
						{
							bool contains = false;

							for ( int i = 0; !contains && i < m_SwampTiles.Length; i += 2 )
								contains = ( tileID >= m_SwampTiles[i] && tileID <= m_SwampTiles[i + 1] );

							if ( contains )
							{
								this.Delete();

								player.SendLocalizedMessage( 1055035 );
								obj.Complete();
							}
						}
					}
				}
			}
		}

		private static int[] m_SwampTiles = new int[]
			{
				0x9C4, 0x9EB,
				0x3D65, 0x3D65,
				0x3DC0, 0x3DC1,
				0x3DC2, 0x3DD9,
				0x3DDB, 0x3DDC,
				0x3DDE, 0x3EF0,
				0x3FF6, 0x3FF6,
				0x3FFC, 0x3FFE,
			};

		#region Effects of achohol
		private static Hashtable m_Table = new Hashtable();

		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( EventSink_Login );
		}

		private static void EventSink_Login( LoginEventArgs e )
		{
			CheckHeaveTimer( e.Mobile );
		}

		public static void CheckHeaveTimer( Mobile from )
		{
			if ( from.BAC > 0 && from.Map != Map.Internal && !from.Deleted )
			{
				Timer t = (Timer)m_Table[from];

				if ( t == null )
				{
					if ( from.BAC > 60 )
						from.BAC = 60;

					t = new HeaveTimer( from );
					t.Start();

					m_Table[from] = t;
				}
			}
			else
			{
				Timer t = (Timer)m_Table[from];

				if ( t != null )
				{
					t.Stop();
					m_Table.Remove( from );

					from.SendLocalizedMessage( 500850 );
				}
			}
		}

		private class HeaveTimer : Timer
		{
			private readonly Mobile m_Drunk;

			public HeaveTimer( Mobile drunk ) : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 5.0 ) )
			{
				this.m_Drunk = drunk;

				this.Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( this.m_Drunk.Deleted || this.m_Drunk.Map == Map.Internal )
				{
					this.Stop();
					m_Table.Remove( m_Drunk );
				}
				else if ( this.m_Drunk.Alive )
				{
					if ( this.m_Drunk.BAC > 60 )
						this.m_Drunk.BAC = 60;

					if ( 10 > Utility.Random( 100 ) )
						--this.m_Drunk.BAC;

					this.m_Drunk.Stam -= 1;
					this.m_Drunk.Mana -= 1;

					if ( Utility.Random( 1, 4 ) == 1 )
					{
						if ( !this.m_Drunk.Mounted )
						{
							this.m_Drunk.Direction = (Direction)Utility.Random( 8 );

							this.m_Drunk.Animate( 32, 5, 1, true, false, 0 );
						}

						this.m_Drunk.PublicOverheadMessage( Network.MessageType.Regular, 0x3B2, 500849 );
					}

					if ( m_Drunk.BAC <= 0 )
					{
						this.Stop();
						m_Table.Remove( m_Drunk );

						this.m_Drunk.SendLocalizedMessage( 500850 );
					}
				}
			}
		}
		#endregion

		public virtual void Pour_OnTarget( Mobile from, object targ )
		{
			if ( IsEmpty || !Pourable || !ValidateUse( from, false ) )
				return;

			if ( targ is BaseBeverage )
			{
				BaseBeverage bev = (BaseBeverage)targ;

				if ( !bev.ValidateUse( from, true ) )
					return;

				if ( bev.IsFull && bev.Content == Content )
				{
					from.SendLocalizedMessage( 500848 );
				}
				else if ( !bev.IsEmpty )
				{
					from.SendLocalizedMessage( 500846 );
				}
				else
				{
					bev.Content = Content;
					bev.Poison = Poison;
					bev.Poisoner = Poisoner;

					if ( Quantity > bev.MaxQuantity )
					{
						bev.Quantity = bev.MaxQuantity;
						Quantity -= bev.MaxQuantity;
					}
					else
					{
						bev.Quantity += Quantity;
						Quantity = 0;
					}

					from.PlaySound( 0x4E );
				}
			}
            else if (from == targ)
            {
                // increase characters thirst value based on type of drink
                if (from.Thirst < 20)
                {
                    switch (Content)
                    {
                        case BeverageType.Water: from.Thirst += 5; break;
                        case BeverageType.Milk: from.Thirst += 4; break;
                        case BeverageType.Ale: from.Thirst -= 3; break;
                        case BeverageType.Wine: from.Thirst -= 1; break;
                        case BeverageType.Cider: from.Thirst += 3; break;
                        case BeverageType.Liquor: from.Thirst -= 2; break;
                    }

                    int iThirst = from.Thirst;
                    if (iThirst < 5)
                    {
                        from.SendMessage("You take a drink but are still extremely thirsty");
                    }
                    else if (iThirst < 10)
                    {
                        from.SendMessage("You take a drink and feel less thirsty");
                    }
                    else if (iThirst < 14)
                    {
                        from.SendMessage("You take a drink and feel much less thirsty");
                    }
                    else if (iThirst < 18)
                    {
                        from.SendMessage("You take a drink and feel more refreshed");
                    }
                    else
                    {
                        from.SendMessage("You take a drink and are no longer thirsty");
                    }
                }
                else
                {
                    from.Thirst = 20;
                }

				if ( ContainsAlchohol )
				{
					int bac = 0;

					switch ( Content )
					{
						case BeverageType.Ale: bac = 1; break;
						case BeverageType.Wine: bac = 2; break;
						case BeverageType.Cider: bac = 3; break;
						case BeverageType.Liquor: bac = 4; break;
					}

					from.BAC += bac;

					if ( from.BAC > 60 )
						from.BAC = 60;

					CheckHeaveTimer( from );
				}

				from.PlaySound( Utility.RandomList( 0x30, 0x2D6 ) );

				if ( m_Poison != null )
					from.ApplyPoison( m_Poisoner, m_Poison );

				--Quantity;
			}
            else if (targ is BaseWaterContainer)
            {
                BaseWaterContainer bwc = targ as BaseWaterContainer;

                if (this.Content != BeverageType.Water)
                {
                    from.SendLocalizedMessage(500842); // Can't pour that in there.
                }
                else if (bwc.Items.Count != 0)
                {
                    from.SendLocalizedMessage(500841); // That has something in it.
                }
                else
                {
                    int itNeeds = Math.Min((bwc.MaxQuantity - bwc.Quantity), Quantity);

                    if (itNeeds > 0)
                    {
                        bwc.Quantity += itNeeds;
                        Quantity -= itNeeds;

                        from.PlaySound(0x4E);
                    }
                }
            }
			else if ( targ is PlantItem )
			{
				((PlantItem)targ).Pour( from, this );
			}
			else if ( targ is AddonComponent &&
				( ((AddonComponent)targ).Addon is WaterVatEast || ((AddonComponent)targ).Addon is WaterVatSouth ) &&
				this.Content == BeverageType.Water )
			{
				PlayerMobile player = from as PlayerMobile;

				if ( player != null )
				{
					SolenMatriarchQuest qs = player.Quest as SolenMatriarchQuest;

					if ( qs != null )
					{
						QuestObjective obj = qs.FindObjective( typeof( GatherWaterObjective ) );

						if ( obj != null && !obj.Completed )
						{
							BaseAddon vat = ((AddonComponent)targ).Addon;

							if ( vat.X > 5784 && vat.X < 5814 && vat.Y > 1903 && vat.Y < 1934 &&
								( (qs.RedSolen && vat.Map == Map.Trammel) || (!qs.RedSolen && vat.Map == Map.Felucca) ) )
							{
								if ( obj.CurProgress + Quantity > obj.MaxProgress )
								{
									int delta = obj.MaxProgress - obj.CurProgress;

									Quantity -= delta;
									obj.CurProgress = obj.MaxProgress;
								}
								else
								{
									obj.CurProgress += Quantity;
									Quantity = 0;
								}
							}
						}
					}
				}
			}
            else if (targ is WaterElemental)
            {
                if (this is Pitcher && Content == BeverageType.Water)
                {
                    EndlessDecanter.HandleThrow(this, (WaterElemental)targ, from);
                }
            }
            else
            {
                from.SendLocalizedMessage(500846); // Can't pour it there.
            }
        }

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsEmpty )
			{
				if ( !Fillable || !this.ValidateUse( from, true ) )
					return;

				from.BeginTarget( -1, true, TargetFlags.None, new TargetCallback( Fill_OnTarget ) );
				SendLocalizedMessageTo( from, 500837 );
			}
			else if ( Pourable && ValidateUse( from, true ) )
			{
				from.BeginTarget( -1, true, TargetFlags.None, new TargetCallback( Pour_OnTarget ) );
				from.SendLocalizedMessage( 1010086 );
			}
		}

		public static bool ConsumeTotal( Container pack, BeverageType content, int quantity )
		{
			return ConsumeTotal( pack, typeof( BaseBeverage ), content, quantity );
		}

		public static bool ConsumeTotal( Container pack, Type itemType, BeverageType content, int quantity )
		{
			Item[] items = pack.FindItemsByType( itemType );

			int total = 0;

			for ( int i = 0; i < items.Length; ++i )
			{
				BaseBeverage bev = items[i] as BaseBeverage;

				if ( bev != null && bev.Content == content && !bev.IsEmpty )
					total += bev.Quantity;
			}

			if ( total >= quantity )
			{
				int need = quantity;

				for ( int i = 0; i < items.Length; ++i )
				{
					BaseBeverage bev = items[i] as BaseBeverage;

					if ( bev == null || bev.Content != content || bev.IsEmpty )
						continue;

					int theirQuantity = bev.Quantity;

					if ( theirQuantity < need )
					{
						bev.Quantity = 0;
						need -= theirQuantity;
					}
					else
					{
						bev.Quantity -= need;
						return true;
					}
				}
			}

			return false;
		}

		public BaseBeverage()
		{
			ItemID = ComputeItemID();
		}

		public BaseBeverage( BeverageType type )
		{
			m_Content = type;
			m_Quantity = MaxQuantity;
			ItemID = ComputeItemID();
		}

		public BaseBeverage( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.Write( (Mobile) m_Poisoner );

			Poison.Serialize( m_Poison, writer );
			writer.Write( (int) m_Content );
			writer.Write( (int) m_Quantity );
		}

		protected bool CheckType( string name )
		{
			return ( World.LoadingType == String.Format( "Server.Items.{0}", name ) );
		}

		public override void Deserialize( GenericReader reader )
		{
            this.InternalDeserialize(reader, true);
		}

        public void InternalDeserialize(GenericReader reader, bool read)
		{
			base.Deserialize( reader );

			if ( !read )
				return;

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					this.m_Poisoner = reader.ReadMobile();
					goto case 0;
				}
				case 0:
				{
					m_Poison = Poison.Deserialize( reader );
					m_Content = (BeverageType)reader.ReadInt();
					m_Quantity = reader.ReadInt();
					break;
				}
			}
		}
	}
}