using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using WebApiDemo3_22_10.Dtos;
using System.Globalization;

namespace WebApiDemo3_22_10.Formatters
{
    public class TextCsvInputFormatter : TextInputFormatter
    {
        public TextCsvInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(StudentDto) || typeof(IEnumerable<StudentDto>).IsAssignableFrom(type);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var request = context.HttpContext.Request;
            using var reader = new StreamReader(request.Body, encoding);

            var content = await reader.ReadToEndAsync();
            var students = new List<StudentDto>();
            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines.Skip(1)) 
            {
                var values = line.Split(',');

                if (values.Length == 5)
                {
                    var student = new StudentDto
                    {
                        Id = int.Parse(values[0]),
                        Fullname = values[1],
                        SeriaNo = values[2],
                        Age = int.Parse(values[3]),
                        Score = int.Parse(values[4])
                    };
                    students.Add(student);
                }
            }

            return await InputFormatterResult.SuccessAsync(students);
        }
    }
}
