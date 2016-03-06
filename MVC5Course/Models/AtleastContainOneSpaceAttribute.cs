using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    class AtleastContainOneSpaceAttribute : DataTypeAttribute
    {
        public AtleastContainOneSpaceAttribute() : base(DataType.Text) { }

        public override bool IsValid(object value)
        {
            return value.ToString().Contains(" ");
        }
    }
}