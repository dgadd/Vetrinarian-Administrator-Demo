using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gaddzeit.VetAdmin.Domain.DomainServices
{
    public class CustomSet<T> : ICollection<T>
    {
        private readonly Dictionary<T, object> _nestedDictionary;

        public CustomSet()
        {
            _nestedDictionary = new Dictionary<T, object>();
        }

        public void AddAssociatedEntityToParentWithinDomain(T t)
        {
            const object nullValue = null;
            _nestedDictionary.Add(t, nullValue);
        }

        public void RemoveAssociatedEntityFromParentWithinDomain(T t)
        {
            _nestedDictionary.Remove(t);
        }


        public int Count
        {
            get { return _nestedDictionary.Count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _nestedDictionary.Keys.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new DirectAddToSetDisallowedException();
        }
        
        public void Clear()
        {
            _nestedDictionary.Clear();
        }

        public bool Contains(T item)
        {
            return _nestedDictionary.Keys.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _nestedDictionary.Keys.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new DirectRemoveFromSetDisallowedException();
        }

        public bool IsReadOnly 
        {
            get
            {
                return false; 
            }
        }
    }
}