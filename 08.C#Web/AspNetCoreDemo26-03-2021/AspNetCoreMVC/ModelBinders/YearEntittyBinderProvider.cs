namespace AspNetCoreMVC.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class YearEntittyBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context?.Metadata?.Name == "Year"
                && context?.Metadata?.ModelType == typeof(int?))
            {
                return new YearEntityBinder();
            }

            return null;
        }
    }
}
