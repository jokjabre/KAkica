using MatBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_Akica.Blazor.Data
{
    public delegate void SendMessageDelegate(string message, MessageType messageType = MessageType.Info);
    public delegate void VoidEventHandler();
    public delegate Task AsyncVoidEventHandler();

    public enum MessageType
    {
        Info,
        Success,
        Error
    }

    public static class DelegatesEnumsExtenstions
    {
        public static MatToastType AsMatType(this MessageType type)
        {
            switch (type)
            {
                case MessageType.Success:
                    return MatToastType.Success;
                case MessageType.Error:
                    return MatToastType.Danger;
                default:
                    return MatToastType.Info;
            }
        }

    }
}
