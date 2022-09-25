using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Primitives;

namespace QuizGame.Requests;

/// <summary>
/// Used as attribute on routes to check if a query string exists
/// </summary>

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class CheckQueryStringAttribute : ActionMethodSelectorAttribute
{
    public string QueryStringName { get; set; }
    public bool CanPass { get; set; }
    
    public CheckQueryStringAttribute(string qname, bool canpass)
    {
        QueryStringName = qname;
        CanPass = canpass;
    }
    
    
    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    {
        StringValues value;

        routeContext.HttpContext.Request.Query.TryGetValue(QueryStringName, out value);

        if (CanPass)
        {
            return !StringValues.IsNullOrEmpty(value);
        }

        return StringValues.IsNullOrEmpty(value);
    }
}