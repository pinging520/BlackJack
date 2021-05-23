using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Blackjack.Models
{
    public class Hand
    {
        public int id { get; set; }
        public int Color { get; set; }
        public int point { get; set; }
        public int Round { get; set; }
        public static int[] Card;

        public static List<Hand> HandCards= new List<Hand>();


        public static int SelectCards(int id)
        {
            int Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());

            var i = from c in HandCards where (c.id == id && c.Round == Round) select c;
            var e = 0;

            

            foreach (var x in i)
            {
                if (x.point > 10)
                {
                    e += 10;
                }
                else if (x.point == 1 && !Start.getset(id))
                {
                    HttpContext.Current.Session[id] = "Ace";
                    e += 11;
                }
                else
                {
                    e += x.point;
                }
 

            }
            return e;
        }

        


       

    }
}