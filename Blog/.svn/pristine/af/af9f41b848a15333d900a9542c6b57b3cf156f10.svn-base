using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc.Html
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString KindEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int width, int height)
        {
            //获取属性的名称 tAGBUILDER 
            var exp = expression.Body as MemberExpression;
            string expStr = exp.ToString();//形如 m.name  
            string id = expStr.Substring(expStr.IndexOf(".") + 1);

            return new MvcHtmlString("<textarea name=\"" + id + "\" style=\"width: " + width + "px; height: " + height + "px; visibility: hidden; \"></textarea>");
        }

        public static web.App_Code.BlogDbContext GetDbContext()
        {
            return new web.App_Code.BlogDbContext();
        }
    }

}