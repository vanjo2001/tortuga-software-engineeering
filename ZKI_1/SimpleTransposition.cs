using System;
using System.Text;

namespace ZKI_1
{
    class SimpleTransposition
    {
        public Matrix Data { get; private set; }
        private string Key { get; set; }

        public SimpleTransposition(Matrix message)
        {
            Data = message;
            Key = message.Key;
        }

        public void Encode(string key)
        {
            SortMatrixColumns(0, Data.ColumnsCount - 1);
        }

        private void SortMatrixColumns(int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(left, right);

                if (pivot > 1)
                {
                    SortMatrixColumns(left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    SortMatrixColumns(pivot + 1, right);
                }
            }
        }

        private int Partition(int left, int right)
        {
            char pivot = Key[left];

            while (true)
            {
                while (Key[left] < pivot)
                {
                    ++left;
                }
                while (Key[right] > pivot)
                {
                    --right;
                }

                if (left < right)
                {
                    if (Key[left] == Key[right]) return right;

                    Data.SwapColumns(left, right);
                    Key = Data.Key;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
