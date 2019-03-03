using System;

namespace MYDIPLOMA.Interface
{
    public  interface SelectorInterface
    {

         void  setValue(Tuple<string,string> t);
        Tuple<string, string> getValue();
    }
}
