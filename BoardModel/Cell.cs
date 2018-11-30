namespace BoardModel
{
    public class ZeroCell
    {
        public byte Row { get; set; }
        public byte Column { get; set; }

        public ZeroCell(byte r, byte c)
        {
            Row = r;
            Column = c;
        }
    }
}