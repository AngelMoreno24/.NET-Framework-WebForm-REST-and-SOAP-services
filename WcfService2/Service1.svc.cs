using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using static System.Net.WebRequestMethods;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //public string WordCount(string file)
        public string WordCount(string file)
        {

            //variables that will store the final output, temporary string, and keys.
            string JSON = "";
            string temp = "sadasd\nasd";
            string word = "";


            //stores the key value pairs in order to make the output
            Dictionary<string, int> data = new Dictionary<string, int>();

            try
            {
                //C:\\Users\\darkw\\source\\repos\\WordFilter\\input.txt
                
                //reads the file and stores it in an object
                StreamReader reader = new StreamReader(file);

                //stores the first line into a string called temp
                temp = reader.ReadLine();

                //iterates through temp line by line until the last line of the file
                while (temp != null)
                {

                    //go through line char by char
                    for (int i = 0; i < temp.Length; i++)
                    {

                        //if the char is not in the alphabet, it is not added to the current word
                        if (temp[i] != ' ' && temp[i] !=  '.' && temp[i] != ',' && temp[i] != '!' && temp[i] != '?' && temp[i] != '"')
                        {
                            word += temp[i];

                        }

                        //when an empty space is found, the current word is added to the dictionary or if already added, it increases the count
                        if (temp[i] == ' ')

                        {

                            if (word != "" || word != null)
                            {
                                //checks if the word is in the dictionary and adds it if it isnt
                                if (data.ContainsKey(word) == false && word != "")

                                {
                                    data.Add(word, 1);
                                }
                                
                                //increases the count of the word if it is alrady in the dicionary
                                else
                                {
                                    data[word] = data[word] + 1;
                                }
                            }

                            //empties the word variable to begin forming the next
                            word = "";

                        }
                    }
                    //checks if the last word in the line is in the dictionary and either adds it or increases the count of the word
                    if (word != "" || word != null) {
                        if (data.ContainsKey(word) == false)
                        {
                            data.Add(word, 1);
                        }
                        else
                        {
                            data[word] = data[word] + 1;
                        }
                    }

                    //empties the word variable to prepare for the next word
                    word = "";

                    //switches the temp variable to the next line
                    temp = reader.ReadLine();
                    
                }

                //closes the StreamReader object
                reader.Close();

                //this loop with add every key/value to a string variable in JSON format
                JSON += "{\n";
                foreach (KeyValuePair<string,int> n in data)
                {
                    JSON += "      \"" + n.Key + "\"" + " : " + n.Value + ", \n";
                    
                }

                

                for (int i = 0; i < 55; i++) {

                    if (JSON[JSON.Length-(i+5)] == ',')
                    {
                        JSON.Remove(i);

                    }

                }
                JSON += "\n}";
            }
            //if The file is not found, the function ends and tells the user that nothing was found
            catch (Exception e)
            {
                return  "nothing found";

            }

            //Returns a string with the JSON data
            return JSON;
        }
    }
}
