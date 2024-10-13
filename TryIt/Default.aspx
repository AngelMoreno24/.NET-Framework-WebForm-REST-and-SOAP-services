<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">

            <h1 id="aspnetTitle1">Account and Blackjack Elective services

            </h1>

            <p> 
                <asp:Label ID="Label8" runat="server" Text="AccountService: This service will read the user input and filter out any stop words."></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label13" runat="server" Text="URL: http://webstrar82.fulton.asu.edu/page1/Service1.svc"></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label14" runat="server" Text="Methods: AccountLogin, parameter type: string, string, return type: string"></asp:Label>

            </p>


            <p>
                <asp:Label ID="Label15" runat="server" Text="Enter a username and password"></asp:Label>

            </p>

            <p>
                <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                <asp:Label ID="Label16" runat="server" Text="output..."></asp:Label>
            </p>

            <p>
                <asp:Button ID="Button6" runat="server" Text="Login" OnClick="Button6_Click" />
            </p>

            <p>
                <asp:Label ID="Label20" runat="server" Text="Method: CreateAccount, parameter type: string, string, return type: string"></asp:Label>

            </p>

            <p>
                <asp:Label ID="Label17" runat="server" Text="Enter a username and password"></asp:Label>
    
            </p>
            <p>
                <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TextBox6" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                <asp:Label ID="Label18" runat="server" Text="output..."></asp:Label>
            </p>

            <p>
                <asp:Button ID="Button7" runat="server" Text="Create Account" OnClick="Button7_Click" />
            </p>

            <p>
            <asp:Label ID="Label19" runat="server" Text="BlackJack: This service will read the user input and filter out any stop words."></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label24" runat="server" Text="BlackJack: This service will register the buttons clicked and call methods to simulate a game of blackjack."></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label21" runat="server" Text="URL: http://webstrar82.fulton.asu.edu/page2/Service1.svc"></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label22" runat="server" Text="Methods: "></asp:Label>

            </p>

            <p>
                <asp:Label ID="Label25" runat="server" Text="DealCards, parameter type: none, return type: string"></asp:Label>

            </p>

            <p>
                <asp:Label ID="Label27" runat="server" Text="Play, parameter type: string, string, return type: string"></asp:Label>

            </p>
            <p>
                <asp:Label ID="Label26" runat="server" Text="Cards, parameter type: none, return type: string"></asp:Label>

            </p>

            <p>
                <asp:Label ID="Label23" runat="server" Text="Click Play to start a new game"></asp:Label>

            </p>

            <p>
                <asp:Button ID="Button3" runat="server" Text="Play" OnClick="Button3_Click" />

            </p>

             
            <p>
                <asp:Label ID="Label28" runat="server" Text="Dealer Cards:"></asp:Label>
                <asp:Label ID="Label29" runat="server" Text="Cards.."></asp:Label>

            </p>
             
            <p>
                <asp:Label ID="Label30" runat="server" Text="Player Cards:"></asp:Label>
                <asp:Label ID="Label31" runat="server" Text="Cards.."></asp:Label>

            </p>


            <p>
                <asp:Button ID="Button4" runat="server" Text="Hit" OnClick="Button4_Click" />
                <asp:Button ID="Button5" runat="server" Text="Stand" OnClick="Button5_Click" />
                <asp:Label ID="Label32" runat="server" Text="Outcome"></asp:Label>
                <asp:Label ID="Label33" runat="server" Text="..."></asp:Label>

            </p>

            
            <h1 id="aspnetTitle">WordFilter and WordCount Required service

            </h1>

            <p> 
                <asp:Label ID="Label4" runat="server" Text="WordFilter service: This service will read the user input and filter out any stop words."></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label9" runat="server" Text="URL: http://webstrar82.fulton.asu.edu/page4/Service1.svc"></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label11" runat="server" Text="Method: WordFilter, parameter type: string, return type: string"></asp:Label>
            </p>

             <p>
                <asp:Label ID="Label1" runat="server" Text="Enter a String to filter out the stop word"></asp:Label>
                
            </p>
            
         
                <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="2000px"></asp:TextBox>
         

            <p>
                <asp:Button ID="Button1" runat="server" Text="Filter" OnClick="Button1_Click" />

            </p>

            <p>
                <asp:Label ID="Label2" runat="server" Text="Output:"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="..."></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label5" runat="server" Text="WordCount service: This service will read in a file from the user input and output a count of every word"></asp:Label>

            </p>
            
            <p>
                <asp:Label ID="Label10" runat="server" Text="URL: https://webstrar82.fulton.asu.edu/page3/Service.svc"></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label12" runat="server" Text="Method: WordCount, parameter type: file, return type: string"></asp:Label>
            </p>

            <p>
                <asp:Label ID="Label6" runat="server" Text="Choose a file to use the service on:"></asp:Label>
            </p>

            <p>
                
                <asp:FileUpload ID="FileUpload1" runat="server" />

            </p>

            <p>
                <asp:Button ID="Button2" runat="server" Text="Count" OnClick="Button2_Click" />
            </p>

            <p>
                <asp:Label ID="Label7" runat="server" Text="Output:"></asp:Label>
            </p>

            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" ReadOnly="True" Height="2000"></asp:TextBox>


        </section>

    </main>

</asp:Content>