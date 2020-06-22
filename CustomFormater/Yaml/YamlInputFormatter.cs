using DotNetAssignment.Dto;
using DotNetAssignment.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DotNetAssignment.CustomFormater.Yaml
{
    public class YamlInputFormatter : TextInputFormatter
    {
        public YamlInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanReadType(Type type)
        {
            if (type == typeof(BankAccountDto))
            {
                return base.CanReadType(type);
            }
            return false;
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding effectiveEncoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (effectiveEncoding == null)
            {
                throw new ArgumentNullException(nameof(effectiveEncoding));
            }

            var request = context.HttpContext.Request;

            using var reader = new StreamReader(request.Body, effectiveEncoding);
            try
            {
                var requestData = await reader.ReadToEndAsync();
                var deserializer = new DeserializerBuilder()
                                  .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                  .Build();

                var bankAccount = deserializer.Deserialize<BankAccount>(requestData);
                return await InputFormatterResult.SuccessAsync(bankAccount);
            }
            catch
            {
                return await InputFormatterResult.FailureAsync();
            }
        }
    }
}
