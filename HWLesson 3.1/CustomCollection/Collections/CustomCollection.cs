
namespace  Collections
{
    public class CustomCollection<T> where T : struct 
    {
        private T[] collections; 

        public CustomCollection() 
        {
            collections = new T[0];
        }

        public int count ()
        { return collections.Length; }

        public void Sort()
        { 
             Array.Sort(collections);           
            
        }

        public void Add(T item) 
        {
           T[] array = new T[collections.Length+1];
            for (int i = 0; i < collections.Length; i++)
            {
                array[i] = collections[i];
            }

            array[collections.Length] = item;

            collections = array;

        }

        public void Print()
        {  
            foreach (T item in collections) 
            { Console.WriteLine(item); }                
        }

        public T GetValue(int index) 
        {
            return collections[index];
        }

        public void  SetValue(int index, T value)
        {
            collections[index] = value;
        }

    }
}
