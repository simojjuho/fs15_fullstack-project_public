namespace WebShopBackend.Core.Other;

public static class HelperMethods<T>
{
    public static T ReplaceNullVals(T oldInstance, T newInstance)
    {
        var oldProps = oldInstance.GetType().GetProperties();
        var newProps = newInstance.GetType().GetProperties();
        
    }
}