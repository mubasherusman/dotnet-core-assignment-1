using DotNetAssignment.Dto;
using DotNetAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace DotNetAssignment.CustomFormater.Yaml
{
    public class YamlOutputFormatter : TextOutputFormatter
    {
        public YamlOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/yaml"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(BankAccountDto).IsAssignableFrom(type)
                || typeof(IEnumerable<BankAccountDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;

            var serializer = new SerializerBuilder().Build();

            if (context.Object is IEnumerable<BankAccountDto>)
            {
                IEnumerable<BankAccountDto> bankAccounts = context.Object as IEnumerable<BankAccountDto>;
                await response.WriteAsync(serializer.Serialize(bankAccounts));
            }
            else
            {
                BankAccountDto bankAccount = context.Object as BankAccountDto;
                await response.WriteAsync(serializer.Serialize(bankAccount));
            }
            
        }
    }
}
