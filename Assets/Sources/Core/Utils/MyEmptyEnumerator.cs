using System.Collections;

namespace Sources.Core.Utils
{
    public class MyEmptyEnumerator: IEnumerator
    {
        public bool MoveNext()
        {
            return false;
        }

        public void Reset()
        {
        }

        public object Current { get; private set; }
    }
}