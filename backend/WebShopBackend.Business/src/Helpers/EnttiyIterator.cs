namespace WebShopBackend.Business.Helpers;

public static class EnttiyIterator<T>
{
    public static void CheckNullValues(T oldVals, T newVals)
    {
        var oldProps = oldVals!.GetType().GetProperties();
        var newProps = newVals!.GetType().GetProperties();
        foreach (var property in newProps)
        {
            if (newProps.GetType().GetProperty(property.Name) is not null) continue;
            if (!property.CanWrite) continue;
            property.SetValue(newVals, oldProps.GetType().GetProperty(property.Name)!.GetValue(oldProps));
        }
    }
}