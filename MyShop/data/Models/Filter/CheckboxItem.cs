namespace MyShop.data.Models.Filter
{
    public class CheckboxItem<T>
    {
        public CheckboxItem(bool checkbox, T item)
        {
            this.checkbox = checkbox;
            this.item = item;
        }

        public bool checkbox { get; set; }
        public T item { get; set; }
    }
}
