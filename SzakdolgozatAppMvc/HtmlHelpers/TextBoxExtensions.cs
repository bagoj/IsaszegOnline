using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SzakdolgozatAppMvc.Enums;
using static SzakdolgozatAppMvc.Enums.Enums;

namespace SzakdolgozatAppMvc
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString IsaTextBox(this HtmlHelper htmlHelper,string divId, string labelname, object expression,
            bool readonlyE=false,bool password=false)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "form-row");
            div.MergeAttribute("id", divId);
            TagBuilder label = new TagBuilder("label");
            label.MergeAttribute("class", "col-xs-12 col-sm-12 col-md-5 col-lg-5 col-xl-4 col-form-label");
            label.InnerHtml = labelname;
            TagBuilder belsoDiv = new TagBuilder("div");
            belsoDiv.MergeAttribute("class", "col-xs-12 col-sm-12 col-md-7 col-lg-7 col-xl-8");
            TagBuilder divin = new TagBuilder("div");
            divin.MergeAttribute("class", "input-group");
            TagBuilder input = new TagBuilder("input");
            input.MergeAttribute("class", "form-control");
            input.MergeAttribute("id", divId);
            input.MergeAttribute("name", divId);
            if (readonlyE)
            {
                input.MergeAttribute("readonly", readonlyE.ToString());
            }
            if(!password)
            input.MergeAttribute("type", "text");
            else input.MergeAttribute("type", "password");
            if (expression != null)
            input.MergeAttribute("value", expression.ToString());
            else input.MergeAttribute("value", "");
            divin.InnerHtml = input.ToString();
            belsoDiv.InnerHtml = divin.ToString();
            div.InnerHtml = label.ToString() + belsoDiv.ToString();
            return new MvcHtmlString(div.ToString());
        }
        public static MvcHtmlString IsaHidden(this HtmlHelper htmlHelper,string Id, object expression)
        {
            TagBuilder input = new TagBuilder("input");
            input.MergeAttribute("type", "hidden");
            input.MergeAttribute("id", Id.ToString());
            input.MergeAttribute("value", expression.ToString());
            return new MvcHtmlString(input.ToString());
        }

        public static MvcHtmlString Select2PosCompuond(this HtmlHelper htmlHelper, string id, string divId, string labelname, object expression, 
            bool readonlyE = false)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "form-row");
            div.MergeAttribute("id", divId);
            TagBuilder label = new TagBuilder("label");
            label.MergeAttribute("class", "col-xs-12 col-sm-12 col-md-5 col-lg-5 col-xl-4 col-form-label");
            label.InnerHtml = labelname;
            TagBuilder belsoDiv = new TagBuilder("div");
            belsoDiv.MergeAttribute("class", "col-xs-12 col-sm-12 col-md-7 col-lg-7 col-xl-8");
            TagBuilder divin = new TagBuilder("div");
            divin.MergeAttribute("class", "select-control");
            TagBuilder select = new TagBuilder("select");
            select.MergeAttribute("class", "js-example-basic-single");
            TagBuilder option1 = new TagBuilder("option");
            option1.MergeAttribute("value", "0");
            option1.InnerHtml = "Kapus";
            TagBuilder option2 = new TagBuilder("option");
            option2.MergeAttribute("value", "1");
            option2.InnerHtml = "Védő";
            TagBuilder option3 = new TagBuilder("option");
            option3.MergeAttribute("value", "2");
            option3.InnerHtml = "Középpályás";
            TagBuilder option4 = new TagBuilder("option");
            option4.MergeAttribute("value", "3");
            option4.InnerHtml = "Csatár";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(option1.ToString());
            sb.AppendLine(option2.ToString());
            sb.AppendLine(option3.ToString());
            sb.AppendLine(option4.ToString());
            select.MergeAttribute("id", divId);
            select.MergeAttribute("name", divId);
            if (readonlyE)
            {
                select.MergeAttribute("readonly", readonlyE.ToString());
            }
            select.InnerHtml = sb.ToString();
            divin.InnerHtml = select.ToString();
            belsoDiv.InnerHtml = divin.ToString();
            div.InnerHtml = label.ToString() + belsoDiv.ToString();
            return new MvcHtmlString(div.ToString());
        }
        //public static MvcHtmlString IsaRadioButton(this HtmlHelper htmlHelper,string Id,)
    }
}