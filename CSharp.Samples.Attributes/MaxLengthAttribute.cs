using System;

namespace AttributeSample
{
    [AttributeUsage(AttributeTargets.Property)]
    class MaxLengthAttribute : Attribute
    {
        public int Length { get; set; }
    }
}
