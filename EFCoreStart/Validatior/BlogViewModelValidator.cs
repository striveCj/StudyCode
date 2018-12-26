using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Model;
using FluentValidation;

namespace EFCoreStart.Validatior
{
   public class BlogViewModelValidator:AbstractValidator<BlogViewModel>
    {
        public BlogViewModelValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithErrorCode("博客名称不能为空");
            RuleFor(b => b.Name).MaximumLength(10).WithErrorCode("博客名称最大长度不能超过10");
            RuleFor(b => b.Url).NotEmpty().WithErrorCode("博客地址不能为空");
        }
    }
}
