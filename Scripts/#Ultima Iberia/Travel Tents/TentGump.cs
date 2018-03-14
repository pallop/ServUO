//==============================================//
// Created by Dupre					//
//								//
// Thanks to:						//
// Ignacio							//
//==============================================//

using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{   
	public class TentDGump : Gump
	{
		public TentDGump( TentDestroyer tentdestroyer, Mobile owner) : base( 150,75 ) 
		{
			m_TentDestroyer = tentdestroyer;
			owner.CloseGump( typeof( TentDGump ) );
			this.Closable=false;
			this.Disposable=false;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 445, 250, 9200);
			this.AddBackground(10, 10, 425, 160, 3500);
			this.AddLabel(95, 30, 195, @"* ¿Quiere desmontar y empaquetar la tienda? *");
			this.AddLabel(60, 70, 1359, @"Recuerde que segun la advertencia, puede perder");
			this.AddLabel(60, 90, 1359, @"todos los objetos de la mochila, guardelos  ");
			this.AddLabel(60, 110, 1359, @"antes de empaquetarla.");
			this.AddLabel(107, 205, 172, @"Empaquetar");
			this.AddLabel(270, 205, 32, @"Mantener el campamento");
			AddButton( 115, 180, 4023, 4024, 1, GumpButtonType.Reply, 0 );
			AddButton( 295, 180, 4017, 4018, 0, GumpButtonType.Reply, 0 );
		}

		private TentDestroyer m_TentDestroyer; 

		public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
		{ 

			Mobile from = state.Mobile; 

			switch ( info.ButtonID ) 
			{ 
			case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
				{ 
					//Cancel
					from.SendMessage( "has decidido no desmontar." ); 
					break; 
				} 

			case 1: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
				{ 
					
					//RePack 
					m_TentDestroyer.Delete();
					from.AddToBackpack( new TentDeed() ); 
					from.SendMessage( "empaquetas la tienda de campaña" ); 
					break;
				} 
			}
		}}

	public class TentGump : Gump
	{
		public TentGump( Mobile owner ) : base( 150,75 )
		{
			this.Closable=false;
			this.Disposable=false;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(0, 0, 445, 395, 9200);
			this.AddBackground(10, 10, 425, 375, 3500);
			this.AddLabel(40, 140, 1359, @"Esta mochila solo puede ser utilizada por ti.");
			this.AddLabel(140, 200, 195, @"* Advertencia - Precaucion *");
			this.AddLabel(40, 240, 1359, @"Si se desmonta la tienda de campaña,");
			this.AddLabel(40, 260, 1359, @"se eliminara el contenido de la mochila y no se podra recuperar.");
			this.AddLabel(40, 280, 1359, @"ni siquiera por un administrador. Ha sido advertido.");
			this.AddButton(310, 330, 9723, 9724, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			this.AddLabel(135, 50, 195, @"* Al montar su tienda de campaña *");
			this.AddLabel(40, 80, 1359, @"Dentro de la tienda puedes encontrar un petate");
			this.AddLabel(40, 100, 1359, @"con el cual puedes empaquetar la tienda,");
			this.AddLabel(40, 120, 1359, @"En la tienda tambien hay una mochila segura.");
			this.AddLabel(140, 335, 32, @"He leido el aviso.");
		}

		public enum Buttons
		{
			Button1,
		}
	}
}
