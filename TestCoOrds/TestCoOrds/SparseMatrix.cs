using System;
namespace TestCoOrds
{
    public class SparseMatrix
    {
        private Term[] terms = new Term[100];
        public SparseMatrix(int r, int c)
        {
            terms[0].row = r;
            terms[0].col = c;
            terms[0].value = 0;
        }

        public void Transpose()
        {   //以C#實作，Term為實值型別 
            Term[] b = new Term[terms[0].value + 1];
            int n = terms[0].value;           //  total number of elements
            b[0].row = terms[0].col;    // rows in b = columns in terms
            b[0].col = terms[0].row;    //  columns in b = rows in terms
            b[0].value = n;
            if (n > 0)
            {                  //  non zero matrix
                int currentb = 1;
                for (int i = 0; i < terms[0].col; i++)
                {   //transpose by the columns in terms
                    for (int j = 1; j <= n; j++)
                    {  //find elements from the current column
                        if (terms[j].col == i)
                        {   //element is in current column, add it to b
                            b[currentb].row = terms[j].col;
                            b[currentb].col = terms[j].row;
                            b[currentb].value = terms[j].value;
                            currentb++;
                        }
                    }
                }
            }
            terms = b;
        }

        //...
    }
}
