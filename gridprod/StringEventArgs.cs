using System;

namespace GridProd
{
    public class StringEventArgs: EventArgs
    {
        public string StringAddedOrRemoved;
        public override string ToString()
        {
            return StringAddedOrRemoved;
        }
    }
}
