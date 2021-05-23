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
            Up.Visible = false;
            Close.Visible = false;
            }

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            int Round = 1;
            if (HttpContext.Current.Application["Round"] == null)
            {
                Hand.HandCards.Clear();
                Hand.Card = Start.GetCard(1);
                Button1.Text = "Round Next";
                HttpContext.Current.Application["Round"] = 1; //場數
                Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());
                Session["count"] = 0;
            }
            else
            {
                Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());
                Round++;
                HttpContext.Current.Application["Round"] = Round;
            }

            //FirstStart();


            Up.Visible = true;
            Close.Visible = true;
            Button1.Visible =false ;
            
            int User = 2;//共2人
            int get = (User - 1) * 2 + 1;//初3張

            int i = Convert.ToInt32(Session["count"]); //*********
            int z = 0,y;
            while (z < get) 
            {
                y = Hand.Card[i];
                var color = 1;
                while (y>13) { y -= 13;color++; }

                var x = (3+z)%2;
                Hand.HandCards.Add(new Hand() {id =x ,Color=color ,point= y ,Round= Round});
                i++;
                z++;
            }
            Session["count"] = i;

            //
            int total1 = Hand.SelectCards(1);
            int total = Hand.SelectCards(0);
            M1.Text = total.ToString();
            U1.Text = total1.ToString();
            Session["Master"] = total; //Master - total
            Session["User"] = total1; //User - total
            //
            List<Hand> item = Hand.HandCards.FindAll(x => x.id == 0 && x.Round == Round) ;
            ListView.DataSource = item;
            ListView.DataBind();

            List<Hand> item1 = Hand.HandCards.FindAll(x => x.id == 1 && x.Round == Round);
            ListView1.DataSource = item1;
            ListView1.DataBind();

           
            HttpContext.Current.Session[1] = null;
            HttpContext.Current.Session[0] = null;

            if (total1 == 21)
            {
                U1.Text = total1.ToString() + "恭喜獲勝";
                Up.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
                
            }



        }

        protected void Up_Click(object sender, EventArgs e)
        {
            int Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());

            int i = Convert.ToInt32(Session["count"]);
            var id = 1;
            //抽牌
            var y = Hand.Card[i];
            var color = 1;
            while (y > 13) { y -= 13; color++; }
            
            Hand.HandCards.Add(new Hand() { id = id, Color = color, point = y ,Round = Round});
            i++; //抽牌數+1
            Session["count"] = i;//存抽牌數

            
            int total = Hand.SelectCards(1);//總分數數 算ACE
            //--------------判斷
            if (total > 21 && Start.getset(id))
            { total -= 10; }
            HttpContext.Current.Session[id] = null;

            if (total > 21) 
            {   
                U1.Text = total.ToString() + "你輸了";
                Up.Visible= false;
                Close.Visible = false;
                Button1.Visible = true;
                
            }
            else if (total == 21) 
            { 
                U1.Text = total.ToString() + "恭喜獲勝";
                Up.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
                
            }
            else { U1.Text = total.ToString(); }

      
            List<Hand> item = Hand.HandCards.FindAll(x => x.id == 1 && x.Round == Round);
            ListView1.DataSource = item;
            ListView1.DataBind();


            Session["User"] = total;
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            int Round = Int32.Parse(HttpContext.Current.Application["Round"].ToString());

            var User = Convert.ToInt32(Session["User"]);
            var Master = Convert.ToInt32(Session["Master"]);

            int i = Convert.ToInt32(Session["count"]);

            while (Master < User)
            {
                var y = Hand.Card[i];
                var color = 1;
                while (y > 13) { y -= 13; color++; }
                Hand.HandCards.Add(new Hand() { id = 0, Color = color, point = y, Round= Round });
                i++; //抽牌數+1

                int total = Hand.SelectCards(0);//總分數數 算ACE
                if (total > 21 && Start.getset(0))
                { total -= 10; }
                HttpContext.Current.Session[0] = null;
                Master = total;
            }

            if (Master > User && Master <= 21)
            { U1.Text = "你輸了";
                Up.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
            }

            if (Master > 21 || Master < User) { U1.Text = "你贏了";
                Up.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
            }
            if (Master == User) { U1.Text = "平手";
                Up.Visible = false;
                Close.Visible = false;
                Button1.Visible = true;
            }

            List<Hand> item = Hand.HandCards.FindAll(x => x.id == 0 && x.Round == Round);
            ListView.DataSource = item;
            ListView.DataBind();


            Session["count"] = i;//存抽牌數
            
        }

        public static bool FirstStart()
        {
            if (HttpContext.Current.Application["Round"] == null)
            {
                Hand.HandCards.Clear();
                Hand.Card = Start.GetCard(1);
                HttpContext.Current.Application["Round"] = 1; //場數
                return true;
            }
            else
            {
                int Round;
                Int32.TryParse(HttpContext.Current.Application["Round"].ToString(), out Round);
                Round++;
                HttpContext.Current.Application["Round"] = Round;
                return false;

            }

            
        
        }



    }
}