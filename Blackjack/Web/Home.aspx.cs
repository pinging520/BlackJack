using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using Blackjack.Models;


namespace Blackjack.Web
{
    public partial class Home : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                HttpContext.Current.Session.RemoveAll();

                Hit.Visible = false;
                Close.Visible = false;
                Response.Cache.SetNoStore();
            }
            
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            int Round = 1;
            //FirstStart();
            if (HttpContext.Current.Application["Round"] == null)
            {
                
                Hand.HandCards.Clear();
                Hand.Card = Start.GetCard(1);
                Button1.Text = "Round Next";
                HttpContext.Current.Application["Round"] = 1; //場數
                Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());
                
            }
            else
            {
                Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());
                Round++;
                HttpContext.Current.Application["Round"] = Round;
            }

            
            Decks();
            Rd.Text = Round.ToString();
            Game.Text = "";

            Hit.Visible = true;
            Close.Visible = true;
            Button1.Visible =false ;
            
            int User = 2;//共2人
            int get = (User - 1) * 2 + 1;//初3張

            int i = Hand.HandCards.Count;
            int z = 0,y;
            while (z < get) 
            {
                y = Hand.Card[i];
                var color = 1;
                while (y>13) { y -= 13;color++; }
                if (color > 4) { color = color%4==0?1: color % 4; }
                string x = ((3+z)%2).ToString();
                Hand.HandCards.Add(new Hand() {id =x ,Color=color ,point= y ,Round= Round});
                i++;
                z++;
            }
            
            
  
            int total1 = Total("1");
            
            int total = Total("0");
            

            M1.Text = total.ToString();
            U1.Text = total1.ToString();
            Deck.Text = Hand.HandCards.Count.ToString();


            List<Hand> item = Hand.HandCards.FindAll(x => x.id == "0" && x.Round == Round) ;
            ListView.DataSource = item;
            ListView.DataBind();

            List<Hand> item1 = Hand.HandCards.FindAll(x => x.id == "1" && x.Round == Round);
            ListView1.DataSource = item1;
            ListView1.DataBind();

           
           
            
            

            if (total1 == 21)
            {
                Game.Text ="Win!!";
                Hit.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
                
            }

            

        }

        protected void Hit_Click(object sender, EventArgs e)
        {
            int Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());
            
            int i = Hand.HandCards.Count;
            string id = "1";
            //抽牌
            Decks();
            var y = Hand.Card[i];
            var color = 1;
            while (y > 13) { y -= 13; color++; }
            if (color > 4) { color = color % 4 == 0 ? 1 : color % 4; }

            Hand.HandCards.Add(new Hand() { id = id, Color = color, point = y ,Round = Round});
            
            

            
            int total = Total(id);//總分數數 算ACE
            
            U1.Text = total.ToString();

            if (total > 21) 
            {   
                Game.Text = "Lose!!";
                Hit.Visible= false;
                Close.Visible = false;
                Button1.Visible = true;
                
            }
            else if (total == 21) 
            { 
                Game.Text = "Win!!";
                Hit.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
                
            }
            

      
            List<Hand> item = Hand.HandCards.FindAll(x => x.id == "1" && x.Round == Round);
            ListView1.DataSource = item;
            ListView1.DataBind();
            Deck.Text = Hand.HandCards.Count.ToString();



        }

        protected void Close_Click(object sender, EventArgs e)
        {
            int Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());
            var Master = Total("0");
            
            var User = Total("1");
           

            
            int i = Hand.HandCards.Count;
            
            while (Master < User)
            {
                Decks();
                var y = Hand.Card[i];
                var color = 1;
                while (y > 13) { y -= 13; color++; }
                if (color > 4) { color = color % 4 == 0 ? 1 : color % 4; }
                Hand.HandCards.Add(new Hand() { id = "0", Color = color, point = y, Round= Round });
                i++; //抽牌數+1

                int total = Total("0");
                HttpContext.Current.Session["0"] = null;
                Master = total;
            }

            M1.Text = Master.ToString();

            if (Master > User && Master <= 21)
            { Game.Text = "Lose!!";
                Hit.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
            }

            if (Master > 21 || Master < User) 
            { 
                Game.Text = "Win!!";
                Hit.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
            }
            if (Master == User) { Game.Text = "Tie";
                Hit.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
            }

            List<Hand> item = Hand.HandCards.FindAll(x => x.id == "0" && x.Round == Round);
            ListView.DataSource = item;
            ListView.DataBind();
            Deck.Text = Hand.HandCards.Count.ToString();




        }

        //手牌總數-ace
        public static int Total(string id)
        {
            var Total = Hand.SelectCards(id);
            if (Total > 21 && Start.getset(id))
            { Total -= 10; }
            HttpContext.Current.Session[id] = null;
            return Total;

        }

        //算牌庫是否用完
        public bool Decks()
        {
            int i = 1;
            int x = Hand.HandCards.Count;
            
            if (53 % (x+1) == 0)
            {
                while (x >= 52) { x -= 52;i++; }
                
                int[] buff = Start.GetCard(i);
                Hand.Card.CopyTo(buff, 0);
                Hand.Card = buff;
                return true;
            }
            return false;
        }

      

    }
}