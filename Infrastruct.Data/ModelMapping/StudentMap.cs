﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.Data.ModelMapping
{
    /// <summary>
    /// 学生map类
    /// </summary>
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// 实体属性配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();

            //处理值对象，否则会被视为实体,OwnsOne定义从属关系，区分HasOne
            builder.OwnsOne(p => p.Address);
        }
    }
}
