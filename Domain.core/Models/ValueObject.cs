using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.core.Models
{
    /// <summary>
    /// 定义值对象基类 
    /// 注意没有唯一标识了
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        /// 重写方法 相等运算
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            var valueObj = obj as T;
            return !ReferenceEquals(valueObj, null) && EqualsCore(valueObj);
        }

        protected abstract bool EqualsCore(T valueObj);

        /// <summary>
        /// 获取哈希
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }
        public abstract int GetHashCodeCore();
        /// <summary>
        /// 重写方法 实体比较 ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator == (ValueObject<T> a, ValueObject<T> b) 
        {
            if(ReferenceEquals(a,null) && ReferenceEquals(b,null))
                return true;
            if(ReferenceEquals(a,null)|| ReferenceEquals(b,null))
                return false;
            return a.Equals(b);
        }
        /// <summary>
        /// 重写方法 实体比较 !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 克隆副本
        /// </summary>
        public virtual T Clone()
        {
            return (T)MemberwiseClone();
        }
    }
}
