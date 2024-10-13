using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class _Default : Page
    {
        static string state = "Continue";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_TextChanged(object sender, EventArgs e)
        {

        }

        //this button will be used for the word filter service
        protected void Button1_Click(object sender, EventArgs e)
        {
            //creates an object of WordFilter
            WordFilter.Service1Client filter = new WordFilter.Service1Client();

            //performs the service on the user given string and stores it into a string called value
            string value = filter.WordFilter(TextBox1.Text.ToString());

            //displays the filtered string into a label
            Label3.Text = value.ToString();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //uploads the selected file into a file called UploadedFiles
            FileUpload1.SaveAs(Server.MapPath("~/UploadedFiles/" + FileUpload1.FileName));

            //Creates an object of the WordCount service
            WordCount.Service1Client count = new WordCount.Service1Client();

            //stores the correct path of the file into a string
            string get = "\\UploadedFiles\\" + FileUpload1.FileName;

            //makes sure the path is correct and stores it into path
            string path = Server.MapPath(get);

            //calls the WordCount service and store the output into value
            string value = count.WordCount(path.ToString());

            //displays the output in a label
            TextBox2.Text = value.ToString();
        }


        protected void TextBox2_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //creates an object of WordFilter
            BlackJack.Service1Client game = new BlackJack.Service1Client();

            //performs the service on the user given string and stores it into a string called value
            string value = game.DealCards();

            string dealer = "";
            string player = "";

            //reset state value to reset Play() and label for outcome
            state = "Continue";
            Label33.Text = "";

            //seperate dealer and player cards from string
            int i = 0;

            //skip unnecessary chars
            while (value[i] != ':')
                i++;

            //read dealer cards
            while (value[i] != ',')
            {
                dealer += value[i].ToString();
                i++;

            }

            //skip unnecessary chars
            while (value[i] != ':')
                i++;

            //skip unnecessary chars
            i++;

            //read player cards
            while (i < value.Length)
            {
                player += value[i].ToString();
                i++;

            }

            //Displays cards
            Label29.Text = dealer + ", hidden card";
            Label31.Text = player;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            BlackJack.Service1Client game = new BlackJack.Service1Client();

            //performs the service on the user given string and stores it into a string called value
            state = game.Play("Hit", state);
            string output = game.Cards();
            string dealer = "";
            string player = "";
            string dealerAll = "";
            int i = 0;

            //Parse player and dealer cards
            while (output[i] != ',')
            {
                dealer += output[i].ToString();
                dealerAll += output[i].ToString();
                i++;

            }

            //skip unnecessary chars
            while (output[i] != ';')
            {
                dealerAll += output[i].ToString();
                i++;
            }
            //skip unnecessary char
            i++;

            //read player cards
            while (i < output.Length)
            {
                player += output[i].ToString();
                i++;

            }

            //show dealer cards if player lost or won
            if (state == "Lost" || state == "Win")
            {
                Label29.Text = dealerAll;
            }
            else
            {
                Label29.Text = dealer + ", hidden card";
            }

            //display cards and state to user
            Label31.Text = player;
            Label33.Text = state;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            BlackJack.Service1Client game = new BlackJack.Service1Client();

            //performs the service on the user given string and stores it into a string called value
            state = game.Play("Stand", state);
            string output = game.Cards();
            string dealer = "";
            string player = "";

            int i = 0;


            //Parse dealer cards
            while (output[i] != ';')
            {
                dealer += output[i].ToString();
                i++;
            }
            //skip unnecessary char
            i++;

            //read player cards
            while (i < output.Length)
            {
                player += output[i].ToString();
                i++;

            }

            //Display cards and state to user
            Label29.Text = dealer;
            Label31.Text = player;
            Label33.Text = state;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            //Create input for login service

            string username = TextBox3.Text;
            string password = TextBox4.Text;

            string URL = "http://webstrar82.fulton.asu.edu/page1/Service1.svc/AccountLogin?username=" + username + "&password=" + password;

            // create a channel
            WebClient channel = new WebClient();
            // return byte array
            byte[] abc = channel.DownloadData(URL);
            // convert to mem stream
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            // convent to string
            string randString = obj.ReadObject(strm).ToString();

            //tell the user if login was successful or if is doesnt match any accounts
            Label16.Text = randString.ToString();

        }

        protected void Button7_Click(object sender, EventArgs e)
        {

            //Create input for login service

            string username = TextBox5.Text;
            string password = TextBox6.Text;

            string URL = "http://webstrar82.fulton.asu.edu/page1/Service1.svc/CreateAccount?username=" + username + "&password=" + password;

            // create a channel
            WebClient channel = new WebClient();
            // return byte array
            byte[] abc = channel.DownloadData(URL);
            // convert to mem stream
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            // convent to string
            string randString = obj.ReadObject(strm).ToString();

            //tell the user if account was created
            Label18.Text = randString.ToString();

        }
    }
}