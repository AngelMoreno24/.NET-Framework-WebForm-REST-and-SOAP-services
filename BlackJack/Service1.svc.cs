using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
namespace BlackJack
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string DealCards()
        {
            //Create list that will store all current cards in deck
            List<string> cards = new List<string>();

            //string asd = "";
            //Get path of ResetDeck.txt
            string directoryPath = HttpContext.Current.Server.MapPath("~/ResetDeck.txt");

            //Read ResetDeck.txt
            StreamReader reader = new StreamReader(directoryPath);
            string data = reader.ReadLine();

            //Get all cards in deck
            while (data != null)
            {
                cards.Add(data);
                data = reader.ReadLine();
            }
            reader.Close();


            //shuffle deck before starting
            int lastIndex = cards.Count - 1;
            while (lastIndex > 0)
            {
                string tempValue = cards[lastIndex];
                int randomIndex = new Random().Next(0, lastIndex);
                cards[lastIndex] = cards[randomIndex];
                cards[randomIndex] = tempValue;
                lastIndex--;
            }


            //variables for dealers cards and their value
            string DealerC1 = "";
            string DealerC2 = "";
            int DealerCard1 = 1;
            int DealerCard2 = 2;

            //chooses 2 random cards and removes them from the deck
            DealerCard1 = new Random().Next(0, cards.Count);
            DealerC1 = cards[DealerCard1].ToString();
            cards.Remove(cards[DealerCard1]);
            while (cards[DealerCard2] == cards[DealerCard1]) //make sure the second card isnt a duplicate
                DealerCard2 = new Random().Next(0, cards.Count);
            DealerC2 = cards[DealerCard2].ToString();
            cards.Remove(cards[DealerCard1]);

            //get path to Dealer.txt
            directoryPath = HttpContext.Current.Server.MapPath("~/Dealer.txt");

            //empty file before adding cards
            System.IO.File.WriteAllText(directoryPath, string.Empty);
            StreamWriter writer = File.AppendText(directoryPath);

            //add cards to file
            writer.WriteLine(DealerC1);
            writer.WriteLine(DealerC2);

            writer.Close();


            //variables for player cards and their value
            string PlayerC1;
            string PlayerC2;
            int PlayerCard1 = 1;
            int PlayerCard2 = 2;

            //choose 2 cards and remove them from deck
            PlayerCard1 = new Random().Next(0, cards.Count);
            PlayerC1 = cards[PlayerCard1].ToString();
            cards.Remove(cards[PlayerCard1]);
            PlayerCard2 = new Random().Next(0, cards.Count);
            while (cards[PlayerCard2] == cards[PlayerCard1]) //make sure the second card isnt a duplicate
                PlayerCard2 = new Random().Next(0, cards.Count);
            PlayerC2 = cards[PlayerCard2].ToString();
            cards.Remove(cards[PlayerCard2]);

            //add cards to Dealer.txt
            directoryPath = HttpContext.Current.Server.MapPath("~/Player.txt");

            //empty file
            System.IO.File.WriteAllText(directoryPath, string.Empty);
            writer = File.AppendText(directoryPath);

            writer.WriteLine(PlayerC1);
            writer.WriteLine(PlayerC2);

            writer.Close();


            //Get path to Deck.txt
            directoryPath = HttpContext.Current.Server.MapPath("~/Deck.txt");

            //empty file before adding cards
            System.IO.File.WriteAllText(directoryPath, string.Empty);

            //add curent cards in deck
            writer = File.AppendText(directoryPath);
            for (int i = 0; i < cards.Count; i++)
            {
                writer.WriteLine(cards[i]);
            }

            writer.Close();


            //return dealer and player cards
            return string.Format("dealer: " + DealerC1 + ", " + DealerC2 + ";" + "Player: " + PlayerC1 + ", " + PlayerC2);
        }




        public string Play(string action, string state)
        {
            //check if game can continue or if player won or lost
            if (state == "Continue")
            {
                //stores value of Cards
                string[,] values = {
                        {"A", "11" },
                        {"2", "2" },
                        {"3", "3" },
                        {"4", "4" },
                        {"5", "5" },
                        {"6", "6" },
                        {"7", "7" },
                        {"8", "8" },
                        {"9", "9" },
                        {"1", "10" },
                        {"K", "10" },
                        {"Q", "10" },
                        {"J", "10" },
                    };

                //create variables to keep track of card names and random number
                int card = 1;
                string cardName = "";

                //check players action. will either be Hit or Stand
                if (action == "Hit")
                {
                    //Create list to stor cards in deck, dealer hand, and player hand
                    List<string> cards = new List<string>();
                    List<string> dealerCards = new List<string>();
                    List<string> playerCards = new List<string>();

                    //Read Deck.txt to get current deck
                    string directoryPath = HttpContext.Current.Server.MapPath("~/Deck.txt");
                    StreamReader reader = new StreamReader(directoryPath);
                    string data = reader.ReadLine();

                    //Get all cards in deck
                    while (data != null)
                    {
                        cards.Add(data);
                        data = reader.ReadLine();
                    }
                    reader.Close();

                    //choose card and remove it from the deck
                    card = new Random().Next(0, cards.Count);
                    cardName = cards[card].ToString();
                    cards.Remove(cards[card]);



                    //Remove used cards from Deck.txt
                    directoryPath = HttpContext.Current.Server.MapPath("~/Deck.txt");
                    System.IO.File.WriteAllText(directoryPath, string.Empty);
                    StreamWriter writer = File.AppendText(directoryPath);
                    for (int i = 0; i < cards.Count; i++)
                    {
                        writer.WriteLine(cards[i]);
                    }
                    writer.Close();


                    //add card to players hand( Hit )
                    directoryPath = HttpContext.Current.Server.MapPath("~/Player.txt");
                    writer = File.AppendText(directoryPath);
                    writer.WriteLine(cardName);
                    writer.Close();


                    //Variables for card values
                    int playerValue = 0;
                    int dealerValue = 0;

                    //get path t Player.txt
                    directoryPath = HttpContext.Current.Server.MapPath("~/Player.txt");
                    reader = new StreamReader(directoryPath);
                    data = reader.ReadLine();


                    //Get all cards in player deck
                    while (data != null)
                    {
                        playerCards.Add(data);
                        data = reader.ReadLine();
                    }
                    reader.Close();

                    //variables for storing card info
                    int das = 0;
                    string temp;
                    //checks the value of players cards.
                    for (int i = 0; i < playerCards.Count; i++)
                    {
                        temp = playerCards[i].ToString();
                        //go through
                        for (int j = 0; j < 13; j++)
                        {
                            if (temp[0].ToString() == values[j, 0])
                            {
                                //add to total value of card
                                playerValue += Int32.Parse(values[j, 1]);
                                das++;
                            }
                        }
                    }

                    //end if player busts 
                    if (playerValue > 21)
                    {
                        //If player has an ace, lower its value to 1
                        if (playerCards.Contains("Ace of Spades") || playerCards.Contains("Ace of Clubs") || playerCards.Contains("Ace of Diamonds") || playerCards.Contains("Ace of Hearts"))
                        {
                            //change value of ace to 1
                            playerValue -= 9;
                            if (playerValue > 21)
                            {
                                return "Lost";
                            }
                        }
                        else
                        {
                            return "Lost";
                        }

                    }

                    //lets game continue
                    return "Continue";
                }
                else
                {

                    //Lists will contain cards of deck,player, and dealer
                    List<string> cards = new List<string>();
                    List<string> dealerCards = new List<string>();
                    List<string> playerCards = new List<string>();

                    //Get path of Deck.txt
                    string directoryPath = HttpContext.Current.Server.MapPath("~/Deck.txt");
                    StreamReader reader = new StreamReader(directoryPath);
                    string data = reader.ReadLine();

                    //Get all cards in deck
                    while (data != null)
                    {
                        cards.Add(data);
                        data = reader.ReadLine();
                    }
                    reader.Close();

                    //keeps track of players card value
                    int playerValue = 0;

                    //get path of Player.txt and read file
                    directoryPath = HttpContext.Current.Server.MapPath("~/Player.txt");
                    reader = new StreamReader(directoryPath);
                    data = reader.ReadLine();


                    //Get all cards in player deck
                    while (data != null)
                    {
                        playerCards.Add(data);
                        data = reader.ReadLine();
                    }
                    reader.Close();

                    //stores card name
                    string temp;

                    //checks the value of players cards.
                    for (int i = 0; i < playerCards.Count; i++)
                    {
                        temp = playerCards[i].ToString();
                        //go through
                        for (int j = 0; j < 13; j++)
                        {
                            if (temp[0].ToString() == values[j, 0])
                            {
                                //add up player's cards
                                playerValue += Int32.Parse(values[j, 1]);

                            }
                        }
                    }

                    //Read dealer.txt for dealers deck
                    directoryPath = HttpContext.Current.Server.MapPath("~/Dealer.txt");
                    reader = new StreamReader(directoryPath);
                    data = reader.ReadLine();

                    //store cards in dealer deck into list
                    while (data != null)
                    {
                        dealerCards.Add(data);
                        data = reader.ReadLine();
                    }
                    reader.Close();

                    int dealerValue = 0;
                    //checks the value of dealers cards.
                    for (int i = 0; i < dealerCards.Count; i++)
                    {
                        temp = dealerCards[i].ToString();
                        //go through
                        for (int j = 0; j < 13; j++)
                        {
                            if (temp[0].ToString() == values[j, 0])
                            {
                                //adds up value of dealer's cards
                                dealerValue += Int32.Parse(values[j, 1]);

                            }
                        }
                    }

                    //if not over 17 dealer hits 
                    while (dealerValue < 17)
                    {
                        //choose card and remove it from deck
                        card = new Random().Next(0, cards.Count);
                        cardName = cards[card].ToString();
                        cards.Remove(cards[card]);

                        //add to dealerCards
                        dealerCards.Add(cardName);

                        //Remove used cards from Deck.txt
                        directoryPath = HttpContext.Current.Server.MapPath("~/Deck.txt");
                        System.IO.File.WriteAllText(directoryPath, string.Empty);

                        //add cards to deck.txt
                        StreamWriter writer = File.AppendText(directoryPath);
                        for (int i = 0; i < cards.Count; i++)
                        {

                            writer.WriteLine(cards[i]);
                        }
                        writer.Close();

                        //add card to dealers hand( HIT )
                        directoryPath = HttpContext.Current.Server.MapPath("~/Dealer.txt");
                        writer = File.AppendText(directoryPath);
                        writer.WriteLine(cardName);
                        writer.Close();

                        //adds up the value of cards after adding a card
                        for (int i = 0; i < dealerCards.Count; i++)
                        {
                            temp = dealerCards[i].ToString();
                            for (int j = 0; j < 13; j++)
                            {
                                if (temp[0].ToString() == values[j, 0])
                                {

                                    dealerValue += Int32.Parse(values[j, 1]);

                                }
                            }
                        }
                    }


                    //check if dealer busts
                    if (dealerValue > 21)
                    {
                        //check if dealer has an Ace
                        if (dealerCards.Contains("Ace of Spades") || dealerCards.Contains("Ace of Clubs") || dealerCards.Contains("Ace of Diamonds") || dealerCards.Contains("Ace of Hearts"))
                        {
                            //change value of ace to 1 if its over 21
                            dealerValue -= 9;
                            if (dealerValue > 21)
                            {
                                return "Win";
                            }
                        }
                        else
                        {
                            return "Win";
                        }

                    }
                    //check who has higher valued cards
                    if (dealerValue < playerValue)
                    {
                        return "Win";
                    }
                    else
                    {
                        return "Lost";
                    }

                    return "Continue";

                }
            }//Player already won            
            else if (state == "Win")
            {
                return "Win";
            }//Player already lost
            else
            {
                return "Lost";
            }

            return "";


        }

        public string Cards()
        {

            //get path of Dealer.txt
            string directoryPath = HttpContext.Current.Server.MapPath("~/Dealer.txt");

            //Read Dealer.txt
            StreamReader reader = new StreamReader(directoryPath);
            string data = reader.ReadLine();

            //variable for dealer cards
            string dealer = "";

            //Get all cards in deck and save them into a string
            dealer += data;
            data = reader.ReadLine();
            while (data != null)
            {
                dealer += "," + data;
                data = reader.ReadLine();
            }
            reader.Close();


            //get path to Player.txt
            directoryPath = HttpContext.Current.Server.MapPath("~/Player.txt");

            //Read Player.txt fo player cards
            reader = new StreamReader(directoryPath);
            data = reader.ReadLine();

            //Will store player cards in a string
            string player = "";

            //Get all cards in players hand
            player += data;
            data = reader.ReadLine();
            while (data != null)
            {
                player += "," + data;
                data = reader.ReadLine();
            }
            reader.Close();

            //output string containing hands of dealer and player
            return dealer + ";  " + player;

        }
    }
}
