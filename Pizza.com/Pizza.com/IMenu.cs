using Pizza.com.Model;

namespace Pizza.com
{
    public interface IMenu
    {
        Product GetItemByIndex(int index);
    }
}