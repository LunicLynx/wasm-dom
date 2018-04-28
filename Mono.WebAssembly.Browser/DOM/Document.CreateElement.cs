﻿using System;
using System.Collections.Generic;

namespace Mono.WebAssembly.Browser.DOM
{
    public sealed partial class Document
    {

        static Dictionary<Type, string> htmlElementTagNameMap = new Dictionary<Type, string>()
        {
            {typeof(HTMLAnchorElement), "a"},
            {typeof(HTMLAreaElement), "area"},
            {typeof(HTMLBaseElement), "base"},
            {typeof(HTMLDivElement), "div"},
            {typeof(HTMLButtonElement), "button"},
            {typeof(HTMLBRElement), "br"},
            {typeof(HTMLInputElement), "input"},
            {typeof(HTMLFieldSetElement), "fieldset"},
            {typeof(HTMLFormElement), "form"},
            {typeof(HTMLHtmlElement), "html"},
            {typeof(HTMLHeadingElement), "h1"},
            {typeof(HTMLLabelElement), "label"},
            {typeof(HTMLLIElement), "li"},
            {typeof(HTMLLinkElement), "link"},
            {typeof(HTMLParagraphElement), "p"},
            {typeof(HTMLQuoteElement), "q"},
            {typeof(HTMLTemplateElement), "template"},
            {typeof(HTMLUListElement), "ul"},
        };

        [Export("createElement")]
        public T CreateElement<T>()
        {
            var tagName = string.Empty;
            if (!htmlElementTagNameMap.TryGetValue(typeof(T), out tagName))
                throw new NotSupportedException($"Element of type {typeof(T)} is not supported yet.  Please use the method CreateElement(tagName).");

            // When called on an HTML document, createElement() converts tagName to lower case before creating the element
            return InvokeMethod<T>("createElement", tagName);
        }

        [Export("createElement")]
        public HTMLElement CreateElement(string tagName)
        {
            Type element = null;
            if (!htmlTagNameElementMap.TryGetValue(tagName, out element))
                return InvokeMethod<HTMLElement>("createElement", tagName);
            else
                return (HTMLElement)InvokeMethod(element, "createElement", tagName);
        }


        static Dictionary<string, Type> htmlTagNameElementMap = new Dictionary<string, Type>()
        {
            {"a", typeof(HTMLAnchorElement)},
            {"abbr", typeof(HTMLElement)},
            {"acronym", typeof(HTMLElement)},
            {"address", typeof(HTMLElement)},
            //{"applet", typeof(HTMLAppletElement)},
            {"area", typeof(HTMLAreaElement)},
            {"article", typeof(HTMLElement)},
            {"aside", typeof(HTMLElement)},
            //{"audio", typeof(HTMLAudioElement)},
            {"b", typeof(HTMLElement)},
            {"base", typeof(HTMLBaseElement)},
            //{"basefont", typeof(HTMLBaseFontElement)},
            {"bdo", typeof(HTMLElement)},
            {"big", typeof(HTMLElement)},
            {"blockquote", typeof(HTMLQuoteElement)},
            //{"body", typeof(HTMLBodyElement)},
            {"br", typeof(HTMLBRElement)},
            {"button", typeof(HTMLButtonElement)},
            //{"canvas", typeof(HTMLCanvasElement)},
            //{"caption", typeof(HTMLTableCaptionElement)},
            {"center", typeof(HTMLElement)},
            {"cite", typeof(HTMLElement)},
            {"code", typeof(HTMLElement)},
            //{"col", typeof(HTMLTableColElement)},
            //{"colgroup", typeof(HTMLTableColElement)},
            //{"data", typeof(HTMLDataElement)},
            //{"datalist", typeof(HTMLDataListElement)},
            {"dd", typeof(HTMLElement)},
            //{"del", typeof(HTMLModElement)},
            {"dfn", typeof(HTMLElement)},
            //{"dir", typeof(HTMLDirectoryElement)},
            {"div", typeof(HTMLDivElement)},
            //{"dl", typeof(HTMLDListElement)},
            {"dt", typeof(HTMLElement)},
            {"em", typeof(HTMLElement)},
            //{"embed", typeof(HTMLEmbedElement)},
            {"fieldset", typeof(HTMLFieldSetElement)},
            {"figcaption", typeof(HTMLElement)},
            {"figure", typeof(HTMLElement)},
            //{"font", typeof(HTMLFontElement)},
            {"footer", typeof(HTMLElement)},
            {"form", typeof(HTMLFormElement)},
            //{"frame", typeof(HTMLFrameElement)},
            //{"frameset", typeof(HTMLFrameSetElement)},
            {"h1", typeof(HTMLHeadingElement)},
            {"h2", typeof(HTMLHeadingElement)},
            {"h3", typeof(HTMLHeadingElement)},
            {"h4", typeof(HTMLHeadingElement)},
            {"h5", typeof(HTMLHeadingElement)},
            {"h6", typeof(HTMLHeadingElement)},
            //{"head", typeof(HTMLHeadElement)},
            {"header", typeof(HTMLElement)},
            {"hgroup", typeof(HTMLElement)},
            //{"hr", typeof(HTMLHRElement)},
            {"html", typeof(HTMLHtmlElement)},
            {"i", typeof(HTMLElement)},
            //{"iframe", typeof(HTMLIFrameElement)},
            //{"img", typeof(HTMLImageElement)},
            {"input", typeof(HTMLInputElement)},
            //{"ins", typeof(HTMLModElement)},
            //{"isindex", typeof(HTMLUnknownElement)},
            {"kbd", typeof(HTMLElement)},
            {"keygen", typeof(HTMLElement)},
            {"label", typeof(HTMLLabelElement)},
            //{"legend", typeof(HTMLLegendElement)},
            {"li", typeof(HTMLLIElement)},
            {"link", typeof(HTMLLinkElement)},
            //{"listing", typeof(HTMLPreElement)},
            //{"map", typeof(HTMLMapElement)},
            {"mark", typeof(HTMLElement)},
            //{"marquee", typeof(HTMLMarqueeElement)},
            //{"menu", typeof(HTMLMenuElement)},
            //{"meta", typeof(HTMLMetaElement)},
            //{"meter", typeof(HTMLMeterElement)},
            {"nav", typeof(HTMLElement)},
            //{"nextid", typeof(HTMLUnknownElement)},
            {"nobr", typeof(HTMLElement)},
            {"noframes", typeof(HTMLElement)},
            {"noscript", typeof(HTMLElement)},
            //{"object", typeof(HTMLObjectElement)},
            //{"ol", typeof(HTMLOListElement)},
            //{"optgroup", typeof(HTMLOptGroupElement)},
            //{"option", typeof(HTMLOptionElement)},
            //{"output", typeof(HTMLOutputElement)},
            {"p", typeof(HTMLParagraphElement)},
            //{"param", typeof(HTMLParamElement)},
            //{"picture", typeof(HTMLPictureElement)},
            {"plaintext", typeof(HTMLElement)},
            //{"pre", typeof(HTMLPreElement)},
            //{"progress", typeof(HTMLProgressElement)},
            {"q", typeof(HTMLQuoteElement)},
            {"rt", typeof(HTMLElement)},
            {"ruby", typeof(HTMLElement)},
            {"s", typeof(HTMLElement)},
            {"samp", typeof(HTMLElement)},
            //{"script", typeof(HTMLScriptElement)},
            {"section", typeof(HTMLElement)},
            //{"select", typeof(HTMLSelectElement)},
            {"small", typeof(HTMLElement)},
            //{"source", typeof(HTMLSourceElement)},
            //{"span", typeof(HTMLSpanElement)},
            {"strike", typeof(HTMLElement)},
            {"strong", typeof(HTMLElement)},
            //{"style", typeof(HTMLStyleElement)},
            {"sub", typeof(HTMLElement)},
            {"sup", typeof(HTMLElement)},
            //{"table", typeof(HTMLTableElement)},
            //{"tbody", typeof(HTMLTableSectionElement)},
            //{"td", typeof(HTMLTableDataCellElement)},
            {"template", typeof(HTMLTemplateElement)},
            //{"textarea", typeof(HTMLTextAreaElement)},
            //{"tfoot", typeof(HTMLTableSectionElement)},
            //{"th", typeof(HTMLTableHeaderCellElement)},
            //{"thead", typeof(HTMLTableSectionElement)},
            //{"time", typeof(HTMLTimeElement)},
            //{"title", typeof(HTMLTitleElement)},
            //{"tr", typeof(HTMLTableRowElement)},
            //{"track", typeof(HTMLTrackElement)},
            {"tt", typeof(HTMLElement)},
            {"u", typeof(HTMLElement)},
            {"ul", typeof(HTMLUListElement)},
            {"var", typeof(HTMLElement)},
            //{"video", typeof(HTMLVideoElement)},
            {"wbr", typeof(HTMLElement)},
            //{"x-ms-webview", typeof(MSHTMLWebViewElement)},
            //{"xmp", typeof(HTMLPreElement)},
        };
    }
}
