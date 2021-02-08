using Betgrab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Betgrab.Domain
{
	public static class ModelBuilderExtensions
   {
      public static void Seed(this ModelBuilder modelBuilder)
      {
			#region Nation Variables

			var Albania = "Albania";
			var Andorra = "Andorra";
			var Austria = "Austria";
			var Belarus = "Belarus";
			var Belgium = "Belgium";
			var BosniaAndHerzegovina = ";BosniaandHerzegovina";
			var Bulgaria = "Bulgaria";
			var Croatia = "Croatia";
			var Cyprus = "Cyprus";
			var CzechRepublic = ";CzechRepublic";
			var Denmark = "Denmark";
			var Estonia = "Estonia";
			var FaroeIslands = "FaroeIslands";
			var Finland = "Finland";
			var Gibraltar = "Gibraltar";
			var Greece = "Greece";
			var Hungary = "Hungary";
			var Iceland = "Iceland";
			var Ireland = "Ireland";
			var Israel = "Israel";
			var Kosovo = "Kosovo";
			var Latvia = "Latvia";
			var Liechtenstein = ";Liechtenstein";
			var Lithuania = "Lithuania";
			var Luxembourg = "Luxembourg";
			var Malta = "Malta";
			var Moldova = "Moldova";
			var Montenegro = "Montenegro";
			var Netherlands = "Netherlands";
			var NorthMacedonia = "NorthMacedonia";
			var NorthernIreland = "NorthernIreland";
			var Norway = "Norway";
			var Poland = "Poland";
			var Portugal = "Portugal";
			var Romania = "Romania";
			var Russia = "Russia";
			var SanMarino = "SanMarino";
			var Scotland = "Scotland";
			var Serbia = "Serbia";
			var Slovakia = "Slovakia";
			var Slovenia = "Slovenia";
			var Sweden = "Sweden";
			var Switzerland = "Switzerland";
			var Turkey = "Turkey";
			var Ukraine = "Ukraine";
			var Wales = "Wales";

			#endregion

			modelBuilder.Entity<Nation>().HasData(
				Albania, Andorra, Austria, Belarus, Belgium, BosniaAndHerzegovina, Bulgaria, Croatia, Cyprus, CzechRepublic, Denmark, Estonia, FaroeIslands, 
				Finland, Gibraltar, Greece, Hungary, Iceland, Ireland, Israel, Kosovo, Latvia, Liechtenstein, Lithuania, Luxembourg, Malta, Moldova, 
				Montenegro, Netherlands, NorthMacedonia, NorthernIreland, Norway, Poland, Portugal, Romania, Russia, SanMarino, Scotland, Serbia, 
				Slovakia, Slovenia, Sweden, Switzerland, Turkey, Ukraine, Wales
			);
      }
   }
}
