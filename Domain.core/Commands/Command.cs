using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;

namespace Domain.core.Commands
{
    public abstract class Command : IRequest<bool>  //IRequest 请求/响应模式，对比发布/订阅模式
    {
        //时间戳
        public DateTime Timestamp { get; private set; }

        //验证结果，需要引用FluentValidation
        public ValidationResult ValidationResult { get; set; }

        protected Command() => Timestamp = DateTime.Now;

        //定义抽象方法，是否有效
        public abstract bool IsValid();
    }
}
