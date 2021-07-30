using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARIŞ_YILDIZ
{
    public class MatrixItem
    {
        public int column, raw;
        public int max_fark;
        public char harf;

        public MatrixItem()
        {
            raw = this.raw;
            column = this.column;
            max_fark = this.max_fark;
            harf = this.harf;
        }

        public MatrixItem(int raw,int column,int max_fark,char harf)
        {
            raw = this.raw;
            column = this.column;
            max_fark = this.max_fark;
            harf = this.harf;
        }

        public void listmaxdegerler()
        {
            max_fark = raw - column;
        }
    }
}
