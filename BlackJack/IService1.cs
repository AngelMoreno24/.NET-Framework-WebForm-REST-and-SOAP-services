using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BlackJack
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //Operation will start the game and deal 2 cards to player and dealer
        [OperationContract]
        string DealCards();

        //Operation will hit or stand depending of user input
        [OperationContract]
        string Play(string action, string state);

        //Operation will be used to Read current cards in hands of player and dealer
        [OperationContract]
        string Cards();
    }
}
