﻿using System;
using WebAssembly.Browser.DOM;
using WebAssembly.Browser.DOM.Events;

namespace HelloElectron
{
    class MainClass
    {
        static int numTimes = 1;
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            System.Console.WriteLine("hello world from Main!");

            var document = Web.Document;

            var div = document.CreateElement<HTMLDivElement>();
            div.AppendChild(document.CreateElement<HTMLParagraphElement>());
            document.Body.AppendChild(div);

            var button = document.CreateElement<HTMLButtonElement>();
            
            button.TextContent = "Click Me";

            div.AppendChild(button);

            button.OnClick += (DOMObject sender, DOMEventArgs args1) =>
            {
                ((HTMLButtonElement)sender).TextContent = $"We be clicked {numTimes++} time(s)";

            };

            // Make a list
            var ul = document.CreateElement<HTMLUListElement>();
            div.AppendChild(ul);

            var li1 = document.CreateElement<HTMLLIElement>();
            var li2 = document.CreateElement<HTMLLIElement>();
            ul.AppendChild(li1);
            ul.AppendChild(li2);

            ul.OnClick += (DOMObject sender, DOMEventArgs args2) =>
            {
                args2.EventObject.Target.ConvertTo<HTMLElement>().SetStyleAttribute("visibility", "hidden");
            };


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine($"elapsedMs: {elapsedMs}");
        }
    }
}
