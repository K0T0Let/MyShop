namespace MyShop.data.Models.Filter
{
    public class CheckboxList<T>
    {
        public CheckboxList(bool checkbox, T item)
        {
            this.checkbox = checkbox;
            this.item = item;
        }

        public bool checkbox { get; set; }
        public T item { get; set; }
    }
}
