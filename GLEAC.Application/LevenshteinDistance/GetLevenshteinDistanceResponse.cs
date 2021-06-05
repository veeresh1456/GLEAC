using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GLEAC.Common;
using GLEAC.Services.Contracts.LevenshteinDistance.Model;

namespace GLEAC.Application.LevenshteinDistance
{
    public class GetLevenshteinDistanceResponse
    {
        public string String1 { get; }
        public string String2 { get; }
        public int Distance { get; }
        public List<List<string>> ResultMatrix { get; set; }

        public GetLevenshteinDistanceResponse(LevenshteinDistanceResponse levenshteinDistanceResponse)
        {
            if (levenshteinDistanceResponse == null)
                return;

            String1 = levenshteinDistanceResponse.String1;
            String2 = levenshteinDistanceResponse.String2;
            Distance = levenshteinDistanceResponse.Distance;

            ResultMatrix = new List<List<string>>();

            GenerateResultMatrix(levenshteinDistanceResponse.ResultMatrix);
        }

        private void GenerateResultMatrix(int[,] resultMatrix)
        {
            var string2Chars = new List<string>
            {
                " ",
                " "
            };

            string2Chars.AddRange(String2.Select(ch => ch.ToString()));

            ResultMatrix.Add(string2Chars);

            var rowsFirstIndex = resultMatrix.GetLowerBound(0);
            var rowsLastIndex = resultMatrix.GetUpperBound(0);

            var columnsFirstIndex = resultMatrix.GetLowerBound(1);
            var columnsLastIndex = resultMatrix.GetUpperBound(1);

            for (var i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                var values = new List<string>
                {
                    i != 0 ? String1[i - 1].ToString() : " "
                };

                for (var j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    values.Add(resultMatrix[i, j].ToString());
                }

                ResultMatrix.Add(values);
            }
        }
    }
}
