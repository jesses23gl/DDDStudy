using Domain.core.Models;
using Domain.Models;

namespace Domain
{
    public class Student : BaseEntity
    {
        protected Student() { }
        public Student(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDate { get; private set; }

        //我们通过把地址建模成值对象，而不是实体，然后把值对象的属性值嵌入外部员工实体的表中，这种映射方式被称为嵌入值模式
        //Address因其描述了领域中的一个东西，可以作为一个不变量，当它被改变时，可以用另一个值对象替换，可以和别的值对象进行相等性比较，从而可以让其为一个值对象
        //Address 是反映 通用语言 概念的值对象
        //可以直接使用Address address = new Address("北京市", "北京市", "海淀区", "一路 ");)来表示一个具体的通过属性识别的不可变的位置概念。在DDD中，我们称这个Address为值对象。
        public Address Address { get; set; }
    }
}