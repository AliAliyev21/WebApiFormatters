using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using WebApiDemo3_22_10.Dtos;

namespace WebApiDemo3_22_10.Formatters
{
    public class TextCsvOutputFormatter : TextOutputFormatter
    {
        public TextCsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var sb = new StringBuilder();

            sb.AppendLine("Id,Fullname,SeriaNo,Age,Score");

            if (context.Object is IEnumerable<StudentDto> list)
            {
                foreach (var student in list)
                {
                    FormatCsv(sb, student);
                }
            }
            else if (context.Object is StudentDto student)
            {
                FormatCsv(sb, student);
            }

            await response.WriteAsync(sb.ToString(), selectedEncoding);
        }

        private void FormatCsv(StringBuilder sb, StudentDto student)
        {
            sb.AppendLine($"{student.Id},{student.Fullname},{student.SeriaNo},{student.Age},{student.Score}");
        }
    }
}
