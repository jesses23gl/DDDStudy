﻿using Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations
{
    //FluentValidation // AbstractValidator
    public abstract class StudentValidation<T>: AbstractValidator<T> where T: StudentCommand
    {
        //受保护方法，验证Name
        protected void ValidateName() 
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .Length(2, 10).WithMessage("姓名在2~10个字符之间");
        }
        //验证年龄
        protected void ValidateBirthDate() 
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(s=>s.Date <= DateTime.Now.AddYears(-14))
                .WithMessage("学生应该14岁以上！");
        }
        //验证邮箱
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }
        //验证手机号
        protected void ValidatePhone()
        {
            RuleFor(c => c.Phone)
                .NotEmpty()
                .Must(s=>s.Length == 11)
                .WithMessage("手机号应该为11位！");
        }
        //验证Guid
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
