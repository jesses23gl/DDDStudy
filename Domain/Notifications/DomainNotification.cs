using Domain.core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Notifications
{
    /// <summary>
    /// 领域通知模型，用来获取当前总线中出现的通知信息
    /// 继承自领域事件和 INotification（也就意味着可以拥有中介的发布/订阅模式）
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
        public DomainNotification(string _key, string _value)
        {
            DomainNotificationId = new Guid();
            Version = 1;
            Key = _key;
            Value = _value;
        }
    }
}
