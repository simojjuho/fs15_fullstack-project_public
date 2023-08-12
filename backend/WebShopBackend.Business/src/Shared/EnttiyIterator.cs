namespace WebShopBackend.Business.Helpers;

public static class EnttiyIterator<T>
{
    public static void CheckNullValues(T product, T update)
    {
        var newProps = update.GetType().GetProperties();
        foreach (var property in newProps)
        {
            if (!property.CanWrite) continue;
            if (update.GetType().GetProperty(property.Name)!.GetValue(update) is null)
            {
                property.SetValue(update, product!.GetType().GetProperty(property.Name)!.GetValue(product));
            }
        }
    }

    public static void ReplaceProperyValues(T product, T update)
    {
        var newProps = update.GetType().GetProperties();
        foreach (var property in newProps)
        {
            if (property.CanWrite)
            {
                property.SetValue(product, update!.GetType().GetProperty(property.Name)!.GetValue(update));
            }
        }

    }
}