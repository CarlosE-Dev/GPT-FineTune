using GPT_FineTune.Application.Interfaces;
using GPT_FineTune.Domain.Entities;
using System.Text;

namespace GPT_FineTune.Application.Services
{
    public class TrainingDataService : ITrainingDataService
    {
        public async Task<string> GenerateTrainingData(IEnumerable<TrainingData> trainingData)
        {
            try
            {
                var data = FormatData(trainingData);
                return await PersistData(data);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<string> PersistData(Dictionary<string, string> data)
        {
            var fileNameBuilder = new StringBuilder("");
            fileNameBuilder.Append("training-data-");
            fileNameBuilder.Append(Guid.NewGuid().ToString().Replace("-", ""));
            fileNameBuilder.Append(".jsonl");
            var fileName = fileNameBuilder.ToString();
            var defaultPath = Path.Combine(Directory.GetCurrentDirectory(), "TrainingFiles");

            if (!Directory.Exists(defaultPath))
            {
                Directory.CreateDirectory(defaultPath);
            }

            string completePath = Path.Combine(defaultPath, fileName);

            await File.WriteAllTextAsync(completePath, data["data"]);

            return $"File: {fileName}\nPath: {completePath}\nCount: {data["count"]}";
        }

        private Dictionary<string, string> FormatData(IEnumerable<TrainingData> data)
        {
            int count = 0;
            var formattedDataBuilder = new StringBuilder();
            var formattedData = new Dictionary<string, string>();

            foreach (var dataItem in data)
            {
                var structureBuilder = new StringBuilder("");
                structureBuilder.Append("{\"prompt\": \"");
                structureBuilder.Append(dataItem.Prompt);
                structureBuilder.Append("####");
                structureBuilder.Append("\", \"completion\": \"");
                structureBuilder.Append(dataItem.Completion);
                structureBuilder.Append("\"}");

                formattedDataBuilder.AppendLine(structureBuilder.ToString());
                count++;
            }

            formattedData.Add("data", formattedDataBuilder.ToString());
            formattedData.Add("count", count.ToString());

            return formattedData;
        }
    }
}
