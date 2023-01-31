using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.Commands;
using Domain.core.Bus;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository _StudentRepository;

        private readonly IMapper _mapper;//用于进行DTO

        private readonly IMediatorHandler Bus;

        public StudentAppService(IStudentRepository StudentRepository,IMapper mapper, IMediatorHandler bus)
        {
            _StudentRepository = StudentRepository;
            _mapper = mapper;   
            Bus= bus;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {

            //第一种写法
            return _mapper.Map<IEnumerable<StudentViewModel>>(_StudentRepository.GetAll());
          //第二种写法 // return _StudentRepository.GetAll().ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_StudentRepository.Get(id));
        }

        public void Register(StudentViewModel StudentViewModel)
        {

            var registerCommand = _mapper.Map<RegisterStudentCommand>(StudentViewModel);

            Bus.SendCommand(registerCommand);
            //var newModel = _mapper.Map<Student>(StudentViewModel);

            //_StudentRepository.Add(newModel);
            //var registerCommand = _mapper.Map<RegisterNewStudentCommand>(StudentViewModel);
        }

        public void Update(StudentViewModel StudentViewModel)
        {
            //var updateCommand = _mapper.Map<UpdateStudentCommand>(StudentViewModel);
        }

        public void Remove(Guid id)
        {
            //var removeCommand = new RemoveStudentCommand(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
