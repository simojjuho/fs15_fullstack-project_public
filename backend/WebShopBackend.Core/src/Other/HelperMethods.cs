namespace WebShopBackend.Core.Other;

public static class HelperMethods<T>
{
    public static void ReplaceNullVals(T oldInstance, T newInstance)
    {
        var oldProps = oldInstance.GetType().GetProperties();
        var newProps = newInstance.GetType().GetProperties();

        foreach (var property in newProps)
        {
            if (oldProps.GetType().GetProperty(property.Name) is not null &&
                newProps.GetType().GetProperty(property.Name) is null)
            {
                if (property.CanWrite)
                {
                    property.SetValue(newProps, oldProps.GetType().GetProperty(property.Name)!.GetValue(oldProps));
                }   
            }
        }
    }
}