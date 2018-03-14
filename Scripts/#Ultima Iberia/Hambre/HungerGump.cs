

using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Commands;

namespace Server.Commands
{
	public class Hungry
	{
		public static void Initialize()
		{
			CommandSystem.Register( "hambre", AccessLevel.Player, new CommandEventHandler( Hungry_OnCommand ) );
			CommandSystem.Register( "sed", AccessLevel.Player, new CommandEventHandler( Hungry_OnCommand ) );
		}
		
		[Usage( "Hunger || Thirst" )]
		[Description( "Show your level of hunger and thirst." )]
		public static void Hungry_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;
			from.CloseGump( typeof( gumpfaim ) );
			from.SendGump( new gumpfaim ( from ) );
			
		}
		
	}
}



namespace Server.Gumps
{
	public class gumpfaim : Gump
	{
		
		public gumpfaim(Mobile from) : base(0,0)
		{
			Closable = true;
			Dragable = true;
			
			AddPage(0);
			
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(177, 234, 222, 96, 9200);
		//	this.AddAlphaRegion(204, 288, 160, 23);
			this.AddImage(192, 288, 11320);
			this.AddImage(352, 288, 11320);
			this.AddImage(357, 231, 10502);
			this.AddImage(194, 231, 10500);
			//this.AddImageTiled(210, 231, 149, 37, 10501);
			this.AddItem( 210, 265, 4155); 
			this.AddItem( 203, 291, 8093);
			this.AddLabel( 238, 265, from.Hunger < 6 ? 33 : 0, string.Format( "Hambre: {0} / 20", from.Hunger));
		//	this.AddImageTiled(258, 171, 58, 59, 5608);
			this.AddLabel( 238, 291, from.Thirst < 6 ? 33 : 0, string.Format( "Sed: {0} / 20", from.Thirst));
			this.AddImage(362, 177, 10410);
			this.AddImage(126, 176, 10400);
			this.AddImage(166, 321, 10420);
			this.AddImage(344, 321, 10430);
			//this.AddImageTiled(220, 331, 131, 18, 10304);
		
			
		}
		
		public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
		{
			
		}
	}
}
