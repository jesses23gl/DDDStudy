using Domain.Commands;
using Domain.core.Bus;
using Domain.Events;
using Domain.Interfaces;
using Domain;
using Domain.Notifications;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterStudentCommand, bool>,
        IRequestHandler<UpdateStudentCommand, bool>,
        IRequestHandler<RemoveStudentCommand, bool>
    {
        private readonly IMemoryCache _cache;
        private readonly IStudentRepository _studentRepository;
        private readonly IMediatorHandler _bus;

        public StudentCommandHandler(IStudentRepository studentRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler bus,
            IMemoryCache cache) : base(unitOfWork, bus, cache)
        {
            _cache = cache;
            _studentRepository = studentRepository;
            _bus = bus;
        }

        //RegisterStudentCommand处理程序
        public Task<bool> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var address = new Address(request.Province, request.City, request.County, request.Street);
            var student = new Student(Guid.NewGuid(), request.Name, request.Email, request.Phone, request.BirthDate,address);

            if (_studentRepository.GetByEmail(request.Email) != null)
            {
                //这里对错误信息进行发布，目前采用缓存形式
                //List<string> errorInfo = new List<string>() { "The customer e-mail has already been taken." };
                //_cache.Set($"ErrorData", errorInfo);


                //使用领域通知

                _bus.RaiseEvent(new DomainNotification("Email_Error", "该邮箱已经被使用！"));
                return Task.FromResult(true);
            }

            _studentRepository.Add(student);
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                _bus.RaiseEvent(new StudentRegisteredEvent(request.Id, request.Name, request.Email, request.BirthDate, request.Phone));

                // waiting....
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        // 手动回收
        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
