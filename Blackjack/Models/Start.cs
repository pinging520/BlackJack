using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;



namespace Blackjack.Models
{
    public class Start
    {
        public static int[] GetCard(int item)
        {

            Random R = new Random();
            //int[] cards = new int[52 * item]; //轉1~13
            int[] Allcard = new int[52 * item]; //總牌數


            for (int x = 0; x < Allcard.Length; x++)
            {
                Allcard[x] = R.Next(1, 53 * item);
                for (int y = 0; y < x; y++)
                {
                    if (Allcard[x] == Allcard[y])
                    {
                        Allcard[x] = R.Next(1, 53 * item);
                        y = -1;
                    }
                }

            }
            /*
            for (int x = 0; x <Allcard.Length ; x++) 
            {
                while (Allcard[x] > 13) { Allcard[x] -= 13; }

                cards[x] = Allcard[x];
            }
            */
            return Allcard;
     
        }

        public static bool getset(string id)
        {
            if (HttpContext.Current.Session[id] != "Ace")
            {
               
                return false;
            }
               
                return true;
            


        }



    }
}