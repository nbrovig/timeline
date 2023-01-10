using System.Collections;

namespace timeline.Models
{
    public class Person: IEnumerable<Person>
    {
        public int PersonId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        internal static object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Person> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
