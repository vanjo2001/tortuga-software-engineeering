using System;
using System.Text;
using System.Collections.Generic;

namespace ZKI_1
{
    class Matrix
    {
        public int ColumnsCount { get; set; }
        public int RowsCount { get; private set; } = 0;

        private List<string> Data { get; set; } = new List<string>();
        public string Key { get; private set; }

        public Matrix()
        { }

        public Matrix(string text, string key)
        {
            ColumnsCount = key.Length;
            RowsCount = text.Length / ColumnsCount;
            Key = key;

            if (text.Length - (RowsCount * ColumnsCount) != 0)
            {
                RowsCount = (text.Length + ColumnsCount) / ColumnsCount;
            }

            int newSymbolsCount = (RowsCount * ColumnsCount) - text.Length;
            char firstSymbol = '!'; // начиная с этого символа будут добавляться дополнительные символы в строку
            for (int i = 0; i < newSymbolsCount; ++i, ++firstSymbol)
            {
                text += firstSymbol;
            }

            for(int i = 0; i < RowsCount; ++i)
            {
                Data.Add("");
            }

            StringBuilder builder = new StringBuilder();
            for (int columnIndex = 0, textIndex = 0; columnIndex < ColumnsCount; ++columnIndex)
            {
                for (int rowIndex = 0; rowIndex < RowsCount; ++rowIndex, ++textIndex)
                {
                    builder.Append(Data[rowIndex]);
                    char c = text[textIndex];
                    builder.Append(text[textIndex]);

                    Data[rowIndex] = builder.ToString();

                    builder = new StringBuilder();
                }
            }
        }

        public void PrintMatrix()
        {
            StringBuilder messageBuilder = new StringBuilder();
            foreach (string row in Data)
            {
                messageBuilder.Append(row);
            }
            Console.WriteLine(messageBuilder.ToString());
        }

        public void PrintMatrixByColumns()
        {
            StringBuilder messageBuilder = new StringBuilder();
            for (int columnIndex = 0; columnIndex < ColumnsCount; ++columnIndex)
            {
                for (int rowIndex = 0; rowIndex < RowsCount; ++rowIndex)
                {
                    messageBuilder.Append(Data[rowIndex][columnIndex]);
                }
            }
            Console.WriteLine(messageBuilder.ToString());
        }

        public void PrintMatrixWithKey()
        {
            Console.WriteLine(Key);
            foreach (string row in Data)
            {
                Console.WriteLine(row);
            }
        }

        private void SwapSymbols(int firstColIndex, int secondColIndex, int rowIndex)
        {
            StringBuilder builder = new StringBuilder(Data[rowIndex]);
            char firstSymbol = builder[firstColIndex];
            builder[firstColIndex] = builder[secondColIndex];
            builder[secondColIndex] = firstSymbol;
            Data[rowIndex] = builder.ToString();
        }

        public void SwapColumns(int firstColumnIndex, int secondColumnIndex)
        {
            StringBuilder builder = new StringBuilder(Key);
            char swapValue = builder[firstColumnIndex];
            builder[firstColumnIndex] = builder[secondColumnIndex];
            builder[secondColumnIndex] = swapValue;
            Key = builder.ToString();

            for (int rowIndex = 0; rowIndex < RowsCount; ++rowIndex)
            {
                SwapSymbols(firstColumnIndex, secondColumnIndex, rowIndex);
            }
        }

        public void SwapRows(int firstRowIndex, int secondRowIndex)
        {
            string firstRow = Data[firstRowIndex];
            Data[firstRowIndex] = Data[secondRowIndex];
            Data[secondRowIndex] = firstRow;
        }
    }
}
