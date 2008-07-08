using System;
using System.Collections.Generic;
using System.Text;

namespace Money.Net
{
    public class LstItem
    {
        public string Name;
        public Int32 ID;

        public LstItem(Int32 id, string name)
        {
            this.Name = name;
            this.ID = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is LstItem)
            {
                return ID == (obj as LstItem).ID;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
