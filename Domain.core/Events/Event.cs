using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.core.Events
{
    public abstract class Event : INotification //INotification 发布/订阅模式
    {
        public DateTime TimeStamp { get; private set; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
