using System.Text;

namespace DataHandler
{
    public class InformationStringBuilder
    {
        private readonly StringBuilder _informationTextBuilder = new StringBuilder();

        public string Length { get; set; }
        public string CheckedNodes { get; set; }
        public string GeneratedNodes { get; set; }

        public string MaximumDepth { get; set; }

        public string ElapsedTime { get; set; }

        public InformationStringBuilder()
        {
            Length = "";

            CheckedNodes = "";

            GeneratedNodes = "";

            MaximumDepth = "";

            ElapsedTime = "";
        }

        public void FillWithInformation(int length, int checkedNodes, int generatedNodes, int maximumDepth,
            double elapsedTime)
        {
            Length = length.ToString();
            CheckedNodes = checkedNodes.ToString();
            GeneratedNodes = generatedNodes.ToString();
            MaximumDepth = maximumDepth.ToString();
            ElapsedTime = elapsedTime.ToString();
        }

        public override string ToString()
        {
            _informationTextBuilder.AppendLine(Length);
            _informationTextBuilder.AppendLine(CheckedNodes);
            _informationTextBuilder.AppendLine(GeneratedNodes);
            _informationTextBuilder.AppendLine(MaximumDepth);
            _informationTextBuilder.AppendLine(ElapsedTime);
            return _informationTextBuilder.ToString();
        }
    }
}