using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServiceBus.Services.IService
{
    public  interface IMessage
    {
        Task publishMessage(object message, string Topic_Queue_Name);
      
    }
}
