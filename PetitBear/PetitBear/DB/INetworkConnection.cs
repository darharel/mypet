using System;
using System.Collections.Generic;
using System.Text;

namespace PetitBear.DB
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();

    }
}
