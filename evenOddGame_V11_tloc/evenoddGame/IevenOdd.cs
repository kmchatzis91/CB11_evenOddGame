using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evenoddGame
{
	interface IevenOdd
	{
		int moneyBet { get; set; }
		int numberofDraws { get; set; }
		int totalEarnings { get; set; }
		void ShowDrawNumbers();
		void calcEarning();
		void runDraw();

	} // interface IevenOdd end //

} // namespace end //
