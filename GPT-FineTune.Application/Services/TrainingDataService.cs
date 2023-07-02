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
                var jsonData = FormatData(trainingData);
                return await PersistData(jsonData);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<string> PersistData(string data)
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

            await File.WriteAllTextAsync(completePath, data);

            return $"File: {fileName}\nPath: {completePath}";
        }

        private string FormatData(IEnumerable<TrainingData> data)
        {
            var formattedDataBuilder = new StringBuilder();

            foreach (var dataItem in data)
            {
                var structureBuilder = new StringBuilder("");
                structureBuilder.Append("{\"prompt\": \"");
                structureBuilder.Append(dataItem.Prompt);
                structureBuilder.Append("\", \"completion\": \"");
                structureBuilder.Append(dataItem.Completion);
                structureBuilder.Append("\"}");

                formattedDataBuilder.AppendLine(structureBuilder.ToString());
            }

            return formattedDataBuilder.ToString();
        }
    }
}
