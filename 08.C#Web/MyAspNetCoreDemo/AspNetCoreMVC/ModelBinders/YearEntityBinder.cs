namespace AspNetCoreMVC.ModelBinders
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class YearEntityBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("ArrivedOn").FirstValue;

            if (DateTime.TryParse(value, out var valueAsDateType))
            {
                bindingContext.Result =
                    ModelBindingResult
                        .Success(valueAsDateType.Year);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}
