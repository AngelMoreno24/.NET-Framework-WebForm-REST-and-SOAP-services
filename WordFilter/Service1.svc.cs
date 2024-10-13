using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;

namespace WordFilter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string WordFilter(string str)
        {

            //creates a list of all possible stop words
            List<string> stopWords = new List<string> { "a", "an", "in", "on",
                    "the", "is", "are", "am", "A", "An", "In", "On",
                    "The", "Is", "Are", "Am"};

            //filter will store the output after the given string is filtered through the list named filtered list
            string filter = "";
            List<string> filtered = new List<string>();

            //temp will store the words and form char by char
            string temp = "";

            //loops through the string once char by char
            for (int i = 0; i < str.Length; i++)
            {

                //checks for XML filter out the XML element tag names and attribute names.
                if (str[i] == '<')
                {
                    //iterates until the end of the XML to not add it as a word
                    while (str[i] != '>')
                    {
                        i++;

                    }
                    i++;

                    //makes sure to not add a space after the XML tag by skipping the char
                    if (str[i] == ' ')
                    {
                        i++;

                    }

                }
                //add char to temp to form a word
                if (str[i] != ' ')
                {
                    temp += str[i];
                }

                //once the char reaches the space at the end of the word, the word is added to the filtered list if it isnt a stop word
                if (str[i] == ' ')
                {
                    //checks if the word is a stop word before adding it to the filtered list
                    if (stopWords.Contains(temp) == false)
                    {
                        filtered.Add(temp);
                    }
                    
                    //empties temp in torder to form the next word
                    temp = "";
                }
            }
            //adds the last word to the filtered list if it belongs
            if (stopWords.Contains(temp) == false)
            {
                filtered.Add(temp);
            }

            //stores the filtered list of strings into a single string called filter
            foreach (string n in filtered)
            {
                 filter += n + " ";
            }

            //returns the filtered string
            return filter;
        }
    }
}
