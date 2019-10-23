namespace Warships.Field
{
    public static class FieldValidator
    {
        public static bool CheckPostion(int row, int col, int max)
        {
            return row >= 0 && row < max && col >= 0 && col < max;
        }
    }
}
