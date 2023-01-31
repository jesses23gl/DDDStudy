using Domain.core.Bus;
using Domain.core.Commands;
using Domain.Interfaces;
using Domain.Notifications;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private IMemoryCache _cache;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus, IMemoryCache cache)
        {
            _uow = unitOfWork;
            _bus = bus;
            _cache = cache;
        }
        protected void NotifyValidationErrors(Command command) 
        {
            List<string> errorInfos = new List<string>();
            foreach (var error in command.ValidationResult.Errors)
            {
                //errorInfos.Add(error.ErrorMessage);
                //将错误信息提交到事件总线，派发出去
                _bus.RaiseEvent(new DomainNotification("", error.ErrorMessage));
            }
            //_cache.Set("ErrorData", errorInfos);错误做法
        }

        public bool Commit() 
        {
            if(_uow.Commit()) return true;
            return false;
        }
    }
}
