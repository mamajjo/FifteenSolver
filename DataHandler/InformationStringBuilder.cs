using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataHandler
{
    public class InformationStringBuilder
    {
        private StringBuilder informationTextBuilder = new StringBuilder();

        public string Length { get; set; }
        public string CheckedNodes { get; set; }
        public string GeneratedNodes { get; set; }

        public string MaximumDepth { get; set; }

        public string ElapsedTime { get; set; }


        public InformationStringBuilder()
        {
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
            informationTextBuilder.AppendLine(Length);
            informationTextBuilder.AppendLine(CheckedNodes);
            informationTextBuilder.AppendLine(GeneratedNodes);
            informationTextBuilder.AppendLine(MaximumDepth);
            informationTextBuilder.AppendLine(ElapsedTime);
            return informationTextBuilder.ToString();
        }
    }
}
